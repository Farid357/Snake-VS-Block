using Snake.Tools;
using Snake.Model;
using UnityEngine;
using System.Collections.Generic;
using System;
using Zenject;

namespace Snake.GameLogic
{
    //public sealed class FoodFactory : Factory<FoodView>
    //{
    //    private readonly Vector2 _offset = new(-5, -2f);
    //    private readonly ObjectsPool<FoodView> _pool = new();
    //    private SnakeCircles _snakeCircles;
    //    private FoodView _prefab;

    //    private void Spawn(int count, Vector2 point)
    //    {
    //        for (int i = 0; i < count; i++)
    //        {
    //            point += _offset;
    //            var view = _pool.Get(_prefab);
    //            view.gameObject.SetActive(true);
    //            view.transform.position = point;
    //            var model = new Food(new System.Random().Next(1, 5));
    //            IDisposable presenter = new FoodPresener(model, view, _snakeCircles);
    //        }
    //    }
    //    [Inject]
    //    private void Constructor(SnakeCircles snakeCircles) => _snakeCircles = snakeCircles;

    //    protected override void TrySpawn(out IDisposable presenter)
    //    {
    //        var random = new System.Random();
    //        var randomValue = random.Next(0, 6);
    //        const int doubleFood = 2;

    //        if (randomValue == doubleFood)
    //        {
    //            Spawn(doubleFood, point);
    //        }

    //        else if (randomValue == 5 || randomValue == 4)
    //        {
    //            Spawn(1, point);
    //        }
    //    }
    //    protected override void ResetFactory() => throw new NotImplementedException();
    //}
}