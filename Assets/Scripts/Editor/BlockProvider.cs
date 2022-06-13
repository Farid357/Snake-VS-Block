using Snake.GameLogic;
using Snake.Model;
using UnityEngine;

namespace Snake.Editor
{
    public sealed class BlockProvider
    {
        private SnakeCircles _snakeCircles;

        public BlockProvider(SnakeCircles snakeCircles) => _snakeCircles = snakeCircles;

        public BlockHealth GetBlock(BlockType type, int health, int seconds)
        {
            if (type == BlockType.WithBonus)
            {
                return new BonusBlock(new SnakeImmortalAbility(_snakeCircles, seconds), health);
            }

            if (type == BlockType.Standart)
            {
                return new BlockHealth(5);
            }
            else
            {
                Debug.LogError("Dont correct type!");
                return null;
            }
        }
    }
}
