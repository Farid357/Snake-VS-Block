using Snake.GameLogic;
using Snake.Input;
using Snake.Model;
using Snake.Tools;
using UnityEngine;
using Zenject;

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
        [SerializeField] private BlockRoot _blockRoot;
        private Camera _camera;
        private SnakeMovement _snake;
        private IDisposable _presenter;
        private SnakeCircles _model;

        private void Awake()
        {
            _camera = Camera.main;
            var bounds = new SafeAreaBounds(_camera);
            _prefab.SetColliderFromGameObject();
            _snake = new SnakeMovement(_input, _snakeRigidbody, _horizontalSpeed, bounds);
            _input.Init(_camera);
            _view.Init(_snakeHead, _prefab);
            _presenter = new SnakeCirclesPresenter(_view, _model, _circlesStartCount);
            _blockRoot.Init(bounds);
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

        [Inject]
        private void Constructor(SnakeCircles model) => _model = model;
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

public interface IUpdatable
{
    public void Update(float deltaTime);
}