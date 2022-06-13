using UnityEngine;
using UnityEngine.SceneManagement;

namespace Clicker.LoadSystem
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
            AsyncOperation loadOpearation = null;
            loadOpearation = SceneManager.LoadSceneAsync(_nextScene.name);
            _screen.StartFadeOut();
            _screen.OnDarkened -= FadeOut;
        }

        public void Load(SceneData sceneData)
        {
            _nextScene = sceneData;
            _screen.StartFade();
        }
    }
}
