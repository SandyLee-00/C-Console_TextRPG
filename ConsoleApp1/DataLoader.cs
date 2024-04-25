using System.Text.Json;

namespace TextGame
{
    public class DataLoader
    {
        public DataLoader()
        {
            dataPath = "../../../../Data/";
            options = new JsonSerializerOptions { WriteIndented = true };
        }

        public T LoadDataFromJson<T>(string fileName)
        {
            string filePath = dataPath + fileName;
            string jsonString = File.ReadAllText(filePath);
            T objectByData = JsonSerializer.Deserialize<T>(jsonString);
            return objectByData;
        }

        public void SaveDataToJson<T>(T objectToWrite, string fileName)
        {
            string filePath = dataPath + fileName;
            string jsonString = JsonSerializer.Serialize(objectToWrite, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void SaveAllDataToJson(Player player, ItemList playerItemList, ItemList storeItemList)
        {
            SaveDataToJson(player, "playerStat.json");
            SaveDataToJson(playerItemList, "playerItemList.json");
            SaveDataToJson(storeItemList, "storeItemList.json");
        }

        string dataPath;
        JsonSerializerOptions options;
    }
}
