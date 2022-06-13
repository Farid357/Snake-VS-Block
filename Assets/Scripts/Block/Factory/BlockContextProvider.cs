using Snake.Model;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class BlockContextProvider : MonoBehaviour
    {
        [SerializeField] private BlockContext _bonusBlock;
        [SerializeField] private BlockContext _baseBlock;

        public BlockContext Get(IBlock block)
        {
            if (block is BonusBlock)
            {
                return _bonusBlock;
            }

            else if (block is BlockHealth)
            {
                return _baseBlock;
            }
            throw new System.InvalidOperationException($"{block} type is not contains this method! Please add this type!");
        }
    }
}