using UnityEngine;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(CircleCollider2D))]
    public sealed class SnakeCollision : MonoBehaviour
    {
        [SerializeField] private SnakeHead _head;

        private void Update()
        {
            transform.position = _head.transform.position;
        }
    }
}
