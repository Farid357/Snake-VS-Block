using Snake.Model;
using System;

namespace Snake.GameLogic
{
    public sealed class ScorePresenter : IDisposable
    {
        private readonly Score _score;
        private readonly ScoreView _view;

        public ScorePresenter(ScoreView view, Score score)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _score.OnChanged += _view.Display;
        }

        public void Add(int count, IAbility ability) => _score.Add(count, ability);

        public void Dispose() => _score.OnChanged -= _view.Display;

    }
}
