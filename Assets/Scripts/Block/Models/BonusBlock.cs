using System;

namespace Snake.Model
{
    public sealed class BonusBlock : Block
    {
        public readonly IAbility Ability;

        public BonusBlock(IAbility ability, int health, AbilityProvider provider) : base(health)
        {
            Ability = ability ?? throw new ArgumentNullException(nameof(ability));
            provider.SetAbility(ability);
        }

        protected override void PlayEndFeedback()
        {
            Ability.Apply();
        }
    }
}
