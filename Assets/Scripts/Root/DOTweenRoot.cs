using DG.Tweening;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class DOTweenRoot : MonoBehaviour
    {
        public void Init()
        {
            DOTween.Init();
        }
    }
}
