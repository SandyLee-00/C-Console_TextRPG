using System;
using TextGame;
using System.Text.Json;

namespace TextGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // 객체 생성
            Game game = new Game();
            Player player = new Player();
            Store store = new Store();
            ItemList playerItemList = new ItemList();
            ItemList storeItemList = new ItemList();

            // 데이터 초기화
            playerItemList.InitPlayerItems();
            storeItemList.InitStoreItems();

            player.Init(playerItemList);
            store.Init(storeItemList);

            string dataPath = "../../../../Data/";
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

            string playerStatFileName = dataPath + "playerStat.json";
            string jsonString = JsonSerializer.Serialize(player, options);
            File.WriteAllText(playerStatFileName, jsonString);

            game.Init(player, store);

            

        }
    }
}
