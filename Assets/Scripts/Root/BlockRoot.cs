using Snake.GameLogic;
using Snake.Model;
using Snake.Tools;
using UnityEngine;

namespace Snake.Root
{
    public sealed class BlockRoot : MonoBehaviour
    {
        [SerializeField] private MapPairFactory _factory;
        [SerializeField] private int _startSpawnCount = 4;

        public void Init(SnakeCircles snakeCircles, Score score)
        {
            _factory.Init(_startSpawnCount, transform, snakeCircles, score);
        }

        private void OnDestroy() => _factory.Dispose();
    }
}
