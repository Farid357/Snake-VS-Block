using UnityEngine;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class EndGameWindowView : MonoBehaviour
    {
        public void Show() => gameObject.SetActive(true);
    }
}
