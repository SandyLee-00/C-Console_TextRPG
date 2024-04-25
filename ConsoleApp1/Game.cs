using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Game
    {
        public Game(DataLoader dataLoader, Player player, Store store)
        {
            this.dataLoader = dataLoader;
            this.player = player;
            this.store = store;
        }

        public void Init()
        {
            StartPage();
        }

        /// <summary>
        /// 1. 게임 시작 화면
        /// </summary>
        public void StartPage()
        {
            Console.WriteLine("\n\n스파르타 마을에 오신 여러분 환영합니다.\r\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\r\n\r\n");
            
            Console.WriteLine("[1] 상태 보기");
            Console.WriteLine("[2] 인벤토리");
            Console.WriteLine("[3] 상점");
            Console.WriteLine("[5] 여관");

            Console.WriteLine("\n원하시는 행동을 입력해주세요.\n>>");

            string command = Console.ReadLine();
            // 상태 보기
            if (command == "1")
            {
                Console.Clear();
                StatusPage();
            }
            // 인벤토리
            else if (command == "2")
            {
                Console.Clear();
                InventoryShowPage();
            }
            // 상점
            else if (command == "3")
            {
                Console.Clear();
                StoreShowPage();
            }
            else if (command == "5")
            {
                Console.Clear();
                HotelRestPage();
            }

            // 잘못된 입력
            else
            {
                ShowWrongCommand();
                StartPage();
            }
        }

        /// <summary>
        /// 2. 상태보기
        /// </summary>
        public void StatusPage()
        {
            Console.WriteLine("\n\n상태 보기\r\n캐릭터의 정보가 표시됩니다.\r\n");

            player.ShowPlayerInfo();

            Console.WriteLine("[0] 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.\r\n>>");

            string command = Console.ReadLine();
            // 게임 시작 화면
            if (command == "0")
            {
                Console.Clear();
                StartPage();
            }
            // 잘못된 입력
            else
            {
                ShowWrongCommand();
                StatusPage();
            }
        }

        /// <summary>
        /// 3. 인벤토리
        /// </summary>
        public void InventoryShowPage()
        {
            Console.WriteLine("\n\n인벤토리\r\n보유 중인 아이템을 관리할 수 있습니다.\r\n\n");
            Console.WriteLine("[아이템 목록]\n");

            // 아이템 목록 출력
            player.ShowInventoryDefaultItemList();

            Console.WriteLine("\n[1] 장착 관리");
            Console.WriteLine("[0] 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.\r\n>>");

            string command = Console.ReadLine();
            // 인벤토리 - 장착 관리
            if (command == "1")
            {
                Console.Clear();
                InventoryEqipPage();
            }
            // 게임 시작 화면
            else if (command == "0")
            {
                Console.Clear();
                StartPage();
            }
            // 잘못된 입력
            else
            {
                ShowWrongCommand();
                InventoryShowPage();
            }
        }

        /// <summary>
        /// 3 - 1. 인벤토리 장착 관리 
        /// 5. 장착 개선
        /// </summary>
        public void InventoryEqipPage()
        {
            dataLoader.SaveAllDataToJson(player, player.playerItemList, store.storeItemList);

            Console.WriteLine("\n\n인벤토리 - 장착 관리\r\n보유 중인 아이템을 관리할 수 있습니다.\r\n\n");
            Console.WriteLine("[아이템 목록]\n");

            // 아이템 목록 출력
            player.ShowInventoryEqipItemList();

            Console.WriteLine("\n[0] 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.\r\n>>");

            int itemCount = player.playerItemList.itemList.Count;
            string command = Console.ReadLine();
            int commandInt = -1;
            // 잘못된 입력 - 문자처리 예외 발생
            try
            {
                commandInt = Convert.ToInt32(command);
            }
            catch (Exception e)
            {
                ShowWrongCommand();
                InventoryEqipPage();
            }
            // 인벤토리
            if (command == "0")
            {
                Console.Clear();
                InventoryShowPage();
            }
            // 아이템 개수 범위 안에 명령어 입력하기
            else if (commandInt > 0 && commandInt <= itemCount)
            {
                Console.Clear();

                Item selectedItem = player.playerItemList.itemList[commandInt - 1];
                player.ChangeEqippedItem(selectedItem);

                player.SetPlayerStat();
                InventoryEqipPage();
            }

            // 잘못된 입력
            else
            {
                ShowWrongCommand();
                InventoryEqipPage();
            }
        }

        /// <summary>
        /// 4. 상점
        /// </summary>
        public void StoreShowPage()
        {
            dataLoader.SaveAllDataToJson(player, player.playerItemList, store.storeItemList);

            Console.WriteLine("\n\n상점\r\n필요한 아이템을 얻을 수 있는 상점입니다.\r\n\n");
            Console.WriteLine("[보유 골드]\n");
            Console.WriteLine($"{player.Gold} G\n");

            Console.WriteLine("[아이템 목록]\n");

            store.ShowStoreDefaultItemList();

            Console.WriteLine("\n[1] 아이템 구매");
            Console.WriteLine("[0] 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.\r\n>>");

            string command = Console.ReadLine();
            // 상점 - 아이템 구매
            if (command == "1")
            {
                Console.Clear();
                StoreBuyPage();
            }
            // 게임 시작 화면
            else if (command == "0")
            {
                Console.Clear();
                StartPage();
            }
            // 잘못된 입력
            else
            {
                ShowWrongCommand();
                StoreShowPage();
            }
        }

        /// <summary>
        /// 4 - 1. 상점 아이템 구매
        /// </summary>
        public void StoreBuyPage()
        {
            dataLoader.SaveAllDataToJson(player, player.playerItemList, store.storeItemList);

            Console.WriteLine("\n\n상점 - 아이템 구매\r\n필요한 아이템을 얻을 수 있는 상점입니다.\r\n\n");
            Console.WriteLine("[보유 골드]\n");
            Console.WriteLine($"{player.Gold} G\n");

            Console.WriteLine("[아이템 목록]\n");

            store.ShowStoreBuyItemList();

            Console.WriteLine("\n[0] 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.\r\n>>");

            int itemCount = store.storeItemList.itemList.Count;
            string command = Console.ReadLine();
            int commandInt = -1;
            // 잘못된 입력 - 문자처리 예외 발생
            try
            {
                commandInt = Convert.ToInt32(command);
            }
            catch (Exception e)
            {
                ShowWrongCommand();
                StoreBuyPage();
            }
            // 상점
            if (command == "0")
            {
                Console.Clear();
                StoreShowPage();
            }
            // 아이템 개수 범위 안에 명령어 입력하기
            else if (commandInt > 0 && commandInt <= itemCount)
            {
                Item selectedItem = store.storeItemList.itemList[commandInt - 1];
                // 일치하는 아이템을 선택했다면 - 이미 구매한 아이템이라면
                if (player.Gold >= selectedItem.Price
                    && selectedItem.IsSold == true)
                {
                    Console.Clear();
                    Console.WriteLine("*** 이미 구매한 아이템입니다. ***");
                    Console.SetCursorPosition(0, 0);
                    StoreBuyPage();
                }
                // 일치하는 아이템을 선택했다면 - 구매 가능한 아이템이라면
                else if (player.Gold >= selectedItem.Price 
                    && selectedItem.IsSold == false)
                {
                    player.Gold -= selectedItem.Price;
                    selectedItem.IsSold = true;
                    player.playerItemList.itemList.Add(selectedItem);
                    Console.Clear();
                    Console.WriteLine("*** 구매를 완료했습니다. ***");
                    Console.SetCursorPosition(0, 0);
                    StoreBuyPage();
                }
                // 골드 부족
                else if (player.Gold < selectedItem.Price)
                {
                    Console.Clear();
                    Console.WriteLine("*** Gold가 부족합니다. ***");
                    Console.SetCursorPosition(0, 0);
                    StoreBuyPage();
                }
            }
            // 잘못된 입력
            else if (commandInt > itemCount)
            {
                ShowWrongCommand();
                StoreBuyPage();
            }
        }

        /// <summary>
        /// 7. 휴식기능 추가
        /// </summary>
        public void HotelRestPage()
        {
            dataLoader.SaveAllDataToJson(player, player.playerItemList, store.storeItemList);

            Console.WriteLine("\n\n휴식하기");
            const int restPrice = 500;
            Console.WriteLine($"{restPrice} G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {player.Gold} G)\n");

            Console.WriteLine("[1] 휴식하기");
            Console.WriteLine("[0] 나가기\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.\r\n>>");

            string command = Console.ReadLine();
            // 휴식하기
            if (command == "1")
            {
                // 보유 금액이 충분하다면
                if (player.Gold >= restPrice)
                {
                    player.Hp = player.MaxHp;
                    player.Gold -= restPrice;
                    Console.Clear();
                    Console.WriteLine("*** 휴식을 완료했습니다. ***");
                    Console.SetCursorPosition(0, 0);
                    HotelRestPage();
                }
                // 보유 금액이 부족하다면
                else
                {
                    Console.Clear();
                    Console.WriteLine("*** Gold가 부족합니다. ***");
                    Console.SetCursorPosition(0, 0);
                    HotelRestPage();
                }
            }
            // 게임 시작 화면
            else if (command == "0")
            {
                Console.Clear();
                StartPage();
            }
            // 잘못된 입력
            else
            {
                ShowWrongCommand();
                HotelRestPage();
            }
        }

        public void ShowWrongCommand()
        {
            Console.Clear();
            Console.WriteLine("***잘못된 입력입니다. 다시 입력해주세요.***");
            Console.SetCursorPosition(0, 0);
        }

        DataLoader dataLoader;
        Player player;
        Store store;
    }
}
