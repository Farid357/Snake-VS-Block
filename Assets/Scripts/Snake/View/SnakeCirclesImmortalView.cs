using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class SnakeCirclesImmortalView : MonoBehaviour
    {
        [SerializeField] private Gradient _gradient;
        private float _delay = 1.5f;
        private bool _isImmortal;

        public void StartUpdateCirclesColor(IList<Circle> circles) => StartCoroutine(UpdateCirclesColor(circles));

        private IEnumerator UpdateCirclesColor(IList<Circle> circles)
        {
            while (_isImmortal)
            {
                for (int i = 0; i < circles.Count; i++)
                {
                    if (circles[i].SpriteRenderer == null)
                        circles[i].Enable();
                    circles[i].SpriteRenderer.DOGradientColor(_gradient, _delay);
                }
                yield return new WaitForSeconds(_delay);
            }
            yield return null;
            EndEffect(circles);
        }

        public void EndEffect(IList<Circle> circles)
        {
            var circlesList = circles as List<Circle>;
            circlesList.ForEach(c => c.SpriteRenderer.DOColor(Color.white, 0.2f));
        }

        public void SetIsImmortal(bool isImmortal) => _isImmortal = isImmortal;
    }
}
