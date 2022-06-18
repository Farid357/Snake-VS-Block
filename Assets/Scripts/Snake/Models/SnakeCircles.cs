using System;

namespace Snake.Model
{
    public sealed class SnakeCircles : ICounter
    {
        public event Action<int> OnRemoved;
        public event Action<int> OnAdded;
        public event Action<int> OnChanged;

        public int Count { get; private set; }

        public void Add(int count)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            Count += count;
            OnAdded?.Invoke(count);
            OnChanged?.Invoke(Count);
        }

        public void Remove(int count)
        {
            Count -= count;
            if (Count <= 0)
            {
                Count = 0;
                return;
            }

            OnRemoved?.Invoke(count);
            OnChanged?.Invoke(Count);
        }
    }
}
