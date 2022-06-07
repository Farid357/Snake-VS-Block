using UnityEngine;

namespace Snake.Tools
{
    public sealed class HorizontalBounds
    {
        private Camera _camera;

        public float MaxPositionX { get; private set; }
        public float MinPositionX { get; private set; }

        public HorizontalBounds(Camera camera)
        {
            _camera = camera;
            MaxPositionX = _camera.ScreenToWorldPoint(Screen.safeArea.max).x;
            MinPositionX = _camera.ScreenToWorldPoint(Screen.safeArea.min).x;
        }
    }
}
