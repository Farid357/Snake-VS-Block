﻿using System;
using System.Threading.Tasks;

namespace Snake.Model
{
    public sealed class SnakeCircles
    {
        private bool _isImmortal;

        public event Action OnEnded;
        public event Action OnRemoved;
        public event Action<int> OnAdded;

        public int Count { get; private set; } = 1;

        public void Add(int count)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            Count += count;
            OnAdded.Invoke(count);
        }

        public void Remove(int count)
        {
            if (_isImmortal == false)
            {
                Count -= count;
                if (Count == 0)
                {
                    return;
                }

                OnRemoved?.Invoke();
            }
        }

        public async void MakeImmortalForSeconds(float seconds)
        {
            _isImmortal = true;
            await Task.Delay(TimeSpan.FromSeconds(seconds));
            _isImmortal = false;
        }
    }
}