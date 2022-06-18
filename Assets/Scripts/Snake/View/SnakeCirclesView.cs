using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class SnakeCirclesView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private readonly List<Circle> _circles = new();
        private readonly List<Vector3> _positions = new();
        private EndGameWindowView _endGameWindow;
        private ExclamationPointAnimation _animation;
        private Circle _prefab;

        public IList<Vector3> Positions => _positions;
        public IList<Circle> Circles => _circles;

        public float CircleDiameter { get; private set; }
        public SnakeHead Head { get; private set; }

        public void Init(SnakeHead head, Circle prefab, EndGameWindowView endGameWindow, ExclamationPointAnimation animation)
        {
            _prefab = prefab;
            _animation = animation ?? throw new System.ArgumentNullException(nameof(animation));
            Head = head ?? throw new System.ArgumentNullException(nameof(head));
            _positions.Add(head.transform.position);
            CircleDiameter = prefab.GetDiameter();
            _endGameWindow = endGameWindow ?? throw new System.ArgumentNullException(nameof(endGameWindow));
        }

        public void Add(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var lastCirclePosition = _positions[^1];
                var circle = Instantiate(_prefab, lastCirclePosition, Quaternion.identity);
                _circles.Add(circle);
                _positions.Add(circle.transform.position);
            }
        }

        public void Display(int count)
        {
            _text.text = System.Convert.ToString(count + 1);
            _animation.TryPlay(count);
        }

        public void Remove(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (_circles.Count <= 2)
                {
                    Die();
                    Destroy(_circles[0].gameObject);
                    Destroy(Head.gameObject);
                    return;
                }

                Destroy(_circles[0].gameObject);
                _circles.RemoveAt(0);
                _positions.RemoveAt(0);
            }
        }

        public void Die() => _endGameWindow.Show();
    }
}
