using System;
using Core.Fsm;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Scenes.Scripts.Fsm.State.MenuState
{
    public class MetaState : StateBase
    {
        private MenuScreen _menuScreen;
        private ShopScreen _shopScreen;
        private BattlePassScreen _battlePassScreen;
        private MetaFlowBuilder _metaFlowBuilder;

        public override string Id => "MetaState";

        public override void OnEnter(Action<StateBase> onComplete)
        {
            base.OnEnter(onComplete);
            
            InitializeStateAsync();
        }

        public override void OnExit()
        {
            _metaFlowBuilder.Deinitialize();
            base.OnExit();
        }

        private async void InitializeStateAsync()
        {
            await SceneManager.LoadSceneAsync("Meta");
            
            _menuScreen = Object.FindAnyObjectByType<MenuScreen>(FindObjectsInactive.Include);
            _shopScreen = Object.FindAnyObjectByType<ShopScreen>(FindObjectsInactive.Include);
            _battlePassScreen = Object.FindAnyObjectByType<BattlePassScreen>(FindObjectsInactive.Include);
            _metaFlowBuilder = new MetaFlowBuilder(this, _menuScreen, _shopScreen, _battlePassScreen);
            _metaFlowBuilder.Initialize();
        }
    }
}