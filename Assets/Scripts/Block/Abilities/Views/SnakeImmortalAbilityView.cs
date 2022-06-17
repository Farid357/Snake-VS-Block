using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Snake.GameLogic
{
    public sealed class SnakeImmortalAbilityView : MonoBehaviour, IAbilityView
    {
        [SerializeField] private Image _timer;
        [SerializeField] private Image _scull;
        [SerializeField] private Sprite _openScull;
        [SerializeField] private SnakeCirclesView _circlesView;
        [SerializeField] private SnakeCirclesImmortalView _immortalView;

        private Sequence _sequence;
        private Sprite _closeScull;

        private void Awake() => _closeScull = _scull.sprite;

        public void Display(float seconds)
        {
            _sequence = DOTween.Sequence();
            _immortalView.SetIsImmortal(true);
            _immortalView.StartUpdateCirclesColor(_circlesView.Circles);
            ResetAllValues();
            _sequence.Append(_timer.DOFillAmount(0, seconds));
            _sequence.AppendCallback(new TweenCallback(() => _scull.sprite = _openScull));
            _sequence.AppendInterval(0.2f);
            _sequence.Append(_scull.DOFade(0, 0.35f).SetDelay(0.2f));
            _sequence.AppendCallback(new TweenCallback(() => _immortalView.SetIsImmortal(false)));
        }

        private void ResetAllValues()
        {
            _scull.sprite = _closeScull;
            _timer.fillAmount = 1;
            _scull.color = Color.white;
        }
    }
}
