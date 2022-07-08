using UnityEngine;

namespace Snake.App
{
    public sealed class AppState
    {
        public void Pause() => Time.timeScale = 0;

        public void Continue() => Time.timeScale = 1;

    }
}
