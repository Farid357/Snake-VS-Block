using Snake.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class RandomMapPairGenerator
    {
        private readonly IEnumerable<MapPair> _pairs;
        private IEnumerable<float> _chances;
        private readonly ICounter _snakeCircles;

        public RandomMapPairGenerator(IEnumerable<MapPair> pairs, ICounter snakeCircles)
        {
            _snakeCircles = snakeCircles ?? throw new System.ArgumentNullException(nameof(snakeCircles));
            _pairs = pairs ?? throw new System.ArgumentNullException(nameof(pairs));
        }

        private IEnumerable<float> CreateChances()
        {
            for (int i = 0; i < _pairs.Count(); i++)
            {
                float chance = GetChance(_pairs.ElementAt(i));
                yield return chance;
            }
        }

        public MapPair CreateRandomMapPair()
        {
            _chances = CreateChances();
            var sum = _chances.Sum();
            var dropChance = Random.Range(0, sum);
            var value = 0f;

            for (int i = 0; i < _chances.Count(); i++)
            {
                value += _chances.ElementAt(i);

                if (dropChance <= value)
                {
                    return _pairs.ElementAt(i);
                }
            }
            var last = _pairs.Count() - 1;
            return _pairs.ElementAt(last);
        }

        private float GetChance(MapPair pair)
        {
            return pair.ChanceCurve.Evaluate(_snakeCircles.Count);
        }
    }
}
