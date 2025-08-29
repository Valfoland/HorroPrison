using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Scripts
{
    public class ShopScreen : MonoBehaviour
    {
        [SerializeField] private Button _menuButton;
        private Action _onButtonClicked;

        public void Initialize(Action onButtonClicked)
        {
            _onButtonClicked = onButtonClicked;
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            _menuButton.onClick.AddListener(OnMenuButtonClicked);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            _menuButton.onClick.RemoveListener(OnMenuButtonClicked);
        }

        private void OnMenuButtonClicked()
        {
            _onButtonClicked?.Invoke();
        }
    }
}