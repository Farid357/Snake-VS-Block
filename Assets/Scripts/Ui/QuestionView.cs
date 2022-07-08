using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(Image))]
    public sealed class QuestionView : MonoBehaviour
    {
        [SerializeField] private Gradient _gradient;
        [SerializeField] private float _delay = 1.4f;

        private void Start()
        {
            var image = GetComponent<Image>();
            StartCoroutine(ChangeColor(_gradient, image));
        }

        private IEnumerator ChangeColor(Gradient gradient, Image image)
        {
            image.DOGradientColor(gradient, 2f);
            yield return new WaitForSeconds(_delay);
            yield return StartCoroutine(ChangeColor(gradient, image));
        }
    }
}
