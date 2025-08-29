using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Fsm
{
    public class FsmController
    {
        private readonly List<StateBase> _states = new();
        private StateBase _currentState;

        public event Action<StateBase, StateBase> OnStateChanged;

        public event Action<StateBase, StateBase> OnStateChangingStarted;

        public void Initialize()
        {
            if (_states.Count == 0)
            {
                throw new Exception("Can't start empty state controller");
            }

            _currentState = _states[0];
            _currentState.OnEnter(null);
        }

        public void Deinitialize()
        {
            foreach (var state in _states)
            {
                state.Deinitialize();
            }

            _states.Clear();
        }

        public void AddState(StateBase state)
        {
            if (_states.Any(cachedState => cachedState.Id == state.Id))
            {
                throw new Exception("This was a try of adding an already cached state!");
            }

            _states.Add(state);

            state.OnFinishState += OnFinishState;
            state.OnRestartState += OnRestartState;
        }

        public void RemoveState(string stateId)
        {
            var stateToRemove = _states.FirstOrDefault(state => state.Id == stateId);

            if (stateToRemove != null)
            {
                _states.Remove(stateToRemove);
            }
        }

        public void RemoveState(StateBase state)
        {
            _states.Remove(state);
        }

        public void CloseCurrentState()
        {
            CloseState(_currentState);
        }

        public void CloseState(string stateId)
        {
            GetStateById(stateId).OnExit();
        }

        public void CloseState(StateBase state)
        {
            if (state == null)
            {
                Debug.LogError($"State: {state} is null");
                return;
            }

            state.OnExit();
        }

        public void SetState(string stateId)
        {
            SetState(GetStateById(stateId));
        }

        public void SetState(StateBase state)
        {
            if (state == null)
            {
                Debug.LogError($"State: {state} is null");
                return;
            }

            OnStateChangingStarted?.Invoke(_currentState, state);
            var defaultTransition = new StateTransition(_currentState, state, null);
            defaultTransition.Transit(newState =>
            {
                OnStateChanged?.Invoke(_currentState, newState);
                _currentState = newState;
            });
        }

        public StateBase GetStateById(string stateId)
        {
            var requiredState = _states.FirstOrDefault(s => s.Id == stateId);
            if (requiredState != null)
            {
                return requiredState;
            }

            throw new Exception($"Cannot transit to state by tag: {stateId}");
        }

        public void Transit(string stateId, Action<StateBase> onCompleted)
        {
            Transit(GetStateById(stateId), onCompleted);
        }

        public void Transit(StateBase state, Action<StateBase> onCompleted)
        {
            foreach (var stateTransition in state.stateTransitions)
            {
                if (!stateTransition.Check())
                {
                    continue;
                }

                OnStateChangingStarted?.Invoke(_currentState, stateTransition.ToState);
                stateTransition.Transit(newState =>
                {
                    OnStateChanged?.Invoke(_currentState, newState);
                    _currentState = newState;
                    onCompleted?.Invoke(newState);
                });
                return;
            }

            throw new Exception($"Cannot transit from state: {state.Id}");
        }

        private void OnFinishState(StateBase state)
        {
            Transit(state, null);
        }

        private void OnRestartState(StateBase state)
        {
            SetState(state);
        }
    }
}