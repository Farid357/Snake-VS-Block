using System;
using System.Threading.Tasks;

namespace Snake.Model
{
    public sealed class SnakeImmortalAbility : IAbility
    {
        private readonly SnakeCircles _snakeCircles;
        private readonly float _seconds;

        public SnakeImmortalAbility(SnakeCircles snakeCircles, float seconds)
        {
            _seconds = seconds > 0 ? seconds : throw new ArgumentOutOfRangeException(nameof(seconds));
            _snakeCircles = snakeCircles ?? throw new ArgumentNullException(nameof(snakeCircles));
        }

        public async void Apply()
        {
            _snakeCircles.SetIsImmortal(true);
            await Task.Delay(TimeSpan.FromSeconds(_seconds));
           _snakeCircles.SetIsImmortal(false);
        }
    }
}
