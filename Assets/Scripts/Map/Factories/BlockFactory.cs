using Snake.Model;

namespace Snake.GameLogic
{
    public sealed class BlockFactory
    {

        public (IDisposable, IDisposable) Spawn(BlockProvider provider, BlockContext block, SnakeCircles snakeCircles, AbilityViewProvider abilityViewProvider)
        {
            var model = provider.GetBlock(block.Type, block.Health);
            var ability = provider.Ability;
            IDisposable presenter = new BlockPresenter(snakeCircles, model, block.View, block.Collision, provider.AbilityProvider);
            block.gameObject.SetActive(true);
            IDisposable abilityPresenter = null;

            if (ability != null)
            {
                abilityPresenter = new SnakeAbilityPresenter(ability, abilityViewProvider.Get(ability));
            }
            return (presenter, abilityPresenter);
        }
    }
}