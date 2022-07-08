using UnityEngine;
using UnityEngine.UI;

namespace Snake.App
{
    [RequireComponent(typeof(Button))]
    public abstract class AppStateButton : MonoBehaviour
    {
        protected readonly AppState AppState = new();
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnCLick);
        }

        protected abstract void OnCLick();

        private void OnDestroy() => _button.onClick.RemoveListener(OnCLick);
    }
}
