using System;
using Snake.Model;

namespace Snake.GameLogic
{
    public sealed class SnakeCirclesPresenter : IDisposable, IUpdatable
    {
        private readonly SnakeCirclesView _view;
        private readonly SnakeCircles _model;
        private readonly SnakeCirclesMovement _circlesMovement;

        public SnakeCirclesPresenter(SnakeCirclesView view, SnakeCircles model, int count)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model.OnRemoved += _view.RemoveLast;
            _model.OnAdded += _view.Add;
            _model.OnRemoved += UpdateText;
            _model.OnAdded += _view.Display;
            _model.Add(count);
            _view.Display(_model.Count - 1);
            _circlesMovement = new(_view.Circles, _view.Positions, _view.CircleDiameter, _view.Head);
        }

        private void UpdateText() => _view.Display(_model.Count);

        public void Dispose()
        {
            _model.OnAdded -= _view.Add;
            _model.OnRemoved -= _view.RemoveLast;
            _model.OnRemoved -= UpdateText;
            _model.OnAdded -= _view.Display;
        }

        public void Update(float deltaTime) => _circlesMovement.Update(deltaTime);
    }
}
