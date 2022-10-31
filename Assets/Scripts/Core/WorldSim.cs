using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace OutworldMini
{
    [System.Serializable]
    public class WorldSim : IState
    {
         [SerializeField] private AllScenesSO allScenes;
        [SerializeField] private Map map;
        [SerializeField] private CellInfoPanel cellInfoPanel;
        [SerializeField] private CameraMovement cameraMovement;
        [SerializeField] private AdditiveSceneLoader sceneLoader;

        public void Enter(SimpleStateMashine simpleStateMashine)
        {
            Init();
        }

        private void Init()
        {
            map.Init();
            cameraMovement.Init(new Rect(0,0,map.Wight,map.Wight));
            cellInfoPanel.Init(map);
            
        }

        public void Exit(SimpleStateMashine simpleStateMashine)
        {
            
        }

        public void LateUpdate(SimpleStateMashine simpleStateMashine)
        {
            
        }

        public void Update(SimpleStateMashine simpleStateMashine)
        {
            
        }


   }
}
