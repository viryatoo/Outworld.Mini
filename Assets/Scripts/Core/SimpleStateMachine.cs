
using System;
using System.Collections.Generic;
using OutworldMini.Core.Containers;
using OutworldMini.Core.States;

namespace OutworldMini.Core
{
    public class SimpleStateMachine
    {
        private IState currentState;
        private readonly Dictionary<Type, IState> states;
        
        public SimpleStateMachine(IContainer container, Dictionary<Type, IState> gameStates)
        {
            states = gameStates;
        }

        public void TransitionTo<TType>()
        {
            currentState.Exit(this);

            currentState = states[typeof(TType)];
            currentState.Enter(this);
        }
        public void UpdateState()
        {
            currentState.UpdateState(this);
        }
        public void LateUpdateState()
        {
            currentState.LateUpdateState(this);
        }
    }
}

