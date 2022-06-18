using Snake.Model;

namespace Snake.GameLogic
{
    public sealed class BlockFactory
    {
        public (IDisposable, IDisposable) Spawn(BlockProvider provider, BlockContext block, SnakeCircles snakeCircles, AbilityViewProvider abilityViewProvider)
        {
            var data = provider.Get(block.Type, block.Health);
            IDisposable presenter = new BlockPresenter(snakeCircles, data.Item1, block.View, block.Collision, provider.AbilityProvider);
            block.gameObject.SetActive(true);
            var ability = data.Item2;
            IDisposable abilityPresenter = new SnakeAbilityPresenter(ability, abilityViewProvider.Get(ability));
            return (presenter, abilityPresenter);
        }
    }
}