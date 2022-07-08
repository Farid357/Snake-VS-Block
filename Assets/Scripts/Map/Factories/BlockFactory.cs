using Snake.Model;

namespace Snake.GameLogic
{
    public sealed class BlockFactory : IDisposable
    {
        private readonly ScorePresenter _scorePresenter;
        private readonly ScoreView _scoreView;

        public BlockFactory(ScoreView scoreView, Score score)
        {
            _scoreView = scoreView ?? throw new System.ArgumentNullException(nameof(scoreView));
            _scorePresenter = new(_scoreView, score);
        }

        public void Dispose() => _scorePresenter.Dispose();

        public (IDisposable, IDisposable) Spawn(BlockProvider provider, BlockContext block, SnakeCircles snakeCircles, AbilityViewProvider abilityViewProvider)
        {
            var data = provider.Get(block.Type, block.Health);
            IDisposable presenter = new BlockPresenter(snakeCircles, data.Item1, block.View, block.Collision, provider.AbilityProvider);
            var ability = data.Item2;
            data.Item1.OnChangedHealth += (int count) => _scorePresenter.Add(1, ability);
            block.gameObject.SetActive(true);
            IDisposable abilityPresenter = new SnakeAbilityPresenter(ability, abilityViewProvider.Get(ability));
            return (presenter, abilityPresenter);
        }
    }
}