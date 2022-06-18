using System;

namespace Snake.Model
{
    public sealed class AbilityProvider
    {
        private IAbility _ability;

        public void SetAbility(IAbility ability)
        {
            _ability = ability ?? throw new ArgumentNullException(nameof(ability));
        }

        public bool TryGetAbility(out IAbility ability)
        {
            if (_ability != null)
            {
                ability = _ability;
                return true;
            }

            ability = null;
            return false;
        }
    }
}
