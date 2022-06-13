using System;
using UnityEngine;

namespace Snake.Model
{
    public sealed class SnakeImmortalAbility : IAbility
    {
        private readonly SnakeCircles _snakeCircles;
        private readonly float _seconds;

        public SnakeImmortalAbility(SnakeCircles snakeCircles, float seconds)
        {
            _seconds = seconds > 0 ? seconds : throw new ArgumentOutOfRangeException(nameof(seconds));
            _snakeCircles = snakeCircles ?? throw new ArgumentNullException(nameof(snakeCircles));
        }

        public void Apply()
        {
            Debug.Log("Immortal");
           _snakeCircles.MakeImmortalForSeconds(_seconds);
        }
    }
}
