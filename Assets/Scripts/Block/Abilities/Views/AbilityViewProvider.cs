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
            throw new System.InvalidOperationException();
        }
    }
}
