using UnityEngine;
using TMPro;
using System;
using Zenject;

namespace Snake.GameLogic
{
    [RequireComponent(typeof(CircleCollider2D))]
    public sealed class FoodView : MonoBehaviour
    {
        public event Action OnCollided;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _maxDistance = 125f;
        private SnakeHead _snakeHead;

        public void Display(int count) => _text.text = count.ToString();


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<SnakeHead>(out _))
            {
                OnCollided?.Invoke();
                gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            float distance = (_snakeHead.transform.position - transform.position).sqrMagnitude;
            if (distance >= _maxDistance)
            {
                gameObject.SetActive(false);
            }
        }

        [Inject]
        public void Constructor(SnakeHead snakeHead) => _snakeHead = snakeHead;
    }
}