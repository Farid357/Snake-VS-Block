using System;

namespace Snake.GameLogic
{
    public sealed class SnakeCirclesPresenter : IDisposable
    {
        private readonly SnakeCirclesView _view;
        private readonly SnakeCircles _model;

        public SnakeCirclesPresenter(SnakeCirclesView view, SnakeCircles model, int count)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model.OnRemoved += _view.RemovOne;
            _model.OnAdded += _view.Add;
            _model.Add(count);
        }

        public void Dispose()
        {
            _model.OnAdded -= _view.Add;
            _model.OnRemoved -= _view.RemovOne;
        }
    }
}
