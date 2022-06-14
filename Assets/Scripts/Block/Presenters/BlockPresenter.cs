using Snake.Model;
using System;

namespace Snake.GameLogic
{
    public sealed class BlockPresenter : IDisposable
    {
        private readonly IBlock _model;
        private readonly SnakeCircles _snakeCircles;
        private readonly BlockCollision _collision;
        private const int Damage = 1;
        private readonly BlockView _view;

        public BlockPresenter(SnakeCircles snakeCircles, IBlock model, BlockView view, BlockCollision collision)
        {
            _snakeCircles = snakeCircles ?? throw new ArgumentNullException(nameof(snakeCircles));
            _collision = collision ?? throw new ArgumentNullException(nameof(collision));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model.OnChanged += _view.Display;
            _model.OnEnded += _view.Disable;
            _collision.OnCollided += RemoveSnakeCircle;
            _model.UpdateHealth();
            _view.DisplayRandomColor();
        }

        private void RemoveSnakeCircle()
        {
            _snakeCircles.Remove(Damage);
            _model.TakeDamage(Damage);
        }

        public void Dispose()
        {
            _model.OnChanged -= _view.Display;
            _model.OnEnded -= _view.Disable;
            _collision.OnCollided -= RemoveSnakeCircle;
        }
    }
}
