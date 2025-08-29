using System.Collections;
using TMPro;
using UnityEngine;

namespace Scenes.Scripts
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _loadingText;

        private readonly string _text = "LOADING";


        public void Activate()
        {
            gameObject.SetActive(true);
            _loadingText.text = _text;
            StartCoroutine(AnimateLoading());
        }

        public void Deactivate()
        {
            StopCoroutine(AnimateLoading());
            gameObject.SetActive(false);
        }

        private IEnumerator AnimateLoading()
        {
            var index = 0;
            while (true)
            {
                if (index >= 3)
                {
                    index = 0;
                    _loadingText.text = _text;
                    yield return new WaitForSeconds(0.5f);
                }

                _loadingText.text += ".";
                yield return new WaitForSeconds(0.5f);
                index++;
            }
        }
    }
}