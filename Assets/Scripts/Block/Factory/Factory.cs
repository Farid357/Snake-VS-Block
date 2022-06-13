using Snake.Tools;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Zenject;

namespace Snake.GameLogic
{
    public abstract class Factory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private List<T> _prefabs = new();
        [SerializeField] private Transform _parent;
        private const int MaxCountInRaw = 4;
        private readonly List<IDisposable> _disposables = new();

        protected ObjectsPool<T> Pool { get; private set; }
        protected IEnumerable<T> Prefabs => _prefabs;

        public void Enable(int startCount)
        {
            for (int i = 0; i < _prefabs.Count; i++)
            {
                Pool.Add(startCount, _prefabs[i], _parent);
            }
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            var wait = new WaitForSeconds(_delay);

            while (true)
            {
                for (int i = 0; i < MaxCountInRaw; i++)
                {
                    TrySpawn(out var disposable);
                    _disposables.Add(disposable);
                }
                ResetFactory();
                yield return wait;
            }
        }

        [Inject]
        public void Constructor(ObjectsPool<T> pool) => Pool = pool;

        protected abstract void TrySpawn(out IDisposable presenter);

        protected abstract void ResetFactory();


        private void OnDisable() => _disposables.ForEach(d => d.Dispose());
    }
}