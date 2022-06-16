using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Snake.Model
{
    public sealed class SnakeImmortalAbilityView : MonoBehaviour, IAbilityView
    {
        [SerializeField] private Image _timer;
        [SerializeField] private Image _scull;
        [SerializeField] private float _scaleCofficient = 1.2f;
        [SerializeField] private Sprite _openScull;

        private Sprite _closeScull;
        private Vector2 _startScale;
        private bool _isEnded;

        public void Display(float seconds)
        {
            TryResetAll();
            var tween = _timer.DOFillAmount(0, seconds);
            tween.OnComplete(new TweenCallback(() => IcreaseScale(_scaleCofficient)));
        }

        private void TryResetAll()
        {
            _scull.sprite = _closeScull != null ? _closeScull : _scull.sprite;
            _timer.fillAmount = 1;
            _scull.color = Color.white;
            _scull.transform.localScale = _startScale != default ? _startScale : _scull.transform.localScale;
            _timer.gameObject.SetActive(true);
        }

        private void IcreaseScale(float cofficient)
        {

            var tween = _scull.transform.DOScale(cofficient, 0.2f);
            tween.OnComplete(new TweenCallback(() => MakeClear(_scull)));
        }

        private void MakeClear(Image scull)
        {
            _closeScull = scull.sprite;
            scull.sprite = _openScull;
            scull.DOColor(Color.clear, 0.2f);
            _isEnded = true;
        }
    }
}
