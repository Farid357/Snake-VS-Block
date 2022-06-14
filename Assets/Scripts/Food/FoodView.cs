using UnityEngine;
using TMPro;
using System;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(CircleCollider2D))]
    public sealed class FoodView : MonoBehaviour
    {
        public event Action OnCollided;
        [SerializeField] private TMP_Text _text;

        public void Display(int count) => _text.text = count.ToString();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<SnakeHead>(out _))
            {
                OnCollided?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}