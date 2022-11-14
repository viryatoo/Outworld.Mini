using OutworldMini.SOdata;
using OutworldMini.SOData;

namespace OutworldMini.Services
{
    public interface IStaticDataProvider
    {
        public LevelData GetLevelData(string path);

        public WorldData GetWorldData(string path);
    }
}