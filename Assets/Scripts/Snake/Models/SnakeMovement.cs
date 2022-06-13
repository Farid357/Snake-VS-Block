using Snake.Input;
using Snake.Tools;
using UnityEngine;

namespace Snake.Model
{
    public sealed class SnakeMovement : IFixedUpdatable, IDisposable
    {
        private readonly float _horizontalSpeed;
        private readonly float _verticalSpeed = 1.2f;
        private readonly Rigidbody2D _rigidbody;
        private readonly IInput _input;
        private readonly Tools.SafeAreaBounds _bounds;
        private float _xDelta;

        public SnakeMovement(IInput input, Rigidbody2D rigidbody, float horizontalSpeed, Tools.SafeAreaBounds bounds)
        {
            _rigidbody = rigidbody ?? throw new System.ArgumentNullException(nameof(rigidbody));
            _horizontalSpeed = horizontalSpeed;
            _input = input ?? throw new System.ArgumentNullException(nameof(input));
            _bounds = bounds;
            _input.OnChangedDelta += MoveX;
        }

        public void Dispose() => _input.OnChangedDelta -= MoveX;

        public void FixedUpdate(float fixedDeltaTime)
        {
            if (_rigidbody == null) return;

            Vector2 movement = (Vector2.right * (_xDelta * _horizontalSpeed)) + (Vector2.up * _verticalSpeed);
            Vector2 movePosition = _rigidbody.position + (movement * fixedDeltaTime);

            movePosition = movePosition.ClampForBounds(_bounds);
            _rigidbody.MovePosition(movePosition);
            _xDelta -= _xDelta * fixedDeltaTime * _horizontalSpeed;
        }

        public void MoveX(Vector2 delta) => _xDelta += delta.x;
    }
}
