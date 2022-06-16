using UnityEngine;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer))]
    public sealed class Circle : MonoBehaviour
    {
        private CircleCollider2D _collider;

        public SpriteRenderer SpriteRenderer { get; private set; }

        public void Enable()
        {
            _collider = GetComponent<CircleCollider2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        public float GetDiameter() => _collider.radius;
    }
}
