using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.LoadSystem
{
    public sealed class ScreenFade : MonoBehaviour
    {
        public event Action OnDarkened;
        [SerializeField] private Image _screen;
        private WaitForSeconds _delay = new(0.05f);
        private bool _isDarkened;

        private void Start() => DontDestroyOnLoad(gameObject);

        public void StartFade() => StartCoroutine(Fade());

        public void StartFadeOut() => StartCoroutine(FadeOut());

        private IEnumerator Fade()
        {
            while (!_isDarkened)
            {
                for (float t = 0.05f; t <= 1; t += 0.05f)
                {
                    SetColor(t);
                    yield return _delay;
                }
                _isDarkened = true;
                OnDarkened?.Invoke();
            }
        }

        private IEnumerator FadeOut()
        {
            while (_isDarkened)
            {
                for (float t = 1; t >= 0; t -= 0.05f)
                {
                    SetColor(t);
                    yield return _delay;
                }
                _isDarkened = false;
            }
        }

        private void SetColor(float t)
        {
            Color color = _screen.color;
            color.a = t;
            _screen.color = color;
        }
    }
}
