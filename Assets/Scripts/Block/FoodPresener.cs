using Snake.Model;
using System;

namespace Snake.GameLogic
{
    public sealed class FoodPresener : IDisposable
    {
        private readonly Food _model;
        private readonly FoodView _view;
        private readonly SnakeCircles _snakeCircles;

        public FoodPresener(Food model, FoodView view, SnakeCircles snakeCircles)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _snakeCircles = snakeCircles ?? throw new ArgumentNullException(nameof(snakeCircles));
            _view.OnCollided += Add;
            _view.Display(_model.Count);
        }

        public void Dispose() => _view.OnCollided -= Add;

        private void Add() => _snakeCircles.Add(_model.Count);

    }
}