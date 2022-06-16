using Snake.Model;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class AbilityViewProvider : MonoBehaviour
    {
        [SerializeField] private SnakeImmortalAbilityView _immortalView;

        public IAbilityView Get(IAbility ability)
        {
            if (ability is SnakeImmortalAbility)
            {
                return _immortalView;
            }
            throw new System.InvalidOperationException();
        }
    }
}
