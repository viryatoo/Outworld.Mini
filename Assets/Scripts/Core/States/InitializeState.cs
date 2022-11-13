namespace OutworldMini.Core.States
{
    public class InitializeState: IState
    {
        private Containers.Container container;
        
        public InitializeState(Containers.Container coreContainer)
        {
            container = coreContainer;
        }
        
        public void Enter(SimpleStateMachine simpleStateMachine)
        {
            RegisterServices();
        }

        public void LateUpdateState(SimpleStateMachine simpleStateMachine)
        {

        }

        public void UpdateState(SimpleStateMachine simpleStateMachine)
        {
            
        }

        public void Exit(SimpleStateMachine simpleStateMachine)
        {
            
        }

        private void RegisterServices()
        {
            
        }
    }
}