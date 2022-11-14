using System;
using System.Collections.Generic;
using OutworldMini.Core.States;
using OutworldMini.Core.Containers;
using OutworldMini.Services;
using OutworldMini.Utils;
using UnityEngine;

namespace OutworldMini.Core
{
    public sealed class Core : MonoBehaviour, ICorutineRunner
    {
        private SimpleStateMachine mainStateMachine;
        private IContainer container;
        
        public void Init()
        {
            container = new Containers.Container();
            mainStateMachine = new SimpleStateMachine(container,CreateStates());
            DontDestroyOnLoad(this);
        }

        private Dictionary<Type, IState> CreateStates()
        {
            return new Dictionary<Type, IState>()
            {
                { typeof(InitializeState), new InitializeState(container) },
                { typeof(WorldState), new WorldState(container.GetSingle<IStaticDataProvider>()) },
            };
        }

        private void Update()
        {
            mainStateMachine.UpdateState();
        }
    }
}


