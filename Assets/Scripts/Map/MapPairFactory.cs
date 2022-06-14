using Snake.Tools;
using Snake.Model;
using UnityEngine;
using Zenject;
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

        [Inject]
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

                foreach (var context in pair.Contexts)
                {
                    var block = _provider.GetBlock(context.Type, context.Health, context.AbilitySeconds);
                    IDisposable presenter = new BlockPresenter(_snakeCircles, block, context.View, context.Collision);
                    _disposables.Add(presenter);
                }

                yield return wait;
            }
        }

        public void Dispose() => _disposables.ForEach(d => d.Dispose());
    }
}