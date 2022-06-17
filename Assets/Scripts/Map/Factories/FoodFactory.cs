using Snake.Model;

namespace Snake.GameLogic
{
    public sealed class FoodFactory
    {
        public IDisposable Spawn(FoodContext food, SnakeCircles snakeCircles)
        {
            var model = new Food(food.Value);
            IDisposable presenter = new FoodPresener(model, food.View, snakeCircles);
            food.gameObject.SetActive(true);
            return presenter;
        }
    }
}