using UnityEngine;
using System.IO;

namespace Snake.SaveSystem
{
    public sealed class JSONStorage : IStorage
    {
        public bool Exists(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }

        public T Load<T>(string path) 
        {
            if (Exists(path))
            {
                string saveJson = File.ReadAllText(path);
                return JsonUtility.FromJson<T>(saveJson);
            }
            return default;
        }

        public void Save<T>(string path, T saveObject)
        {
            var saveJson = JsonUtility.ToJson(path);
            File.WriteAllText(path, saveJson);
        }
    }
}