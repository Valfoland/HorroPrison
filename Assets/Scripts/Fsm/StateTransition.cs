using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Fsm
{
    public class StateTransition
    {
        public StateBase FromState { get; }
        public StateBase ToState { get; }

        private readonly IReadOnlyCollection<Func<bool>> _predicates;

        public StateTransition(StateBase fromState, StateBase toState,
            IReadOnlyCollection<Func<bool>> predicates)
        {
            FromState = fromState;
            ToState = toState;
            _predicates = predicates;
        }

        public void Transit(Action<StateBase> onCompleted)
        {
            if (!Check())
            {
                return;
            }

            FromState.OnExit();
            ToState.OnEnter(onCompleted);
            onCompleted?.Invoke(ToState);
        }

        public bool Check()
        {
            return _predicates == null || _predicates.All(predicate => predicate());
        }
    }
}