using Snake.SaveSystem;
using System;

namespace Snake.Model
{
    public sealed class BestScore : IDisposable, ICounter
    {
        private readonly IStorage _storage = new BinaryStorage();
        private const string Key = "Score";
        private readonly Score _score;

        public int Count { get; private set; }

        public BestScore(Score score)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            Count = _storage.Load<int>(Key);
            _score.OnChanged += TryChange;
        }

        private void TryChange(int count)
        {
            if (Count < count)
            {
                Count = count;
                _storage.Save(Key, Count);
            }
        }

        public void Dispose() => _score.OnChanged -= TryChange;

    }
}
