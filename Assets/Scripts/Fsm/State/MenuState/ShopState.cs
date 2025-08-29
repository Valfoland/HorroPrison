using System;
using Core.Fsm;

namespace Scenes.Scripts.Fsm.State.MenuState
{
    public class ShopState : StateBase
    {
        private readonly ShopScreen _shopScreen;
        public override string Id => "ShopState";

        public ShopState(ShopScreen shopScreen)
        {
            _shopScreen = shopScreen;
        }

        public override void OnEnter(Action<StateBase> onComplete)
        {
            base.OnEnter(onComplete);
            _shopScreen.Initialize(OnExitButtonClicked);
            _shopScreen.Activate();
        }


        public override void OnExit()
        {
            _shopScreen.Deactivate();
            base.OnExit();
        }

        private void OnExitButtonClicked()
        {
            Finish();
        }
    }
}