using UnityEngine.SceneManagement;

namespace Snake.LoadSystem
{
    public class StandartLoader : ILoader
    {
        public void Load(SceneData sceneData)
        {
            SceneManager.LoadSceneAsync(sceneData.name);
        }
    }
}
