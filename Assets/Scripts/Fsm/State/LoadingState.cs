using System;
using Core.Fsm;
using UnityEngine;
using Object = UnityEngine.Object;
using Task = System.Threading.Tasks.Task;

namespace Scenes.Scripts.Fsm.State
{
    public class LoadingState : StateBase
    {
        private LoadingScreen _loadingScreen;
        
        public override string Id => "LoadingState";

        public override void OnEnter(Action<StateBase> onComplete)
        {
            base.OnEnter(onComplete);

            _loadingScreen = Object.FindAnyObjectByType<LoadingScreen>(FindObjectsInactive.Include);
            _loadingScreen.Activate();

            WaitScene();
        }
        
        private async void WaitScene()
        {
            await Task.Delay(5000);

            Finish();
        }
    }
}