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
        private readonly RandomAbilityGenerator _generator = new();

        public BlockProvider(float seconds)
        {
            _nullAbility = new(seconds);
            _immortalAbility = new(seconds);
            _healthAbility = new(seconds);
        }

        public (IBlock, IAbility) Get(BlockType type, int health)
        {
            switch (type)
            {
                case BlockType.Standart:
                    var block = new Block(health);
                    return (block, _nullAbility);

                case BlockType.WithImmortalAbiity:
                    var bonusBlock = new BonusBlock(_immortalAbility, health, AbilityProvider);
                    return (bonusBlock, _immortalAbility);

                case BlockType.WithHealthAbility:
                    var healthBlock = new BonusBlock(_healthAbility, health, AbilityProvider);
                    return (healthBlock, _healthAbility);

                case BlockType.WithRandomAbility:
                    var ability = _generator.GetRandom(_healthAbility, _immortalAbility, _nullAbility);
                    var randomBlock = new BonusBlock(ability, health, AbilityProvider);
                    return (randomBlock, ability);

                default:
                    throw new InvalidOperationException($"{type} not added!");
            }
        }
    }
}
