using System;
using UnityEngine;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class BlockCollision : MonoBehaviour
    {
        public event Action OnCollided;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out SnakeCollision snake))
            {
                OnCollided?.Invoke();
            }
        }
    }
}
