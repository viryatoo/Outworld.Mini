using UnityEngine;
using UnityEngine.SceneManagement;

namespace OutworldMini.Core
{
    public class AppStart : MonoBehaviour
    {
        [SerializeField] private string nextScene;
        [SerializeField] private Core core;
        
        private void Awake()
        {
            core.Init();
            SceneManager.LoadScene(nextScene);
        }
    }
}

