using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Snake.Model
{
    public sealed class SnakeImmortalAbilityView : MonoBehaviour, IAbilityView
    {
        [SerializeField] private Image _timer;
        [SerializeField] private Image _scull;
        [SerializeField] private float _scaleCofficient = 0.4f;
        [SerializeField] private Sprite _openScull;

        private Sprite _closeScull;
        private Vector2 _startScale;

        private void Awake()
        {
            _startScale = _timer.transform.localScale;
            _closeScull = _scull.sprite;
        }

        public void Display(float seconds)
        {
            ResetAll();
            _timer.DOFillAmount(0, 5)
                 .OnComplete(new TweenCallback(() => _scull.sprite = _openScull)).
                 OnComplete(new TweenCallback(() => _scull.DOFade(0, 0.35f).SetDelay(0.2f)));
        }

        private void ResetAll()
        {
            _scull.sprite = _closeScull;
            _timer.fillAmount = 1;
            _scull.color = Color.white;
        }
    }
}
