using TMPro;
using UnityEngine;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class BlockView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Color[] _colors;
        [SerializeField] private ParticleSystem _particle;
        private SpriteRenderer _spriteRenderer;

        public void Display(int count)
        {
            _text.text = count.ToString();
            Instantiate(_particle, transform.position, Quaternion.identity).Play();
        }

        public void DisplayRandomColor()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            var index = Random.Range(0, _colors.Length);
            _spriteRenderer.color = _colors[index];
        }

        public void Disable()
        {
            gameObject.SetActive(false);
            Instantiate(_particle, transform.position, Quaternion.identity).Play();
        }
    }
}
