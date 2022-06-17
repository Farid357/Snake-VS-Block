using UnityEngine;
using TMPro;
using System;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(CircleCollider2D))]
    public sealed class FoodView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private Action _onCollided;

        public event Action OnCollided { add => _onCollided ??= value; remove => _onCollided -= value; }

        public void Display(int count) => _text.text = count.ToString();


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<SnakeHead>(out _))
            {
                _onCollided.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}