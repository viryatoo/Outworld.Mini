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

        private CellInfoPanel cellInfoPanel;
        private CameraMovement cameraMovement;
        private AdditiveSceneLoader sceneLoader;


        public WorldSim(AllScenesSO scenes,AdditiveSceneLoader additiveSceneLoader)
        {
            allScenes = scenes;
            sceneLoader = additiveSceneLoader;
        }

        public void Enter(SimpleStateMashine simpleStateMashine)
        {

            sceneLoader.LoadScene(allScenes.WorlSimulation,InitWorlSimScene);
            sceneLoader.LoadScene(allScenes.UI,InitUI);

        }

        private void InitWorlSimScene()
        {
            map = GameObject.FindObjectOfType<Map>();
            cameraMovement = GameObject.FindObjectOfType<CameraMovement>();
            Debug.Log("Init");
            DebugLogExt.LogErrorIfNotFind(map,nameof(map));
            DebugLogExt.LogErrorIfNotFind(cameraMovement,nameof(cameraMovement));

            map.Init();
            cameraMovement.Init(new Rect(0,0,map.Wight,map.Wight));
            
        }

        private void InitUI()
        {
            cellInfoPanel = GameObject.FindObjectOfType<CellInfoPanel>();
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
