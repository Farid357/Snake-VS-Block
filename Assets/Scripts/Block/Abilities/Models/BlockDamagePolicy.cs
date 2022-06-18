namespace Snake.Model
{
    public sealed class BlockDamagePolicy
    {
        private readonly SnakeCircles _snakeCircles;

        public BlockDamagePolicy(SnakeCircles snakeCircles) => _snakeCircles = snakeCircles;

        public void TakeDamage(in IBlock block, in IAbility ability, in int damage)
        {
            if (ability is SnakeImmortalAbility)
            {
                TakeDamage(block);
                return;
            }

            if (ability is SnakeHealthAbility)
            {
                TakeDamage(block, damage);
                return;
            }

            throw new System.InvalidOperationException($"Type {ability.GetType()} not added!");
        }

        private void TakeDamage(in IBlock block)
        {
            block.Kill();
        }

        private void TakeDamage(in IBlock block, in int damage)
        {
            _snakeCircles.Add(damage);
            block.TakeDamage(damage);
        }
    }
}
