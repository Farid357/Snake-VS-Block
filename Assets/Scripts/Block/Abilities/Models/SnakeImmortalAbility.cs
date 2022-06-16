using System;
using System.Threading.Tasks;

namespace Snake.Model
{
    public sealed class SnakeImmortalAbility : IAbility
    {
        public event Action<float> OnApplyed;
        private readonly SnakeCircles _snakeCircles;
        private float _seconds;
        private readonly float _upSeconds;

        public SnakeImmortalAbility(SnakeCircles snakeCircles, float seconds)
        {
            _upSeconds = seconds > 0 ? seconds : throw new ArgumentOutOfRangeException(nameof(seconds));
            _snakeCircles = snakeCircles ?? throw new ArgumentNullException(nameof(snakeCircles));
        }

        public async void Apply()
        {
            _seconds += _upSeconds;
            OnApplyed?.Invoke(_seconds);
            _snakeCircles.SetIsImmortal(true);
            await Task.Delay(TimeSpan.FromSeconds(_seconds));
            _snakeCircles.SetIsImmortal(false);
        }
    }
}
