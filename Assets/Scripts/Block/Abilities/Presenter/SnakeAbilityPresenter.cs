using System;
using Snake.GameLogic;

namespace Snake.Model
{
    public sealed class SnakeAbilityPresenter : IDisposable
    {
        private readonly IAbility _model;
        private readonly IAbilityView _view;

        public SnakeAbilityPresenter(IAbility model, IAbilityView view)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model.OnApplyed += _view.Display;
        }

        public void Dispose()
        {
            _model.OnApplyed -= _view.Display;
        }
    }
}
