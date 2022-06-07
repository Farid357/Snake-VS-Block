using UnityEngine;

namespace Snake.Tools
{
    public static class Vector2Extension
    {
        private const float ScreenDelta = 0.6f;

        public static Vector2 ClampForBounds(this Vector2 position, in HorizontalBounds bounds)
        {
            var minPositionWithDelta = bounds.MinPositionX + ScreenDelta;
            if (position.x > bounds.MaxPositionX)
            {
                position.x = bounds.MaxPositionX;
            }

            else if (position.x < minPositionWithDelta)
            {
                position.x = minPositionWithDelta;
            }
            return position;
        }
    }
}
