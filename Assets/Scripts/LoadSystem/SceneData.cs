using UnityEditor;
using UnityEngine;

namespace Snake.LoadSystem
{
    [CreateAssetMenu(fileName = "Scene", menuName = "Create/ Scene data")]
    public sealed class SceneData : ScriptableObject, ISerializationCallbackReceiver
    {
        public string Name => _sceneName;
#if UNITY_EDITOR

        [SerializeField] private SceneAsset _scene;
#endif
        [SerializeField] private string _sceneName;

        public void OnAfterDeserialize()
        {

        }

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            if (_scene != null)
                _sceneName = _scene.name;
#endif
        }
    }
}
