using UnityEngine;
using UnityEngine.UI;

namespace Snake.App
{
    [RequireComponent(typeof(Button))]
    public sealed class PauseButton : AppStateButton
    {
        protected override void OnCLick()
        {
            AppState.Pause();
        }
    }
}
