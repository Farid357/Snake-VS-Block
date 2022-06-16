using UnityEngine;

namespace Snake.Model
{
    public sealed class Food
    {
        public readonly int Count;

        public Food(int count)
        {
            Count = count;
            Debug.Log(Count);
        }
    }
}