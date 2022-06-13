using Snake.GameLogic;
using Snake.Model;
using Snake.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Root
{
    public sealed class BlockRoot : MonoBehaviour
    {
        [SerializeField] private BlockFactory _factory;
        [SerializeField] private int _startSpawnCount = 8;
        [SerializeField] private FoodView _prefab;
        [SerializeField] private int _foodStartCount = 6;
        private IDisposable _foodFactory;

        public void Init(SafeAreaBounds bounds, SnakeCircles snakeCircles)
        {
            _factory.Init(bounds, _startSpawnCount);
            _foodFactory = new FoodFactory(_factory, snakeCircles, _prefab, _foodStartCount);
        }

        private void OnDisable() => _foodFactory.Dispose();
    }
}
