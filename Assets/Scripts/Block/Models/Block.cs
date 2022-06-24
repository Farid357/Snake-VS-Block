using System;

namespace Snake.Model
{
    public class Block : IBlock
    {
        private int _health;

        public event Action<int> OnChangedHealth;
        public event Action OnEndedHealth;

        public Block(int health) => _health = health;

        public void UpdateHealth() => OnChangedHealth.Invoke(_health);

        public void TakeDamage(in int damage)
        {
            if (damage <= 0) throw new ArgumentOutOfRangeException(nameof(damage));
            _health -= damage;
            OnChangedHealth?.Invoke(_health);

            if (_health <= 0)
            {
                Kill();
            }
        }

        protected virtual void PlayEndFeedback()
        {

        }

        public void Kill()
        {
            _health = 0;
            OnEndedHealth?.Invoke();
            PlayEndFeedback();
        }
    }
}
