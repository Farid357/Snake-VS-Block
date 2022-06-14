using System;
using UnityEngine;

namespace Snake.Input
{
    public interface IInput
    {
        public event Action<Vector2> OnChangedDelta;
    }
}
