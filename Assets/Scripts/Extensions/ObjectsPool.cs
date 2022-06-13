using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Snake.Tools
{
    public sealed class ObjectsPool<T> where T : MonoBehaviour
    {
        private readonly List<T> _objects = new();
        private int _count;
        private DiContainer _container;

        [Inject]
        public void Init(DiContainer container) => _container = container;

        public void Add(int count, T prefab, Transform parent = null)
        {
            if (!_objects.Contains(prefab))
            {
                _count = count;
                for (int i = 0; i < count; i++)
                {
                    if (_container == null) Debug.Log("null");
                    var createObject = parent != null ? _container.InstantiatePrefab(prefab) : _container.InstantiatePrefab(prefab, parent);

                    //var createObject = Object.Instantiate(prefab, parent);
                    createObject.gameObject.SetActive(false);
                    _objects.Add(createObject.GetComponent<T>());
                }
            }
        }

        private int GetIndex(T prefab)
        {
            for (int i = 0; i < _objects.Count - 1; i++)
            {
                if (!_objects[i].gameObject.activeInHierarchy)
                {
                    return i;
                }
            }
            return 0;
        }
        public T Get(T prefab)
        {
            if (HaveObjects(_objects))
            {
                int index = GetIndex(prefab);
                return _objects[index];
            }
            else
            {
                Add(_count, prefab);
                return _objects[GetIndex(prefab)];
            }
        }

        private bool HaveObjects(List<T> objects)
        {
            for (int i = 0; i < objects.Count - 1; i++)
            {
                if (!objects[i].gameObject.activeInHierarchy)
                    return true;
            }
            return false;
        }
    }
}