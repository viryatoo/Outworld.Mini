using System;

namespace OutworldMini.Utils
{
    public interface ISceneLoader
    {
        void LoadScene(string name, Action onLoaded = null);
    }
}