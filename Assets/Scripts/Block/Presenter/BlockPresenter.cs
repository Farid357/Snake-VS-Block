using Snake.Model;
using System;
using System.Collections.Generic;

namespace Snake.GameLogic
{
    public sealed class BlockPresenter : IDisposable
    {
        private readonly IBlock _model;
        private readonly ISnakeAbilityVisitor _damagePolicy;
        private readonly SnakeCircles _snakeCircles;
        private readonly BlockCollision _collision;
        private readonly AbilityProvider _provider;
        private readonly BlockView _view;
        private const int Damage = 1;

        public BlockPresenter(SnakeCircles snakeCircles, IBlock model, BlockView view, BlockCollision collision, AbilityProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _snakeCircles = snakeCircles ?? throw new ArgumentNullException(nameof(snakeCircles));
            _collision = collision ?? throw new ArgumentNullException(nameof(collision));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _model.OnChangedHealth += _view.Display;
            _model.OnEndedHealth += _view.Disable;
            _collision.OnCollided += RemoveSnakeCircle;
            _model.UpdateHealth();
            _view.DisplayRandomColor();
            _damagePolicy = new BlockDamagePolicy(_snakeCircles, Damage);
        }

        private void RemoveSnakeCircle()
        {
            if (_provider.TryGetAbility(out var ability) && ability.IsApplyed)
            {
                _damagePolicy.Visit((dynamic)ability, _model);
            }

            else
            {
                _model.TakeDamage(Damage);
                _snakeCircles.Remove(Damage);
            }
        }

        public void Dispose()
        {
            _model.OnChangedHealth -= _view.Display;
            _model.OnEndedHealth -= _view.Disable;
            _collision.OnCollided -= RemoveSnakeCircle;
        }
    }
}
