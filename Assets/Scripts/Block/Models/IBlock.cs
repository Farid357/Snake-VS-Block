using System;

namespace Snake.GameLogic
{
    public interface IBlock
    {
        public void TakeDamage(in int damage);
        public void UpdateHealth();

        public event Action<int> OnChanged;

        public event Action OnEnded;
    }
}