using UnityEngine.SceneManagement;

namespace Clicker.LoadSystem
{
    public class StandartLoader : ILoader
    {
        public void Load(SceneData sceneData)
        {
            SceneManager.LoadSceneAsync(sceneData.name);
        }
    }
}
