using System;
using Snake.Model;
using UnityEngine;

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
            _model.OnChanged += _view.Display;
            _model.OnBecameImmortal += _view.ImmortalView.MakeImmortal;
            _model.OnCompletedBeImmortal += _view.ImmortalView.UnMakeImmortal;
            _model.Add(count);
            _circlesMovement = new(_view.Circles, _view.Positions, _view.CircleDiameter, _view.Head);
        }

        public void Dispose()
        {
            _model.OnAdded -= _view.Add;
            _model.OnRemoved -= _view.RemoveLast;
            _model.OnChanged -= _view.Display;
            _model.OnBecameImmortal -= _view.ImmortalView.MakeImmortal;
            _model.OnCompletedBeImmortal -= _view.ImmortalView.UnMakeImmortal;
        }

        public void Update(float deltaTime) => _circlesMovement.Update(deltaTime);
    }
}
