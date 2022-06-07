using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Snake.Input
{
    public sealed class SnakeInput : MonoBehaviour, IInput, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public event Action<Vector2> OnChangedDelta;
        public event Action<Vector2> OnChangedAbsolute;

        private Vector2 _delta;
        private Vector2 _absolute;
        private Camera _camera;

        public void Init(Camera camera)
        {
            _camera = camera;

            _delta = Vector2.zero;
            _absolute = Vector2.zero;
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            _absolute = _camera.ScreenToWorldPoint(eventData.position);
            OnChangedAbsolute?.Invoke(_absolute);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            Vector2 lastPosition = _absolute;
            _absolute = _camera.ScreenToWorldPoint(eventData.position);
            _delta = _absolute - lastPosition;

            OnChangedAbsolute?.Invoke(_absolute);
            OnChangedDelta?.Invoke(_delta);
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            _delta = Vector2.zero;
        }
    }

    public interface IInput
    {
        public event Action<Vector2> OnChangedDelta;
        public event Action<Vector2> OnChangedAbsolute;
    }
}
