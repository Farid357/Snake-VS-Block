using Zenject;
using Snake.Model;
using UnityEngine;

namespace Snake.GameLogic
{
    public class AppStartBindings : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SnakeCircles>().FromNew().AsSingle();
        }
    }
}
