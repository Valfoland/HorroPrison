using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Fsm
{
    public abstract class StateBase
    {
        public readonly List<StateTransition> stateTransitions = new();

        public abstract string Id { get; }
        protected StateCompletionType StateCompletionType { get; private set; } = StateCompletionType.None;

        public event Action<StateBase> OnEnterState;

        public event Action<StateBase> OnExitState;

        public event Action<StateBase> OnFinishState;

        public event Action<StateBase> OnRestartState;

        public void AddTransition(StateBase targetState, params Func<bool>[] predicates)
        {
            stateTransitions.Add(new StateTransition(this, targetState, predicates.ToList()));
        }

        public void AddTransition(StateBase targetState)
        {
            stateTransitions.Add(new StateTransition(this, targetState, null));
        }

        public virtual void OnEnter(Action<StateBase> onComplete)
        {
            OnEnterState?.Invoke(this);
        }

        public virtual void OnExit()
        {
            OnExitState?.Invoke(this);
        }

        public void Finish()
        {
            StateCompletionType = StateCompletionType.Finished;
            OnFinishState?.Invoke(this);
        }

        public void Restart()
        {
            StateCompletionType = StateCompletionType.Restarted;
            OnRestartState?.Invoke(this);
        }

        public virtual void Deinitialize()
        {
            OnEnterState = null;
            OnExitState = null;
            OnFinishState = null;
            OnRestartState = null;
        }
    }
}