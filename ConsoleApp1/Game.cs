using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Game
    {
        public void Init(Player player, Store store)
        {
            this.player = player;
            this.store = store;

            StartPage();
        }

        public void StartPage()
        {
            Console.WriteLine("\n\n스파르타 마을에 오신 여러분 환영합니다.\r\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\r\n\r\n1. 상태 보기\r\n2. 인벤토리\r\n3. 상점\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");

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
            // 잘못된 입력
            else
            {
                ShowWrongCommand();
                StartPage();
            }
        }

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

        public void InventoryEqipPage()
        {
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
                // 장착
                if (player.playerItemList.itemList[commandInt - 1].Equipped == false)
                {
                    player.playerItemList.itemList[commandInt - 1].Equipped = true;
                    player.SetPlayerStat();
                }
                // 장착 해제
                else
                {
                    player.playerItemList.itemList[commandInt - 1].Equipped = false;
                    player.SetPlayerStat();
                }
                InventoryEqipPage();
            }

            // 잘못된 입력
            else
            {
                ShowWrongCommand();
                InventoryEqipPage();
            }
        }

        public void StoreShowPage()
        {
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


        public void StoreBuyPage()
        {
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
                // 일치하는 아이템을 선택했다면 - 이미 구매한 아이템이라면
                if (player.Gold >= store.storeItemList.itemList[commandInt - 1].price
                    && store.storeItemList.itemList[commandInt - 1].isSold == true)
                {
                    Console.Clear();
                    Console.WriteLine("*** 이미 구매한 아이템입니다. ***");
                    Console.SetCursorPosition(0, 0);
                    StoreBuyPage();
                }
                // 일치하는 아이템을 선택했다면 - 구매 가능한 아이템이라면
                else if (player.Gold >= store.storeItemList.itemList[commandInt - 1].price 
                    && store.storeItemList.itemList[commandInt - 1].isSold == false)
                {
                    player.Gold -= store.storeItemList.itemList[commandInt - 1].price;
                    store.storeItemList.itemList[commandInt - 1].isSold = true;
                    Console.Clear();
                    Console.WriteLine("*** 구매를 완료했습니다. ***");
                    Console.SetCursorPosition(0, 0);
                    StoreBuyPage();
                }
                // 골드 부족
                else if (player.Gold < store.storeItemList.itemList[commandInt - 1].price)
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


        public void ShowWrongCommand()
        {
            Console.Clear();
            Console.WriteLine("***잘못된 입력입니다. 다시 입력해주세요.***");
            Console.SetCursorPosition(0, 0);
        }

        Player player;
        Store store;
    }
}
