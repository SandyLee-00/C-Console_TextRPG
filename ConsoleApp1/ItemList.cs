using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class ItemList
    {
        public List<Item> itemList { get; set; } = new List<Item>();

        public void MakeStoreDataFromCode()
        {
            Item item1 = new Item();
            item1.Id = 1;
            item1.Name = "수련자 갑옷";
            item1.AddDefenseStat = 5;
            item1.Description = "수련에 도움을 주는 갑옷입니다.";
            item1.Price = 1000;
            item1.ItemType = ItemType.Armor;
            itemList.Add(item1);

            Item item2 = new Item();
            item2.Id = 2;
            item2.Name = "무쇠갑옷";
            item2.AddDefenseStat = 9;
            item2.Description = "무쇠로 만들어져 튼튼한 갑옷입니다.";
            item2.IsSold = true;
            item2.ItemType = ItemType.Armor;
            itemList.Add(item2);

            Item item3 = new Item();
            item3.Id = 3;
            item3.Name = "스파르타의 갑옷";
            item3.AddDefenseStat = 15;
            item3.Description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.";
            item3.Price = 3500;
            item3.ItemType = ItemType.Armor;
            itemList.Add(item3);

            Item item4 = new Item();
            item4.Id = 4;
            item4.Name = "낡은 검";
            item4.AddAttackStat = 2;
            item4.Description = "쉽게 볼 수 있는 낡은 검 입니다.";
            item4.Price = 600;
            item4.ItemType = ItemType.Weapon;
            itemList.Add(item4);

            Item item5 = new Item();
            item5.Id = 5;
            item5.Name = "청동 도끼";
            item5.AddAttackStat = 5;
            item5.Description = "어디선가 사용됐던거 같은 도끼입니다.";
            item5.Price = 1500;
            item5.ItemType = ItemType.Weapon;
            itemList.Add(item5);

            Item item6 = new Item();
            item6.Id = 6;
            item6.Name = "스파르타의 창";
            item6.AddAttackStat = 7;
            item6.Description = "스파르타의 전사들이 사용했다는 전설의 창입니다.";
            item6.IsSold = true;
            item6.ItemType = ItemType.Weapon;
            itemList.Add(item6);
        }

        public void MakePlayerDataFromCode()
        {
            Item item1 = new Item();
            item1.Id = 1;
            item1.Name = "무쇠갑옷";
            item1.AddDefenseStat = 5;
            item1.IsEquipped = true;
            item1.Description = "무쇠로 만들어져 튼튼한 갑옷입니다.";
            item1.ItemType = ItemType.Armor;
            itemList.Add(item1);

            Item item2 = new Item();
            item2.Id = 2;
            item2.Name = "스파르타의 창";
            item2.AddAttackStat = 7;
            item2.IsEquipped = true;
            item2.Description = "스파르타의 전사들이 사용했다는 전설의 창입니다.";
            item2.ItemType = ItemType.Weapon;
            itemList.Add(item2);

            Item item3 = new Item();
            item3.Id = 3;
            item3.Name = "낡은 검";
            item3.AddAttackStat = 2;
            item3.Description = "쉽게 볼 수 있는 낡은 검 입니다.";
            item3.ItemType = ItemType.Weapon;
            itemList.Add(item3);
        }
    }
}
