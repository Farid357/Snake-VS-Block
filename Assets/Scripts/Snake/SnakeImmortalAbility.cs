using System;

namespace Snake.Model
{
    public sealed class SnakeImmortalAbility : IAbility
    {
        private readonly SnakeCircles _snakeCircles;

        public SnakeImmortalAbility(SnakeCircles snakeCircles)
        {
            _snakeCircles = snakeCircles ?? throw new ArgumentNullException(nameof(snakeCircles));
        }

        public void Apply() => _snakeCircles.MakeImmortal();
    }
}
