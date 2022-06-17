using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Snake.GameLogic
{
    public sealed class SnakeHealthAbilityView : MonoBehaviour, IAbilityView
    {
        [SerializeField] private Image _heart;
        [SerializeField] private ParticleSystem _particle;

        public void Display(float seconds)
        {
            ResetAllValues();
            var tween = _heart.DOFillAmount(0, seconds);
            tween.OnComplete(new TweenCallback(() => _particle.Play()));
        }

        private void ResetAllValues() => _heart.fillAmount = 1;
    }
}
