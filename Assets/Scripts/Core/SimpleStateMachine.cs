
namespace OutworldMini.Core
{
    public class SimpleStateMachine
    {
        private IState currentState;

        public SimpleStateMachine(IState state)
        {
            currentState = state;
            state.Enter(this);
        }

        public void TransitionTo(IState state)
        {
            currentState.Exit(this);

            currentState = state;
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

