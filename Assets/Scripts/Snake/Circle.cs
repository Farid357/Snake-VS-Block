using UnityEngine;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(CircleCollider2D))]
    public sealed class Circle : MonoBehaviour
    {
        private CircleCollider2D _collider;

        public void SetColliderFromGameObject() => _collider = GetComponent<CircleCollider2D>();

        public float GetRadius() => _collider.radius;
    }
}
