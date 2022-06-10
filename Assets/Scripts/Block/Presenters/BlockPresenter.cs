using Snake.Model;
using System;

namespace Snake.GameLogic
{
    public sealed class BlockPresenter : IDisposable
    {
        private readonly BlockView _view;
        private readonly IBlock _model;
        private readonly SnakeCircles _snakeCircles;
        private readonly BlockContext _context;
        private const int Damage = 1;

        public BlockPresenter(SnakeCircles snakeCircles, IBlock model, BlockContext context)
        {
            _snakeCircles = snakeCircles ?? throw new ArgumentNullException(nameof(snakeCircles));
            _context = context;
            _view = context.View ?? throw new ArgumentNullException(nameof(context.View));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _model.OnChanged += _view.Display;
            _model.OnEnded += _view.Disable;
            _context.Collision.OnCollided += RemoveSnakeCircle;
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
            _context.Collision.OnCollided -= RemoveSnakeCircle;
        }
    }
}
