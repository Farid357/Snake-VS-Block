using System;

namespace Snake.GameLogic
{
    public sealed class SnakeCircles
    {
        public event Action OnEnded;
        public event Action<int> OnAdded;
        public event Action OnRemoved;
        public event Action<int> OnChanged;
        private int _count;

        public void Add(int count)
        {
            Validate(count);
            _count += count;
            OnAdded?.Invoke(count);
            OnChanged?.Invoke(_count);
        }

        public void RemoveOne()
        {
            _count -= 1;
            Validate(_count);
            if (_count == 0)
            {
                OnEnded?.Invoke();
                return;
            }
            OnRemoved?.Invoke();
            OnChanged?.Invoke(_count);
        }

        private void Validate(int count)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
        }
    }
}
