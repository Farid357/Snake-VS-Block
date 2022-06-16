using System;

namespace Snake.Model
{
    public interface IAbility
    {
        public event Action<float> OnApplyed;
        public void Apply();
    }
}