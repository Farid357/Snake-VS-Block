using Snake.Tools;
using Snake.Model;
using UnityEngine;
using Zenject;

namespace Snake.GameLogic
{
    public sealed class BlockFactory : Factory<BlockContext>
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private BlockContextProvider _provider;

        private SnakeCircles _snakeCircles;
        private RandomBlockGenerator _generator;
        private float _diameter;
        private const int MaxCountInRaw = 4;
        private float _startPositionX;
        private float _nextPositionX;

        public void Init(SafeAreaBounds bounds, float diameter)
        {
            _diameter = diameter;
            _startPositionX = bounds.GetMinPositionXWithOffset() - (_diameter * MaxCountInRaw);
            _generator = new RandomBlockGenerator(Prefabs, _snakeCircles);
            ResetValues();
        }

        protected override void TrySpawn(out IDisposable presenter)
        {
            var randomBlock = _generator.CreateBlock();
            var prefabContext = _provider.Get(randomBlock);
            var context = Pool.Get(prefabContext);
            _nextPositionX += _diameter;

            context.gameObject.SetActive(true);
            context.transform.position = new Vector2(_nextPositionX, _spawnPoint.position.y);
            presenter = new BlockPresenter(_snakeCircles, randomBlock, context);
            var blockLifeTime = new BlockLifeTime(15, context.View);
            blockLifeTime.Enable();
        }

        protected override void ResetFactory() => ResetValues();

        private void ResetValues()
        {
            _spawnPoint.position = new Vector2(_startPositionX, _spawnPoint.position.y);
            _nextPositionX = _startPositionX;
        }

        [Inject]
        public void Constructor(SnakeCircles snakeCircles) => _snakeCircles = snakeCircles;
    }
}