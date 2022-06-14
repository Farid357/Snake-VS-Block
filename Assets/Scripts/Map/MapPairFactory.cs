using Snake.Tools;
using Snake.Model;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Snake.GameLogic
{
    public sealed class MapPairFactory : MonoBehaviour, IDisposable
    {
        [SerializeField] private List<MapPair> _pairs = new();
        [SerializeField] private float _delay = 3.5f;
        [SerializeField] private Transform _spawnPoint;
        private readonly List<IDisposable> _disposables = new();
        private RandomMapPairGenerator _generator;
        private BlockProvider _provider;
        private ObjectsPool<MapPair> _pool;
        private SnakeCircles _snakeCircles;

        [Zenject.Inject]
        public void Constructor(ObjectsPool<MapPair> pool) => _pool = pool;

        public void Init(int startCount, Transform parent, SnakeCircles snakeCircles)
        {
            _provider = new(snakeCircles);
            _generator = new(_pairs, snakeCircles);
            _snakeCircles = snakeCircles ?? throw new System.ArgumentNullException(nameof(snakeCircles));

            for (int i = 0; i < _pairs.Count; i++)
            {
                _pool.Add(startCount, _pairs[i], parent);
            }

            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            var wait = new WaitForSeconds(_delay);

            while (true)
            {
                var randomPair = _generator.CreateRandomMapPair();
                var pair = _pool.Get(randomPair);
                pair.gameObject.SetActive(true);
                pair.transform.position = new Vector2(pair.transform.position.x, _spawnPoint.position.y);
                pair.Enable();

                foreach (var block in pair.BlockContexts)
                {
                    var model = _provider.GetBlock(block.Type, block.Health, block.AbilitySeconds);
                    IDisposable presenter = new BlockPresenter(_snakeCircles, model, block.View, block.Collision);
                    _disposables.Add(presenter);
                    block.gameObject.SetActive(true);
                }

                foreach (var food in pair.FoodContexts)
                {
                    var model = new Food(food.Value);
                    IDisposable presenter = new FoodPresener(model, food.View, _snakeCircles);
                    _disposables.Add(presenter);
                    food.gameObject.SetActive(true);
                }

                yield return wait;
            }
        }

        public void Dispose() => _disposables.ForEach(d => d.Dispose());
    }
}