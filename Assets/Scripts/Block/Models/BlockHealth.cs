using Snake.GameLogic;
using System;

namespace Snake.Model
{
    [Serializable]
    public class BlockHealth : IBlock
    {
        private int _health;

        public event Action<int> OnChanged;
        public event Action OnEnded;

        public BlockHealth(int health) => _health = health;

        public void UpdateHealth() => OnChanged.Invoke(_health);

        public void TakeDamage(in int damage)
        {
            if (damage <= 0) throw new ArgumentOutOfRangeException(nameof(damage));
            _health -= damage;
            OnChanged?.Invoke(_health);

            if (_health <= 0)
            {
                OnEnded?.Invoke();
                PlayEndFeedback();
            }
        }

        protected virtual void PlayEndFeedback()
        {

        }
    }
}
