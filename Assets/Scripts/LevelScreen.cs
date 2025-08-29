using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Scripts
{
    public class LevelScreen : MonoBehaviour
    {
        [SerializeField] private Button _onExitButton;

        private Action _onExitButtonClicked;

        public void Initialize(Action onExitButtonClicked)
        {
            _onExitButtonClicked = onExitButtonClicked;
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            _onExitButton.onClick.AddListener(OnExitButtonClicked);
        }


        public void Deactivate()
        {
            gameObject.SetActive(false);
            _onExitButton.onClick.RemoveListener(OnExitButtonClicked);
        }

        private void OnExitButtonClicked()
        {
            _onExitButtonClicked();
        }
    }
}