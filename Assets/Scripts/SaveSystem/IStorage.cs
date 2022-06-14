namespace Snake.SaveSystem
{
    public interface IStorage
    {
        public T Load<T>(string key);
        public void Save<T>(string key, T saveObject);
        public bool Exists(string path);
    }
    public interface IDeletable
    {
        public void Delete(string path);
    }
}