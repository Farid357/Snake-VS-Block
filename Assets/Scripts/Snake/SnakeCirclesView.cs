using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class SnakeCirclesView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private List<Transform> _circles = new();
        private List<Vector3> _positions = new();
        private SnakeHead _head;
        private float _circleDiameter;

        public void Init(SnakeHead head, Circle prefab)
        {
            _head = head;
            _positions.Add(head.transform.position);
            _circleDiameter = prefab.GetRadius();
        }

        private void Update()
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

        public void Add(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var lastCirclePosition = _positions[_positions.Count - 1];
                var circle = Instantiate(_head.transform, lastCirclePosition, Quaternion.identity);
                _circles.Add(circle);
                _positions.Add(circle.position);
                
            }
        }

        public void UpdateText(int count) => _text.text = count.ToString();

        public void RemoveLast()
        {
            if (_circles.Count - 1 < 0)
            {
                Destroy(_head.gameObject);
                return;
            }

            Destroy(_circles[^1].gameObject);
            _circles.RemoveAt(_circles.Count - 1);
            _positions.RemoveAt(_positions.Count - 1);
        }
    }
}
