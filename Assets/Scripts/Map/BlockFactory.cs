using Snake.Model;

namespace Snake.GameLogic
{
    public sealed class BlockFactory
    {

        public (IDisposable, IDisposable) Spawn(BlockProvider provider, BlockContext block, SnakeCircles snakeCircles, AbilityViewProvider abilityViewProvider)
        {
            var model = provider.GetBlock(block.Type, block.Health, block.AbilitySeconds);
            IDisposable presenter = new BlockPresenter(snakeCircles, model, block.View, block.Collision);
            block.gameObject.SetActive(true);
            var ability = provider.Ability;
            IDisposable abilityPresenter = null;

            if (ability != null)
            {
                abilityPresenter = new SnakeAbilityPresenter(ability, abilityViewProvider.Get(ability));
            }
            return (presenter, abilityPresenter);
        }
    }
}