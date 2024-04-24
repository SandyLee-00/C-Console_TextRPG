using System;
using TextGame;

class Program
{
    static void Main(string[] args)
    {

        // TODO : DataLoader를 이용하여 데이터를 불러오고, Player와 Store를 초기화합니다. 나중에 하기
        /*DataLoader dataLoader = new DataLoader();
        dataLoader.LoadData(); */

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

        game.Init(player, store);

    }
}