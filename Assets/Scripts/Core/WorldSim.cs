using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace OutworldMini
{
    public class WorldSim : IState
    {
        private AllScenesSO allScenes;
        private Map map;
        private CameraMovement cameraMovement;

        private AdditiveSceneLoader sceneLoader;


        public WorldSim(AllScenesSO scenes,AdditiveSceneLoader additiveSceneLoader)
        {
            allScenes = scenes;
            sceneLoader = additiveSceneLoader;
        }

        public void Enter(SimpleStateMashine simpleStateMashine)
        {

            sceneLoader.LoadScene(allScenes.WorlSimulation,InitScene);

        }

        private void InitScene()
        {
            map = GameObject.FindObjectOfType<Map>();
            cameraMovement = GameObject.FindObjectOfType<CameraMovement>();

            DebugLogExt.LogErrorIfNotFind(map,nameof(map));
            DebugLogExt.LogErrorIfNotFind(cameraMovement,nameof(cameraMovement));
            
            map.Init();
            cameraMovement.Init(new Rect(0,0,map.Wight,map.Wight));
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
