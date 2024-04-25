using System;
using TextGame;
using System.Text.Json;
using System.Reflection.PortableExecutable;

namespace TextGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // 게임 초기화
            DataLoader dataLoader = new DataLoader();
            
            Player player = new Player();
            ItemList playerItemList = new ItemList();
            ItemList storeItemList = new ItemList();

            /*// 코드로 데이터 넣기
            storeItemList.MakeStoreDataFromCode();
            playerItemList.MakePlayerDataFromCode();
            player.MakeDataFromCode(playerItemList);

            dataLoader.SaveAllDataToJson(player, playerItemList, storeItemList);*/

            // json으로 데이터 넣기
            player = dataLoader.LoadDataFromJson<Player>("playerStat.json");
            playerItemList = dataLoader.LoadDataFromJson<ItemList>("playerItemList.json");
            storeItemList = dataLoader.LoadDataFromJson<ItemList>("storeItemList.json");

            player.Init(playerItemList);
            Store store = new Store(storeItemList);
            // 게임 시작
            Game game = new Game(dataLoader, player, store);
            game.Init();
        }
    }
}
