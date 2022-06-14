using Zenject;
using Snake.Model;
using Snake.Tools;

namespace Snake.GameLogic
{
    public sealed class AppStartBindingsMono : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ObjectsPool<MapPair>>().FromNew().AsSingle();
            Container.Bind<SnakeCircles>().FromNew().AsSingle();
        }
    }
}
