using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Scripts
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _shopButton;
        [SerializeField] private Button _battlePassButton;
        [SerializeField] private Button _startButton;

        private Action<string> _onButtonClicked;
        
        public void Initialize(Action<string> onButtonClicked)
        {
            _onButtonClicked = onButtonClicked;
        }
        
        public void Activate()
        {
            gameObject.SetActive(true);
            _shopButton.onClick.AddListener(OnShopButtonClicked);
            _battlePassButton.onClick.AddListener(OnBattlePassButtonClicked);
            _startButton.onClick.AddListener(OnStartButtonClicked);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            _shopButton.onClick.RemoveListener(OnShopButtonClicked);
            _battlePassButton.onClick.RemoveListener(OnBattlePassButtonClicked);
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
        }

        private void OnShopButtonClicked()
        {
            _onButtonClicked?.Invoke("Shop");
        }

        private void OnBattlePassButtonClicked()
        {
            _onButtonClicked?.Invoke("BattlePass");
        }
        
        private void OnStartButtonClicked()
        {
            _onButtonClicked?.Invoke("Start");
        }
    }
}
