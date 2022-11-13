
using OutworldMini.Core;

namespace OutworldMini
{
    public interface IState
    {
        public void Enter(SimpleStateMachine simpleStateMachine);
        public void LateUpdateState(SimpleStateMachine simpleStateMachine);
        public void UpdateState(SimpleStateMachine simpleStateMachine);
        public void Exit(SimpleStateMachine simpleStateMachine);
    }
}