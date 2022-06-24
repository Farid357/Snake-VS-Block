using UnityEngine.SceneManagement;

namespace Snake.LoadSystem
{
    public sealed class FadeLoader : ILoader
    {
        private ScreenFade _screen;
        private SceneData _nextScene;

        public FadeLoader(ScreenFade screen)
        {
            _screen = screen;
            _screen.OnDarkened += FadeOut;
        }

        public void FadeOut()
        {
            var loadOpearation = SceneManager.LoadSceneAsync(_nextScene.name);
            _screen.FadeOut();
            _screen.OnDarkened -= FadeOut;
        }

        public void Load(SceneData sceneData)
        {
            _nextScene = sceneData;
            _screen.FadeIn();
        }
    }
}
