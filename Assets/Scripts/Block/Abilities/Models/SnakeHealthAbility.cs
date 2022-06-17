using System;
using System.Threading.Tasks;

namespace Snake.Model
{
    public sealed class SnakeHealthAbility : IAbility
    {
        public event Action<float> OnApplyed;
        private readonly float _seconds;
        private readonly SnakeCircles _snakeCircles;

        public bool IsApplyed { get; private set; }


        public SnakeHealthAbility(SnakeCircles snakeCircles, float seconds)
        {
            _snakeCircles = snakeCircles ?? throw new ArgumentNullException(nameof(snakeCircles));
            _seconds = seconds  > 0 ? seconds : throw new ArgumentOutOfRangeException(nameof(seconds));
        }

        public async void Apply()
        {
            OnApplyed?.Invoke(_seconds);
            IsApplyed = true;
            await Task.Delay(TimeSpan.FromSeconds(_seconds));
            IsApplyed = false;
        }

        public void TakeBlockHealth(IBlock block, in int damage)
        {
            _snakeCircles.Add(damage);
            block.TakeDamage(damage);
        }
    }
}
