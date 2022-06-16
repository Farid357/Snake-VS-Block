using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class MapPair : MonoBehaviour
    {
        [SerializeField] private List<BlockContext> _blockContexts = new();
        [SerializeField] private float _disableSeconds = 30f;
        [SerializeField] private List<FoodContext> _foodContexts = new();

        [field: SerializeField] public AnimationCurve ChanceCurve { get; private set; }

        public IList<BlockContext> BlockContexts => _blockContexts;
        public IList<FoodContext> FoodContexts => _foodContexts;

        public void Enable() => StartCoroutine(DisablingAfterSeconds(_disableSeconds));

        private IEnumerator DisablingAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            gameObject.SetActive(false);
        }
    }
}
