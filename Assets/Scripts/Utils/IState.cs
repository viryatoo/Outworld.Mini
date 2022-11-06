
namespace OutworldMini
{
    public interface IState
    {
        public void Enter(SimpleStateMashine simpleStateMashine);
        public void LateUpdateState(SimpleStateMashine simpleStateMashine);
        public void UpdateState(SimpleStateMashine simpleStateMashine);
        public void Exit(SimpleStateMashine simpleStateMashine);
    }
}