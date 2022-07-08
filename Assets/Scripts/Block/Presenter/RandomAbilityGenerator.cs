using System;

namespace Snake.Model
{
    public sealed class RandomAbilityGenerator
    {
        public IAbility GetRandom(params IAbility[] abilities)
        {
            var randomIndex = new Random().Next(0, abilities.Length);
            return abilities[randomIndex];
        }
    }
}
