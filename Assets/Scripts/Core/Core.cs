using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OutworldMini
{
    public sealed class Core : MonoBehaviour
    {

        [SerializeField] private AllScenesSO allScenesSO;
        [SerializeField] private AdditiveSceneLoader sceneLoader;
        private SimpleStateMashine MainStateMashine;
        [SerializeReference] private IState worldSimulation;

        private void Awake()
        {
            MainStateMashine = new SimpleStateMashine();

            MainStateMashine.TransitionTo(worldSimulation);
        }
        
    }
}


