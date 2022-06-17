using Snake.Model;
using System;

namespace Snake.GameLogic
{
    public sealed class BlockProvider
    {
        public readonly AbilityProvider AbilityProvider = new();
        private readonly SnakeImmortalAbility _immortalAbility;
        private readonly SnakeHealthAbility _healthAbility;

        public BlockProvider(SnakeCircles snakeCircles, float seconds)
        {
            if (snakeCircles is null)
            {
                throw new ArgumentNullException(nameof(snakeCircles));
            }

            _immortalAbility = new(snakeCircles, seconds);
            _healthAbility = new(snakeCircles, seconds);
        }

        public IAbility Ability { get; private set; }

        public IBlock GetBlock(BlockType type, int health)
        {
            if (type == BlockType.WithImmortalAbiity)
            {
                Ability = _immortalAbility;
                return new BonusBlock(Ability, health, AbilityProvider);
            }

            if (type == BlockType.Standart)
            {
                Ability = null;
                return new Block(health);
            }

            if (type == BlockType.WithHealthAbility)
            {
                Ability = _healthAbility;
                return new BonusBlock(Ability, health, AbilityProvider);
            }

            throw new InvalidOperationException();
        }
    }
}
