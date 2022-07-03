namespace Snake.Model
{
    public interface ISnakeAbilityVisitor
    {
        public void Visit(SnakeImmortalAbility immortalAbility, IBlock block);

        public void Visit(SnakeHealthAbility healthAbility, IBlock block);

        public void Visit(SnakeNullAbility nullAbility, IBlock block);

    }
}
