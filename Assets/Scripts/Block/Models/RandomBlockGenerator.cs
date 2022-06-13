using Snake.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class RandomBlockGenerator
    {
        private readonly IEnumerable<BlockContext> _contexts;
        private readonly IEnumerable<float> _chances;
        private IBlock[] _blocks;
        private readonly SnakeCircles _snakeCircles;
        private readonly int _snakeCirclesCount;
        private float _seconds = 5.5f;

        public RandomBlockGenerator(IEnumerable<BlockContext> contexts, int snakeCirclesCount, SnakeCircles snakeCircles)
        {
            _snakeCirclesCount = snakeCirclesCount;
            _contexts = contexts ?? throw new System.ArgumentNullException(nameof(contexts));
            _snakeCircles = snakeCircles;
            _chances = CreateChances();
        }

        private IEnumerable<float> CreateChances()
        {
            for (int i = 0; i < _contexts.Count(); i++)
            {
                float chance = GetChance(_contexts.ElementAt(i));
                yield return chance;
            }
        }

        public IBlock CreateBlock()
        {
            _blocks = new IBlock[]
            {
             new BlockHealth(Random.Range(1, 5)),
             new BonusBlock(new SnakeImmortalAbility(_snakeCircles, _seconds), Random.Range(1, 5))
            };
            var sum = _chances.Sum();
            var dropChance = Random.Range(0, sum);
            var value = 0f;

            for (int i = 0; i < _chances.Count(); i++)
            {
                value += _chances.ElementAt(i);

                if (dropChance <= value)
                {
                    return _blocks[i];
                }
            }
            var last = _blocks.Length - 1;
            return _blocks[last];
        }

        private float GetChance(BlockContext context)
        {
            return context.ChanceCurve.Evaluate(_snakeCirclesCount);
        }
    }
}
