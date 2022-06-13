using Snake.GameLogic;
using Snake.Model;
using Snake.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Root
{
    public sealed class BlockRoot : MonoBehaviour, IDisposableDestroyer
    {
        [SerializeField] private BlockFactory _factory;
        [SerializeField] private int _startSpawnCount = 8;
        [SerializeField] private BlockContext _context;
        private List<IDisposable> _disposables;

        public void Init(SafeAreaBounds bounds, SnakeCircles snakeCircles)
        {
            _factory.Init(bounds, _context.Diameter);
            _factory.Enable(_startSpawnCount);
        }

        public void SetDisposables(List<IDisposable> disposables) => _disposables = disposables;

        private void OnDestroy()
        {
            _disposables.ForEach(d => d.Dispose());
        }
    }
    public interface IDisposableDestroyer
    {
        public void SetDisposables(List<IDisposable> disposables);
    }
}
