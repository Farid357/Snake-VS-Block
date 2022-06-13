using Snake.Model;
using System;

namespace Snake.GameLogic
{
    public sealed class BlockPresenter : IDisposable
    {
        private readonly IBlock _model;
        private readonly SnakeCircles _snakeCircles;
        private readonly BlockContext _context;
        private const int Damage = 1;

        public BlockPresenter(SnakeCircles snakeCircles, IBlock model, BlockContext context)
        {
            _snakeCircles = snakeCircles ?? throw new ArgumentNullException(nameof(snakeCircles));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _model.OnChanged += _context.View.Display;
            _model.OnEnded += _context.View.Disable;
            _context.Collision.OnCollided += RemoveSnakeCircle;
            _model.UpdateHealth();
            _context.View.DisplayRandomColor();
        }

        private void RemoveSnakeCircle()
        {
            _snakeCircles.Remove(Damage);
            _model.TakeDamage(Damage);
        }

        public void Dispose()
        {
            _model.OnChanged -= _context.View.Display;
            _model.OnEnded -= _context.View.Disable;
            _context.Collision.OnCollided -= RemoveSnakeCircle;
        }
    }
}
