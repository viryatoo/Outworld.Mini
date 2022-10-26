using UnityEngine;

namespace OutworldMini
{
    public static class DebugLogExt
    {
        public static void LogErrorIfNotFind<T>(T obj,string name)
        {
            if(obj == null)
            {
                Debug.LogError($"Didn't find {name} instance. ");
            }

        }
    }

}