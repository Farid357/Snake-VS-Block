using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Snake.GameLogic
{
    public sealed class MapPair : MonoBehaviour
    {
        [SerializeField] private List<BlockContext> _blockContexts = new();
        [SerializeField] private float _distance = 10f;
        [SerializeField] private List<FoodContext> _foodContexts = new();
        private SnakeHead _head;

        [field: SerializeField] public AnimationCurve ChanceCurve { get; private set; }

        public IList<BlockContext> BlockContexts => _blockContexts;
        public IList<FoodContext> FoodContexts => _foodContexts;

        private void Update() => TryDisable();

        private void TryDisable()
        {
            if (isActiveAndEnabled)
            {
                var currentDistance = _head.transform.position.y - transform.position.y;
                if (currentDistance >= _distance)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        [Inject]
        public void Constructor(SnakeHead snakeHead) => _head = snakeHead;
    }
}
