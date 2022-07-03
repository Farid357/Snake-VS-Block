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
        [SerializeField] private AbilityViewProvider _abilityViewProvider;
        [SerializeField] private float _yOffset = 4f;
        [SerializeField] private ScoreView _scoreView;
        private readonly List<IDisposable> _disposables = new();
        private RandomMapPairGenerator _generator;
        private BlockProvider _provider;
        private ObjectsPool<MapPair> _pool;
        private SnakeCircles _snakeCircles;
        private readonly FoodFactory _foodFactory = new();
        private BlockFactory _blockFactory;

        [Zenject.Inject]
        public void Constructor(ObjectsPool<MapPair> pool) => _pool = pool;

        public void Init(int startCount, Transform parent, SnakeCircles snakeCircles, Score score)
        {
            _blockFactory = new(_scoreView, score);
            _provider = new(snakeCircles, _pairs[0].BlockContexts[0].AbilitySeconds);
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

                foreach (var block in pair.BlockContexts)
                {
                    var disposables = _blockFactory.Spawn(_provider, block, _snakeCircles, _abilityViewProvider);
                    _disposables.Add(_blockFactory);
                    _disposables.Add(disposables.Item1);
                    _disposables.Add(disposables.Item2);
                }

                foreach (var food in pair.FoodContexts)
                {
                    _disposables.Add(_foodFactory.Spawn(food, _snakeCircles));
                }
                _spawnPoint.position = new Vector2(_spawnPoint.position.x, _spawnPoint.position.y + _yOffset);
                yield return wait;
            }
        }

        public void Dispose() => _disposables.ForEach(d => d.Dispose());
    }
}