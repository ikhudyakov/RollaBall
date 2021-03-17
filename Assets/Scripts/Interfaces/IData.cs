using System.Collections.Generic;

namespace RollABall
{
    public interface IData<T>
    {
        void Save(T data, string path = null);
        void SaveArr(T[] data, string path = null);
        T Load(string path = null);
        Dictionary<string, SavedData> LoadArr(string path = null);
    }
}