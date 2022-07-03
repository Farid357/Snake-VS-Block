using TMPro;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void Display(int count) => _text.text = count.ToString();

    }
}
