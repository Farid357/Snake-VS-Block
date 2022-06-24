using UnityEngine;

namespace Snake.LoadSystem
{
    public sealed class SceneLoader : MonoBehaviour, ILoader
    {
        [SerializeField] private SceneLoadMode _mode;
        [SerializeField] private ScreenFade _screen;
        [SerializeField] private SceneData _loaderScene;
        private ILoader[] _loaders;

        public void Load(SceneData sceneData)
        {
            _loaders = new ILoader[]
            {
                new StandartLoader(),
                new FadeLoader(_screen),
                new LoaderWithScreen(_loaderScene),
            };
            var modeIndex = (int) _mode;
            _loaders[modeIndex].Load(sceneData);
        }
    }

    public enum SceneLoadMode
    {
        Simple,
        Fade,
        WithLoadScreen
    }

    public interface ILoader
    {
        public void Load(SceneData sceneData);
    }
}
