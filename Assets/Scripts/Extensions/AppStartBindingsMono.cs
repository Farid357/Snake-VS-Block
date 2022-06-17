using Zenject;
using Snake.Model;
using Snake.Tools;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class AppStartBindingsMono : MonoInstaller
    {
        [SerializeField] private SnakeHead _snakeHead;

        public override void InstallBindings()
        {
            Container.BindInstance(_snakeHead).AsSingle();
            Container.Bind<ObjectsPool<MapPair>>().FromNew().AsSingle();
            Container.Bind<SnakeCircles>().FromNew().AsSingle();
        }
    }
}
