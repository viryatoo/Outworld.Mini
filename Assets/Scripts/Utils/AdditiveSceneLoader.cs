using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace OutworldMini
{

    public class AdditiveSceneLoader : MonoBehaviour
    {

        public void LoadScene(string name, Action onLoaded)
        {
            StartCoroutine(LoadCouroutine(name,onLoaded));
        }
        private IEnumerator LoadCouroutine(string name, Action onLoaded)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(name,LoadSceneMode.Additive);
            operation.allowSceneActivation = false;

            while(operation.isDone==false)
            {
                    

                
                yield return null;
            }
            onLoaded.Invoke();
        }
    }
}