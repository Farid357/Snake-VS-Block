using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class SnakeCirclesMovement : IUpdatable
    {
        private readonly List<Transform> _circles;
        private readonly List<Vector3> _positions;
        private readonly float _circleDiameter;
        private readonly SnakeHead _head;

        public SnakeCirclesMovement(List<Transform> circles, List<Vector3> positions, float circleDiameter, SnakeHead head)
        {
            _circles = circles ?? throw new System.ArgumentNullException(nameof(circles));
            _positions = positions ?? throw new System.ArgumentNullException(nameof(positions));
            _circleDiameter = circleDiameter;
            _head = head ?? throw new System.ArgumentNullException(nameof(head));
        }

        public void Update(float deltaTime)
        {
            float distance = 0;
            if (_head != null)
                distance = (_head.transform.position - _positions[0]).magnitude;

            if (distance > _circleDiameter)
            {
                var direction = (_head.transform.position - _positions[0]).normalized;
                _positions.Insert(0, _positions[0] + (direction * _circleDiameter));
                _positions.RemoveAt(_positions.Count - 1);
                distance -= _circleDiameter;
            }

            for (int i = 0; i < _circles.Count; i++)
            {
                var next = i + 1;
                _circles[i].position = Vector2.Lerp(_positions[next], _positions[i], distance / _circleDiameter);
            }
        }
    }
}
