using UnityEngine;

namespace Snake.Tools
{
    [RequireComponent(typeof(Camera))]
    public sealed class CameraFollowing : MonoBehaviour
    {
        [SerializeField] private Transform _snake;

        private void LateUpdate() => Follow();

        private void Follow()
        {
            transform.position = new Vector3(transform.position.x, _snake.position.y, transform.position.z);
        }
    }
}
