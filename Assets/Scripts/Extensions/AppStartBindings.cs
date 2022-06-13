using Zenject;
using Snake.Model;
using UnityEngine;
using Snake.Tools;

namespace Snake.GameLogic
{
    public class AppStartBindings : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ObjectsPool<BlockContext>>().FromNew().AsSingle();
            Container.Bind<ObjectsPool<FoodView>>().FromNew().AsSingle();
            Container.Bind<SnakeCircles>().FromNew().AsSingle();
        }
    }
}
