using System;
using System.Threading.Tasks;

namespace Snake.Model
{
    public class Ability : IAbility
    {
        public event Action<float> OnApplyed;
        private readonly float _seconds;


        public Ability(float seconds)
        {
            _seconds = seconds > 0 ? seconds : throw new ArgumentOutOfRangeException(nameof(seconds));
        }

        public bool IsApplyed { get; private set; }

        public async void Apply()
        {
            IsApplyed = true;
            OnApplyed?.Invoke(_seconds);
            await Task.Delay(TimeSpan.FromSeconds(_seconds));
            IsApplyed = false;
        }
    }
}
