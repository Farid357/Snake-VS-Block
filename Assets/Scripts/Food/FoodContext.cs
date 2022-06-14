using UnityEngine;

namespace Snake.GameLogic
{
    public class FoodContext : MonoBehaviour
    {
        [field: SerializeField, Min(1)] public int Value { get; private set; }
        [field: SerializeField] public FoodView View { get; private set; }
    }
}
