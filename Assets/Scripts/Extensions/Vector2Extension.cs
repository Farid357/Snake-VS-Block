using UnityEngine;

namespace Snake.Tools
{
    public static class Vector2Extension
    {
        public static Vector2 ClampForBounds(this Vector2 position, in SafeAreaBounds bounds)
        {
            var minPositionWithDelta = bounds.GetMinPositionXWithOffset();
            if (position.x > bounds.GetMaxPositionX())
            {
                position.x = bounds.GetMaxPositionX();
            }

            else if (position.x < minPositionWithDelta)
            {
                position.x = minPositionWithDelta;
            }
            return position;
        }
    }
}
