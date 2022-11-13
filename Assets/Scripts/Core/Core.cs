using System;
using OutworldMini.Core.States;
using OutworldMini.Core.Containers;
using UnityEngine;

namespace OutworldMini.Core
{
    public sealed class Core : MonoBehaviour, ICorutineRunner
    {
        private SimpleStateMachine mainStateMachine;
        private Container container;
        
        public void Init()
        {
            container = new Containers.Container();
            mainStateMachine = new SimpleStateMachine(new InitializeState(container));
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            mainStateMachine.UpdateState();
        }
    }
}


