using Snake.Model;

namespace Snake.GameLogic
{
    public sealed class BlockProvider
    {
        private SnakeCircles _snakeCircles;
        private readonly SnakeImmortalAbility _immortalAbility;

        public BlockProvider(SnakeCircles snakeCircles, float seconds)
        {
            _snakeCircles = snakeCircles;
            _immortalAbility = new(snakeCircles, seconds);
        }

        public IAbility Ability { get; private set; }

        public IBlock GetBlock(BlockType type, int health, float seconds)
        {
            if (type == BlockType.WithImmortalAbiity)
            {
                Ability = _immortalAbility;
                return new BonusBlock(Ability, health);
            }

            if (type == BlockType.Standart)
            {
                Ability = null;
                return new BlockHealth(health);
            }

            throw new System.InvalidOperationException();
        }
    }
}
