using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class BlockContext : MonoBehaviour
    {
        [field: SerializeField] public BlockCollision Collision { get; private set; }
        [field: SerializeField] public float Diameter { get; private set; } = -1.46f;
        [field: SerializeField] public BlockView View { get; private set; }
        [field: SerializeField] public BlockType Type { get; private set; }
        [field: SerializeField] public int Health { get; private set; }

        [field: SerializeField] public float AbilitySeconds { get; private set; }
    }

    public enum BlockType
    {
        Standart,
        WithImmortalAbiity
    }
}
