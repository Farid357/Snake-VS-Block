using UnityEngine;

namespace Snake.Tools
{
    public sealed class SafeAreaBounds
    {
        private const float ScreenOffsetX = 0.6f;

        private readonly Camera _camera;
        public float MinPositionX { get; private set; }

        public SafeAreaBounds(Camera camera)
        {
            _camera = camera;
            MaxPositionX = _camera.ScreenToWorldPoint(Screen.safeArea.max).x;
            MinPositionX = _camera.ScreenToWorldPoint(Screen.safeArea.min).x;
        }

        public float MaxPositionX { get; private set; }

        public float GetMinPositionXWithOffset() => MinPositionX + ScreenOffsetX;

    }
}
