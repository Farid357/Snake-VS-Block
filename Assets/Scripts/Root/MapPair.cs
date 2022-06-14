using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class MapPair : MonoBehaviour
    {
        [SerializeField] private List<BlockContext> _contexts = new();
        [SerializeField] private float _destroySeconds = 15f;

        [field: SerializeField] public AnimationCurve ChanceCurve { get; private set; }

        public IList<BlockContext> Contexts => _contexts;

        public void Enable()
        {
            Destroy(gameObject, _destroySeconds);
        }
    }
}
