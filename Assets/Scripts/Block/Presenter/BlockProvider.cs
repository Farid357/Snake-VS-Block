using Snake.Model;
using System;

namespace Snake.GameLogic
{
    public sealed class BlockProvider
    {
        public readonly AbilityProvider AbilityProvider = new();
        private readonly SnakeImmortalAbility _immortalAbility;
        private readonly SnakeHealthAbility _healthAbility;
        private readonly SnakeNullAbility _nullAbility;

        public BlockProvider(SnakeCircles snakeCircles, float seconds)
        {
            if (snakeCircles is null)
            {
                throw new ArgumentNullException(nameof(snakeCircles));
            }

            _nullAbility = new(seconds);
            _immortalAbility = new(seconds);
            _healthAbility = new(seconds);
        }


        public (IBlock, IAbility) Get(BlockType type, int health)
        {
            if (type == BlockType.WithImmortalAbiity)
            {
                var bonusBlock = new BonusBlock(_immortalAbility, health, AbilityProvider);
                return (bonusBlock, _immortalAbility);
            }

            if (type == BlockType.Standart)
            {
                var block = new Block(health);
                return (block, _nullAbility);
            }

            if (type == BlockType.WithHealthAbility)
            {
                var block = new BonusBlock(_healthAbility, health, AbilityProvider);
                return (block, _healthAbility);
            }

            throw new InvalidOperationException($"{type} not added!");
        }
    }
}
