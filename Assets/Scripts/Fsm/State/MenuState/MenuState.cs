using System;
using Core.Fsm;

namespace Scenes.Scripts.Fsm.State.MenuState
{
    public class MenuState : StateBase
    {
        private readonly MenuScreen _menuScreen;
        private readonly Action _onLevelStartClicked;
        private readonly Action _onExit;

        public string TargetId { get; private set; }

        public override string Id => "MenuState";

        public MenuState(MenuScreen menuScreen, Action onLevelStartClicked)
        {
            _menuScreen = menuScreen;
            _onLevelStartClicked = onLevelStartClicked;
        }

        public override void OnEnter(Action<StateBase> onComplete)
        {
            base.OnEnter(onComplete);

            _menuScreen.Initialize(OnButtonClicked);
            _menuScreen.Activate();
        }

        public override void OnExit()
        {
            _menuScreen.Deactivate();
            base.OnExit();
        }

        private void OnButtonClicked(string targetId)
        {
            if (targetId == "Start")
            {
                _onLevelStartClicked();
                return;
            }

            TargetId = targetId;
            Finish();
        }
    }
}