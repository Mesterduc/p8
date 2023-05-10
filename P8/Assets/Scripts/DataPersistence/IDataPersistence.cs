using DataStore;

namespace DataPersistence {
    // Implements interface for other classes to use
    public interface IDataPersistence {
        void LoadData(GameData data);
        void SaveData(GameData data);
    }
}