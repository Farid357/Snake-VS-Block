using TMPro;
using UnityEngine;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class BlockView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Color[] _colors;
        private SpriteRenderer _spriteRenderer;

        private void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();

        public void Display(int count) => _text.text = count.ToString();

        public void DisplayRandomColor()
        {
            var index = Random.Range(0, _colors.Length);
            _spriteRenderer.color = _colors[index];
        }

        public void Disable() => gameObject.SetActive(false);
    }
}
