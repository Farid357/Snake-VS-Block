using Snake.Input;
using UnityEngine;
using Snake.Model;
using Snake.Tools;
using Snake.GameLogic;

namespace Snake.Root
{
    public sealed class SnakeRoot : MonoBehaviour
    {
        [SerializeField] private SnakeInput _input;
        [SerializeField] private Rigidbody2D _snakeRigidbody;
        [SerializeField] private float _horizontalSpeed = 2.3f;
        [SerializeField] private SnakeCirclesView _view;
        [SerializeField] private SnakeHead _snakeHead;
        [SerializeField] private Circle _prefab;
        [SerializeField, Min(1)] private int _circlesStartCount = 4;
        private Camera _camera;
        private SnakeMovement _snake;
        private IDisposable _presenter;

        private void Awake()
        {
            _camera = Camera.main;
            SnakeCircles model = new();
            var bounds = new HorizontalBounds(_camera);
            _prefab.SetColliderFromGameObject();
            _snake = new SnakeMovement(_input, _snakeRigidbody, _horizontalSpeed, bounds);
            _input.Init(_camera);
            _view.Init(_snakeHead, _prefab);
            _presenter = new SnakeCirclesPresenter(_view, model, _circlesStartCount);
        }

        private void FixedUpdate()
        {
            _snake.FixedUpdate(Time.fixedDeltaTime);
        }

        private void OnDestroy()
        {
            _snake.Dispose();
            _presenter.Dispose();
        }
    }
}

public interface IFixedUpdatable
{
    public void FixedUpdate(float fixedDeltaTime);
}

public interface IDisposable
{
    public void Dispose();
}