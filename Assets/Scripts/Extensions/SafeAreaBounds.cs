using UnityEngine;

namespace Snake.Tools
{
    public sealed class SafeAreaBounds
    {
        private const float ScreenOffsetX = 0.6f;

        private readonly Camera _camera;
        private float _minPositionX;
        private float _maxPositionX;

        public SafeAreaBounds(Camera camera)
        {
            _camera = camera;
            _maxPositionX = _camera.ScreenToWorldPoint(Screen.safeArea.max).x;
            _minPositionX = _camera.ScreenToWorldPoint(Screen.safeArea.min).x;
        }

        public float GetMaxPositionX() => _maxPositionX - ScreenOffsetX;

        public float GetMinPositionXWithOffset() => _minPositionX + ScreenOffsetX;

    }
}
