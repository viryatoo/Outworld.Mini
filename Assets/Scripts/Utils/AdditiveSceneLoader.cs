using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OutworldMini.Utils
{
    public class AdditiveSceneLoader : ISceneLoader
    {
        private ICorutineRunner coroutineRunner;
        public void LoadScene(string name, Action onLoaded = null)
        {
            coroutineRunner.StartCoroutine(LoadCoroutine(name,onLoaded));
        }
        private static IEnumerator LoadCoroutine(string name, Action onLoaded)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(name,LoadSceneMode.Single);
            operation.allowSceneActivation = true;

            while(operation.isDone==false)
            {

                yield return null;
            }

            onLoaded?.Invoke();
        }
    }
}