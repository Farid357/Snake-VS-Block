using Snake.Tools;
using Snake.Model;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Snake.GameLogic
{
    public sealed class BlockFactory : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private List<BlockContext> _contexts = new();
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _parent;
        [SerializeField] private BlockContextProvider _provider;
        private SnakeCircles _snakeCircles;
        private const int MaxCountInRaw = 4;
        private float _diameter;
        private readonly ObjectsPool<BlockContext> _pool = new();
        private readonly List<IDisposable> _disposables = new();
        private float _startPositionX;

        public void Init(SafeAreaBounds bounds, int startCount)
        {
            _diameter = _contexts[0].Diameter;
            _startPositionX = bounds.GetMinPositionXWithOffset() - _diameter * MaxCountInRaw;
            _spawnPoint.position = new Vector2(_startPositionX, _spawnPoint.position.y);

            for (int i = 0; i < _contexts.Count; i++)
            {
                _pool.Add(startCount, _contexts[i], _parent);
            }
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            var wait = new WaitForSeconds(_delay);

            while (true)
            {
                var nextPositionX = _startPositionX;

                for (int i = 0; i < MaxCountInRaw; i++)
                {
                    var generator = new RandomBlockGenerator(_contexts, _snakeCircles.Count, _snakeCircles);
                    IBlock randomBlock = generator.CreateBlock();
                    var prefabContext = _provider.Get(randomBlock);
                    var context = _pool.Get(prefabContext);
                    Debug.Log(prefabContext.name);
                    nextPositionX += _diameter;

                    context.gameObject.SetActive(true);
                    context.transform.position = new Vector2(nextPositionX, _spawnPoint.position.y);
                    IDisposable presenter = new BlockPresenter(_snakeCircles, randomBlock, context);
                    var blockLifeTime = new BlockLifeTime(15, context.View);
                    blockLifeTime.Enable();
                    _disposables.Add(presenter);
                }
                _spawnPoint.position = new Vector2(_startPositionX, _spawnPoint.position.y);
                yield return wait;
            }
        }
        [Zenject.Inject]
        public void Init(SnakeCircles snakeCircles) => _snakeCircles = snakeCircles;

        private void OnDisable() => _disposables.ForEach(d => d.Dispose());
    }
}