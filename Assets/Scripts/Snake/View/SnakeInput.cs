using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Snake.Input
{
    public sealed class SnakeInput : MonoBehaviour, IInput, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public event Action<Vector2> OnChangedDelta;

        private Vector2 _delta;
        private Vector2 _startTouch;
        private Camera _camera;

        public void Init(Camera camera)
        {
            _camera = camera;

            _delta = Vector2.zero;
            _startTouch = Vector2.zero;
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            _startTouch = _camera.ScreenToWorldPoint(eventData.position);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            Vector2 lastPosition = _startTouch;
            _startTouch = _camera.ScreenToWorldPoint(eventData.position);
            _delta = _startTouch - lastPosition;

            OnChangedDelta?.Invoke(_delta);
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            _delta = Vector2.zero;
        }
    }
}
