using Snake.GameLogic;
using Snake.Model;
using Snake.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Root
{
    public sealed class BlockRoot : MonoBehaviour
    {
        [SerializeField] private BlockFactory _factory;
        [SerializeField] private int _startSpawnCount = 8;

        public void Init(SafeAreaBounds bounds)
        { 
            _factory.Init(bounds, _startSpawnCount);
        }
    }
}
