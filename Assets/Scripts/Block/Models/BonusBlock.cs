using System;

namespace Snake.Model
{
    public sealed class BonusBlock : BlockHealth
    {
        private readonly IAbility _ability;

        public BonusBlock(IAbility ability, int health) : base(health) 
        {
            _ability = ability ?? throw new ArgumentNullException(nameof(ability));
        }

        protected override void PlayEndFeedback() => _ability.Apply();
    }
}
