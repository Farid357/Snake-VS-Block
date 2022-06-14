using UnityEngine;

namespace Snake.SaveSystem
{
    public sealed class PlayerPrefsStorage : IStorage
    {
        public bool Exists(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public T Load<T>(string key)
        {
            if (Exists(key))
            {
                string loadJson = PlayerPrefs.GetString(key);
                return JsonUtility.FromJson<T>(loadJson);
            }
            return default;
        }

        public void Save<T>(string key, T saveObject)
        {
            var saveJson = JsonUtility.ToJson(saveObject);
            PlayerPrefs.SetString(key, saveJson);
            PlayerPrefs.Save();
        }
    }
}
