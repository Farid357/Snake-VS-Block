using System;
using UnityEngine;

namespace Snake.GameLogic
{
    [Serializable]
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class BlockCollision : MonoBehaviour
    {
        public event Action OnCollided;

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out SnakeHead snake))
            {
                OnCollided?.Invoke();
            }
        }
    }
}
