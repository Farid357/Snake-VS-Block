using System;

namespace Snake.Model
{
    public interface IBlock
    {
        public void TakeDamage(in int damage);
        public void UpdateHealth();

        public event Action<int> OnChangedHealth;

        public event Action OnEndedHealth;
        public void Kill();
    }
}