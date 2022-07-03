namespace Snake.Model
{
    public sealed class BlockDamagePolicy : ISnakeAbilityVisitor
    {
        private readonly SnakeCircles _snakeCircles;
        private readonly int _damage;

        public BlockDamagePolicy(SnakeCircles snakeCircles, int damage)
        {
            _snakeCircles = snakeCircles ?? throw new System.ArgumentNullException(nameof(snakeCircles));
            _damage = damage;
        }

        public void Visit(SnakeImmortalAbility immortalAbility, IBlock block) => block.Kill();

        public void Visit(SnakeHealthAbility healthAbility, IBlock block)
        {
            _snakeCircles.Add(_damage);
            block.TakeDamage(_damage);
        }

        public void Visit(SnakeNullAbility nullAbility, IBlock block)
        {
        }
    }
}
