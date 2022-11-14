using OutworldMini.Core.Containers;
using OutworldMini.Services;
using OutworldMini.Utils;

namespace OutworldMini.Core.States
{
    public class InitializeState: IState
    {
        private const string nextLevel = "MainLevel";
        private readonly IContainer container;
        private SimpleStateMachine sm;
        public InitializeState(IContainer coreContainer)
        {
            container = coreContainer;
            RegisterServices();
        }
        
        public void Enter(SimpleStateMachine simpleStateMachine)
        {
            sm = simpleStateMachine;
            container.GetSingle<ISceneLoader>().LoadScene(nextLevel);
            
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
            container.RegisterSingle<ISceneLoader>(new AdditiveSceneLoader());
            container.RegisterSingle<IStaticDataProvider>(new StaticDataProvider());
        }

        private void OnLevelLoaded()
        {
            sm.TransitionTo<WorldState>();
        }
    }
}