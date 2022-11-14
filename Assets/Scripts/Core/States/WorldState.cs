using OutworldMini.Services;
using OutworldMini.SOdata;
using OutworldMini.SOData;

namespace OutworldMini.Core.States
{
    public class WorldState: IState
    {
        private IStaticDataProvider staticDataProvider;
        private LevelData levelData;
        private WorldData worldData;

        public WorldState(IStaticDataProvider dataProvider)
        {
            staticDataProvider = dataProvider;
        }
        
        public void Enter(SimpleStateMachine simpleStateMachine)
        {
            levelData = staticDataProvider.GetLevelData("none");
            worldData = staticDataProvider.GetWorldData("none");
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

        private void InitializeLevel()
        {
            
        }
    }
}