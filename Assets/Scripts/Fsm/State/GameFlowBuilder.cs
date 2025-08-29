using System;
using Core.Fsm;
using Scenes.Scripts.Fsm.State;
using Scenes.Scripts.Fsm.State.MenuState;
using UnityEngine;

namespace Scenes.Scripts.Fsm
{
    public class GameFlowBuilder : MonoBehaviour
    {
        private FsmController _fsmController;
        private Test _t;
        
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            Build();
        }

        private void Build()
        {
            // _fsmController = new FsmController();
            // var loadingState = new LoadingState();
            // var metaState = new MetaState();
            // var levelState = new LevelState();
            // _fsmController.AddState(loadingState); 
            // _fsmController.AddState(metaState);
            // _fsmController.AddState(levelState);
            //
            // loadingState.AddTransition(metaState);
            // metaState.AddTransition(levelState);
            // levelState.AddTransition(metaState);
            //
            // _fsmController.Initialize();

            _t = new Test();
            _t.Initialize();
        }

        private void Update()
        {
            _t.Update();
        }
    }
}