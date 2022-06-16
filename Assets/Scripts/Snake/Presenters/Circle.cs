using UnityEngine;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer))]
    public sealed class Circle : MonoBehaviour
    {
        private CircleCollider2D _collider;

        public SpriteRenderer SpriteRenderer { get; private set; }

        private void Awake()
        {
            _collider = GetComponent<CircleCollider2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        public float GetRadius() => _collider.radius;
    }
}
