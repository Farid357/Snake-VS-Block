using System;

namespace Snake.Model
{
    public interface IAbility
    {
        public event Action<float> OnApplyed;
        public void Apply();

        public bool IsApplyed { get; }
        public void TakeBlockHealth(IBlock block, in int damage);
    }
}