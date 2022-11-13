using OutworldMini.SOdata;
using OutworldMini.SOData;

namespace OutworldMini.Services
{
    public interface IStaticDataProvider
    {
        public LevelData LoadLevel(string path);
    }
}