using System;

namespace Snake.Model
{
    public sealed class SnakeCircles : ICounter
    {
        public event Action OnRemoved;
        public event Action<int> OnAdded;
        public event Action<int> OnChanged;

        public bool IsImmortal { get; private set; }
        public int Count { get; private set; }

        public void Add(int count)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            Count += count;
            OnAdded?.Invoke(count - 1);
            OnChanged?.Invoke(Count);
        }

        public void Remove(int count)
        {
            if (IsImmortal == false)
            {
                Count -= count;
                if (Count <= 0)
                {
                    Count = 0;
                    return;
                }

                OnRemoved?.Invoke();
                OnChanged?.Invoke(Count);
            }
        }

        public void SetIsImmortal(bool isImmortal) => IsImmortal = isImmortal;
    }
}
