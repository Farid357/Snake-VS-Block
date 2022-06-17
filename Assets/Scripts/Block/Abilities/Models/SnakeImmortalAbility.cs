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

        public bool IsApplyed { get; private set; }

        public async void Apply()
        {
            _seconds += _upSeconds;
            SetIsApplyed(true);
            OnApplyed?.Invoke(_seconds);
            await Task.Delay(TimeSpan.FromSeconds(_seconds));
            SetIsApplyed(false);
        }

        private void SetIsApplyed(bool isApplyed)
        {
            IsApplyed = isApplyed;
            _snakeCircles.SetIsImmortal(IsApplyed);
        }

        public void TakeBlockHealth(IBlock block, in int damage) => block.Kill();
    }
}
