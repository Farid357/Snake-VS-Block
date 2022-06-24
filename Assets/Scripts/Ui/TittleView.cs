using UnityEngine;
using DG.Tweening;
using TMPro;

namespace Snake.GameLogic
{
    public sealed class TittleView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tittle;
        [SerializeField] private float _seconds = 1.5f;
        [SerializeField, ColorUsage(false)] private Color _nextColor = Color.blue;

        private void Start()
        {
            _tittle.DOColor(_nextColor, _seconds).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
