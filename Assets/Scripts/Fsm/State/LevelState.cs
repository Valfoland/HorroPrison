using System;
using Core.Fsm;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Scenes.Scripts.Fsm.State
{
    public class LevelState : StateBase
    {
        private LevelScreen _levelScreen;

        public override string Id => "LevelState";

        public override void OnEnter(Action<StateBase> onComplete)
        {
            base.OnEnter(onComplete);

            InitializeStateAsync();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        private async void InitializeStateAsync()
        {
            await SceneManager.LoadSceneAsync("Game");

            _levelScreen = Object.FindAnyObjectByType<LevelScreen>(FindObjectsInactive.Include);
            _levelScreen.Initialize(OnExitButtonClicked);
            _levelScreen.Activate();
        }

        private void OnExitButtonClicked()
        {
            Finish();
        }
    }
}