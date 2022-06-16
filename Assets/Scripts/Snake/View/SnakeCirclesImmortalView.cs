using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class SnakeCirclesImmortalView : MonoBehaviour
    {
        [SerializeField] private Gradient _gradient;
        private bool _isImmortal;

        public void UpdateCirclesColor(List<Circle> circles)
        {
            if (_isImmortal)
            {
                for (int i = 0; i < circles.Count; i++)
                {
                    if (circles[i].SpriteRenderer == null)
                        circles[i].Enable();
                    circles[i].SpriteRenderer.DOGradientColor(_gradient, 1.5f).SetLoops(2, LoopType.Yoyo);
                }
            }

            else
            {
                if (circles[0].SpriteRenderer != null)
                {
                    circles.ForEach(c => c.SpriteRenderer.DOColor(Color.white, 0.2f));
                }
            }
        }

        public void MakeImmortal() => _isImmortal = true;

        public void UnMakeImmortal() => _isImmortal = false;
    }
}
