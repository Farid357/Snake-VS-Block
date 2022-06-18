using System;
using System.Collections;
using UnityEngine;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class BlockCollision : MonoBehaviour
    {
        private bool _isInCollision;
        private const float Delay = 0.1f;
        private Action _onCollided;

        public event Action OnCollided { add => _onCollided ??= value; remove => _onCollided -= value; }

        private void OnCollisionEnter2D(Collision2D collision) => TrySetIsInCollision(collision, true);

        private void OnCollisionExit2D(Collision2D collision) => TrySetIsInCollision(collision, false);

        private void TrySetIsInCollision(Collision2D collision, bool isInCollision)
        {
            if (collision.collider.TryGetComponent<SnakeHead>(out _))
            {
                _isInCollision = isInCollision;
            }

            StartCoroutine(OnCollidedTick(Delay));
        }

        private IEnumerator OnCollidedTick(float delay)
        {
            var wait = new WaitForSeconds(delay);
            while (_isInCollision && gameObject.activeInHierarchy)
            {
                yield return wait;
                _onCollided?.Invoke();
            }
        }
    }
}
