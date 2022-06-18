using Snake.Model;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class AbilityViewProvider : MonoBehaviour
    {
        [SerializeField] private SnakeImmortalAbilityView _immortalView;
        [SerializeField] private SnakeHealthAbilityView _healthView;

        public IAbilityView Get(IAbility ability)
        {
            if (ability is SnakeImmortalAbility)
            {
                return _immortalView;
            }

            if (ability is SnakeHealthAbility)
            {
                return _healthView;
            }

            if (ability is SnakeNullAbility)
            {
                return null;
            }
            throw new System.InvalidOperationException();
        }
    }
}
