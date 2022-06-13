using UnityEngine;

namespace Snake.GameLogic
{
    public sealed class ExclamationPointAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private readonly int _id = Animator.StringToHash("ExclamanationPoint");

        public void TryPlay(int count)
        {
            if (count == 1)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }

        private void Play()
        {
            gameObject.SetActive(true);
            _animator.Play(_id);
        }

        private void Stop() => gameObject.SetActive(false);
    }
}
