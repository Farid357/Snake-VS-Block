using Snake.Tools;
using Snake.Model;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace Snake.GameLogic
{
    public sealed class FoodFactory : IDisposable
    {
        private readonly Vector2 _offset = new(-5, -2f);
        private readonly ObjectsPool<FoodView> _pool = new();
        private readonly SnakeCircles _snakeCircles;
        private readonly FoodView _prefab;
        private readonly List<IDisposable> _disposables = new();
        private readonly BlockFactory _blockFactory;

        public FoodFactory(BlockFactory blockFactory, SnakeCircles snakeCircles, FoodView prefab, int startCount)
        {
            _blockFactory = blockFactory ?? throw new ArgumentNullException(nameof(blockFactory));
            _snakeCircles = snakeCircles ?? throw new ArgumentNullException(nameof(snakeCircles));
            _prefab = prefab ?? throw new ArgumentNullException(nameof(prefab));
            _pool.Add(startCount, prefab);
            _blockFactory.OnSpawned += TrySpawn;
        }

        public void Dispose()
        {
            _disposables.ForEach(d => d.Dispose());
            _blockFactory.OnSpawned -= TrySpawn;
        }

        public void TrySpawn(Vector2 point)
        {
            var random = new System.Random();
            var randomValue = random.Next(0, 6);
            const int doubleFood = 2;

            if (randomValue == doubleFood)
            {
                Spawn(doubleFood, point);
            }

            else if (randomValue == 5 || randomValue == 4)
            {
                Spawn(1, point);
            }
        }

        private void Spawn(int count, Vector2 point)
        {
            for (int i = 0; i < count; i++)
            {
                point += _offset;
                var view = _pool.Get(_prefab);
                view.gameObject.SetActive(true);
                view.transform.position = point;
                var model = new Food(new System.Random().Next(1, 5));
                IDisposable presenter = new FoodPresener(model, view, _snakeCircles);
                _disposables.Add(presenter);
            }
        }
    }
}