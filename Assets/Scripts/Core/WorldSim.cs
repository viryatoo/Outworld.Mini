using System.Collections;
using System.Collections.Generic;
using OutworldMini.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace OutworldMini
{
    [System.Serializable]
    public class WorldSim : MonoBehaviour, IState
    {
        [SerializeField] private AllScenesSO allScenes;
        [SerializeField] private Map map;
        [SerializeField] private CellInfoPanel cellInfoPanel;
        [SerializeField] private CameraMovement cameraMovement;
        [SerializeField] private AdditiveSceneLoader sceneLoader;
        [FormerlySerializedAs("SecondsPerMove")] [SerializeField] private int secondsPerMove;
        private ICorutineRunner coroutineRunner;
        
        public void Init(ICorutineRunner runner)
        {
            coroutineRunner = runner;
        }

        public void Enter(SimpleStateMachine simpleStateMachine)
        {
            InitComponents();
            coroutineRunner.StartCoroutine(Tick());
        }

        private void InitComponents()
        {
            map.Init();
            cameraMovement.Init(new Rect(0,0,map.WorldWight,map.WorldWight));
            cellInfoPanel.Init(map);
            
        }

        public void Exit(SimpleStateMachine simpleStateMachine)
        {
            coroutineRunner.StopCoroutine(Tick());
        }

        private IEnumerator Tick()
        {
            while(true)
            {
                map.UpdateWorld();
                yield return new WaitForSeconds(secondsPerMove);
            }

        }

        public void LateUpdateState(SimpleStateMachine simpleStateMachine)
        {

        }

        public void UpdateState(SimpleStateMachine simpleStateMachine)
        {

        }
    }
}
