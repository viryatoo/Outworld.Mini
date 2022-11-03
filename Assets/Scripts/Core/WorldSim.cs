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
        [SerializeField] private int SecondsPerMove;
        private ICorutineRunner corutineRunner;

        public void Init(ICorutineRunner runner)
        {
            corutineRunner = runner;
        }

        public void Enter(SimpleStateMashine simpleStateMashine)
        {
            Init();
            corutineRunner.StartCoroutine(Tick());
        }

        private void Init()
        {
            map.Init();
            cameraMovement.Init(new Rect(0,0,map.Wight,map.Wight));
            cellInfoPanel.Init(map);
            
        }

        public void Exit(SimpleStateMashine simpleStateMashine)
        {
            corutineRunner.StopCoroutine(Tick());
        }

        private IEnumerator Tick()
        {
            while(true)
            {
                map.UpdateWorld();
                yield return new WaitForSeconds(SecondsPerMove);
            }

        }

        public void LateUpdate(SimpleStateMashine simpleStateMashine)
        {

        }

        public void Update(SimpleStateMashine simpleStateMashine)
        {

        }
    }
}
