using System;

namespace Snake.Model
{
    public sealed class Score : ISnakeAbilityVisitor
    {
        private int _count;
        private int _addCount;

        public event Action<int> OnChanged;

        public void Add(int count, IAbility ability)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            _addCount = count;
            Visit((dynamic)ability, null);
            OnChanged?.Invoke(_count);
        }

        public void Visit(SnakeImmortalAbility immortalAbility, IBlock block)
        {
            _count += _addCount * 2;
        }

        public void Visit(SnakeHealthAbility healthAbility, IBlock block)
        {
            _count += _addCount * 3;
        }

        public void Visit(SnakeNullAbility nullAbility, IBlock block)
        {
            _count += _addCount;
        }
    }
}
