using System.Threading.Tasks;

namespace Snake.GameLogic
{
    public sealed class BlockLifeTime
    {
        private readonly float _lifeTime = 5f;
        private readonly BlockView _blockView;

        public BlockLifeTime(float lifeTime, BlockView blockView)
        {
            if (lifeTime <= 0) throw new System.ArgumentOutOfRangeException(nameof(lifeTime));
            _lifeTime = lifeTime;
            _blockView = blockView ?? throw new System.ArgumentNullException(nameof(blockView));
        }

        public async void Enable()
        {
            await Task.Delay(System.TimeSpan.FromSeconds(_lifeTime));
            _blockView.Disable();
        }
    }
}
