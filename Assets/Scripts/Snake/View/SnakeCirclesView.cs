using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class SnakeCirclesView : MonoBehaviour
    {
        public readonly List<Circle> Circles = new();
        public readonly List<Vector3> Positions = new();

        [SerializeField] private Gradient _gradient;
        [SerializeField] private TMP_Text _text;
        private EndGameWindowView _endGameWindow;
        private ExclamationPointAnimation _animation;
        private Circle _prefab;
        private readonly List<Sequence> _sequences = new();

        public float CircleDiameter { get; private set; }
        public SnakeHead Head { get; private set; }

        public void Init(SnakeHead head, Circle prefab, EndGameWindowView endGameWindow, ExclamationPointAnimation animation)
        {
            _prefab = prefab;
            _animation = animation ?? throw new System.ArgumentNullException(nameof(animation));
            Head = head ?? throw new System.ArgumentNullException(nameof(head));
            Positions.Add(head.transform.position);
            CircleDiameter = prefab.GetRadius();
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
            }
        }

        public void Display(int count)
        {
            _text.text = count.ToString();
            _animation.TryPlay(count);
        }

        public void RemoveLast()
        {
            if (Circles.Count <= 0)
            {
                Destroy(Head.gameObject);
                return;
            }

            Destroy(Circles[0].gameObject);
            //Head.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            Circles.RemoveAt(0);
            Positions.RemoveAt(0);
        }

        public void MakeImmortal()
        {
            for (int i = 0; i < Circles.Count; i++)
            {
                _sequences.Add(Circles[i].SpriteRenderer.DOGradientColor(_gradient, 5));
            }
        }

        public void UnMakeImmortal()
        {
            Debug.Log("Unmake");
            Circles.ForEach(x => x.SpriteRenderer.DOColor(Color.white, 0.2f));
            _sequences.ForEach(s => s.Kill());
        }

        public void Die() => _endGameWindow.Show();
    }
}
