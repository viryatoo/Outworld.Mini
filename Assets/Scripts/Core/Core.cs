using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OutworldMini
{
    public sealed class Core : MonoBehaviour, ICorutineRunner
    {

        [SerializeField] private AllScenesSO allScenesSO;
        [SerializeField] private AdditiveSceneLoader sceneLoader;
        [SerializeField] private WorldSim worldSimulation;
        private SimpleStateMashine MainStateMashine;
        private void Awake()
        {

            MainStateMashine = new SimpleStateMashine();
            worldSimulation.Init(this);
            MainStateMashine.TransitionTo(worldSimulation);
            
        }
        
    }
}


