using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OutworldMini.SOdata;
using OutworldMini.SOData;
using UnityEngine;

namespace OutworldMini.Services
{
    public class StaticDataProvider : IStaticDataProvider
    {
        public LevelData GetLevelData(string path)
        { 
            return ScriptableObject.CreateInstance<LevelData>();
        }
        
        public WorldData GetWorldData(string path)
        {
            return ScriptableObject.CreateInstance<WorldData>();
        }
    }
}