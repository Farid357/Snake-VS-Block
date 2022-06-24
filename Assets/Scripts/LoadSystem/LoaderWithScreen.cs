using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading.Tasks;

namespace Snake.LoadSystem
{
    public sealed class LoaderWithScreen : ILoader
    {
        private SceneData _loaderScene;
        private AsyncOperation _loadScreen;
        private AsyncOperation _nextSceneLoad;
        private SceneData _nextScene;

        public LoaderWithScreen(SceneData loaderScene) => _loaderScene = loaderScene;

        public void Load(SceneData sceneData)
        {
            _loadScreen = SceneManager.LoadSceneAsync(_loaderScene.Name, LoadSceneMode.Additive);
            _nextScene = sceneData;
            _loadScreen.completed += LoadNext;
        }

        private async void ChangeLoadText()
        {
            while (!_nextSceneLoad.isDone)
            {
                await Task.Yield();
                LoadText.SetInterest(_nextSceneLoad.progress);
            }
        }

        private void LoadNext(AsyncOperation operation)
        {
            _nextSceneLoad = SceneManager.LoadSceneAsync(_nextScene.name);
            ChangeLoadText();
            _loadScreen.completed -= LoadNext;
        }
    }
}
