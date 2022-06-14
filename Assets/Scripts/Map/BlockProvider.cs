using Snake.Model;

namespace Snake.GameLogic
{
    public sealed class BlockProvider
    {
        private SnakeCircles _snakeCircles;

        public BlockProvider(SnakeCircles snakeCircles) => _snakeCircles = snakeCircles;

        public IBlock GetBlock(BlockType type, int health, float seconds)
        {
            if (type == BlockType.WithBonus)
            {
                return new BonusBlock(new SnakeImmortalAbility(_snakeCircles, seconds), health);
            }

            if (type == BlockType.Standart)
            {
                return new BlockHealth(health);
            }
            throw new System.InvalidOperationException();
        }
    }
}
