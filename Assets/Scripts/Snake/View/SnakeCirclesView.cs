using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class SnakeCirclesView : MonoBehaviour
    {
        public readonly List<Circle> Circles = new();
        public readonly List<Vector3> Positions = new();

        [SerializeField] private TMP_Text _text;
        private EndGameWindowView _endGameWindow;
        private ExclamationPointAnimation _animation;
        private Circle _prefab;

        [field: SerializeField] public SnakeCirclesImmortalView ImmortalView { get; private set; }
        public float CircleDiameter { get; private set; }
        public SnakeHead Head { get; private set; }

        public void Init(SnakeHead head, Circle prefab, EndGameWindowView endGameWindow, ExclamationPointAnimation animation)
        {
            _prefab = prefab;
            _animation = animation ?? throw new System.ArgumentNullException(nameof(animation));
            Head = head ?? throw new System.ArgumentNullException(nameof(head));
            Positions.Add(head.transform.position);
            CircleDiameter = prefab.GetDiameter();
            _endGameWindow = endGameWindow ?? throw new System.ArgumentNullException(nameof(endGameWindow));
        }

        public void Add(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var lastCirclePosition = Positions[^1];
                var circle = Instantiate(_prefab, lastCirclePosition, Quaternion.identity);
                Circles.Add(circle);
                Positions.Add(circle.transform.position);
                ImmortalView.UpdateCirclesColor(Circles);
            }
        }

        public void Display(int count)
        {
            _text.text = count.ToString();
            _animation.TryPlay(count);
            ImmortalView.UpdateCirclesColor(Circles);
        }

        public void RemoveLast()
        {
            if (Circles.Count <= 0)
            {
                Die();
                Destroy(Head.gameObject);
                return;
            }

            Destroy(Circles[0].gameObject);
            Circles.RemoveAt(0);
            Positions.RemoveAt(0);
            ImmortalView.UpdateCirclesColor(Circles);
        }

        public void Die() => _endGameWindow.Show();
    }
}
