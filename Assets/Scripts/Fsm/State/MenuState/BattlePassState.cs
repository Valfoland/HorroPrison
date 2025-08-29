using System;
using Core.Fsm;

namespace Scenes.Scripts.Fsm.State.MenuState
{
    public class BattlePassState : StateBase
    {
        private readonly BattlePassScreen _battlePassScreen;

        public BattlePassState(BattlePassScreen battlePassScreen)
        {
            _battlePassScreen = battlePassScreen;
        }

        public override string Id => "BattlePassState";

        public override void OnEnter(Action<StateBase> onComplete)
        {
            base.OnEnter(onComplete);
            _battlePassScreen.Initialize(OnExitButtonClicked);
            _battlePassScreen.Activate();
        }


        public override void OnExit()
        {
            base.OnExit();
            _battlePassScreen.Deactivate();
        }

        private void OnExitButtonClicked()
        {
            Finish();
        }
    }
}