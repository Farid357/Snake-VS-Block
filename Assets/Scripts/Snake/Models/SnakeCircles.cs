using System;
using UnityEngine;

namespace Snake.Model
{
    public sealed class SnakeCircles : ICounter
    {
        private bool _isImmortal;

        public event Action OnRemoved;
        public event Action<int> OnAdded;
        public event Action<int> OnChanged;

        public int Count { get; private set; }

        public void Add(int count)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            Count += count;
            Debug.Log(Count);
            OnAdded?.Invoke(count);
            OnChanged?.Invoke(Count);
        }

        public void Remove(int count)
        {
            if (_isImmortal == false)
            {
                Count -= count;
                if (Count <= 0)
                {
                    Count = 0;
                    return;
                }
                Debug.Log(Count);

                OnRemoved?.Invoke();
                OnChanged?.Invoke(Count);
            }
        }

        public void SetIsImmortal(bool isImmortal) => _isImmortal = isImmortal;
    }
}
