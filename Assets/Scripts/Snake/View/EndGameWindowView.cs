using Snake.Model;
using TMPro;
using UnityEngine;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class EndGameWindowView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _bestScore;
        private ICounter _counter;

        public void Show()
        {
            gameObject.SetActive(true);
            _bestScore.text = _counter.Count.ToString();
        }

        public void Init(ICounter counter) => _counter = counter ?? throw new System.ArgumentNullException(nameof(counter));

    }
}
