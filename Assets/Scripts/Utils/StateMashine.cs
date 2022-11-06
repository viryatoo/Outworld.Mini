using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutworldMini
{
    public class SimpleStateMashine
    {
        private IState currentState;

        public void TransitionTo(IState state)
        {
            if (currentState != null)
            {
                currentState.Exit(this);
            }

            currentState = state;
            currentState.Enter(this);
        }

        public void UpdateState()
        {
            if (currentState != null)
                currentState.UpdateState(this);
        }
        public void LateUpdateState()
        {
            if (currentState != null)
                currentState.LateUpdateState(this);
        }
    }
}

