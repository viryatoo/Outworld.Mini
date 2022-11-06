using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OutworldMini
{
    public class AppStart : MonoBehaviour
    {
        [SerializeField]
        private readonly string NEXT_SCENE;
        
        private void Awake()
        {
            SceneManager.LoadScene(NEXT_SCENE);
        }
    }
}

