﻿using System;
using UnityEngine;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class BlockCollision : MonoBehaviour
    {
        [SerializeField, Min(0.001f)] private float _maxDelay = 0.02f;
        private bool _isInCollision;
        private float _delay;
        private Action _onCollided;

        public event Action OnCollided { add => _onCollided ??= value; remove => _onCollided -= value; }

        private void OnCollisionEnter2D(Collision2D collision) => TrySetInCollision(collision, true);

        private void OnCollisionExit2D(Collision2D collision) => TrySetInCollision(collision, false);

        private void TrySetInCollision(Collision2D collision, bool isInCollision)
        {
            if (collision.collider.TryGetComponent<SnakeHead>(out _))
            {
                _isInCollision = isInCollision;
            }
        }

        private void Update()
        {
            if (_isInCollision)
            {
                _delay += Time.deltaTime;

                if (_delay >= _maxDelay)
                {
                    _delay = 0;
                    _onCollided.Invoke();
                }
            }
        }
    }
}
