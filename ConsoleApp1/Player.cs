using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Player
    {
        public void Init(ItemList playerItemList)
        {
            this.playerItemList = playerItemList;
        }

        public void MakeDataFromCode(ItemList playerItemList)
        {
            this.Level = 1;
            this.Name = "이서영";
            this.Role = Role.Warrior;
            this.Attack = 10;
            this.Defense = 5;
            this.Hp = 50;
            this.MaxHp = 50;
            this.Gold = 10000;

            this.playerItemList = playerItemList;
        }

        // 인벤토리
        public void ShowInventoryDefaultItemList()
        {
            foreach (Item item in playerItemList.itemList)
            {
                Console.WriteLine($"- {item.GetAllInfoInventory()}");
            }
        }

        // 장착 관리 
        public void ShowInventoryEqipItemList()
        {
            int index = 1;

            foreach (Item item in playerItemList.itemList)
            {
                Console.WriteLine($"- [{index}] {item.GetAllInfoInventory()}");
                index += 1;
            }
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine(GetAllPlayerInfo());
        }

        public string GetAllPlayerInfo()
        {
            string ret = "";

            ret += $"Lv. {Level}\n";
            string role = "";
            if (Role == Role.Warrior)
            {
                role = "전사";
            }
            else if (Role == Role.Mage)
            {
                role = "마법사";
            }
            else if (Role == Role.Archer)
            {
                role = "궁수";
            }
            ret += $"{Name} ( {role} )\n";

            int addedAttack = 0;
            int addedDefense = 0;
            int addedMaxHp = 0;

            foreach (Item item in playerItemList.itemList)
            {
                if (item.Equipped)
                {
                    addedAttack += item.AddAttackStat;
                    addedDefense += item.AddDefenseStat;
                    addedMaxHp += item.AddMaxHpStat;
                }
            }

            ret += $"공격력 : {Attack}";
            if (addedAttack != 0)
            {
                ret += $" + ({addedAttack})";
            }

            ret += $"\n방어력 : {Defense}";
            if (addedDefense != 0)
            {
                ret += $" + ({addedDefense})";
            }

            ret += $"\n체력 : {Hp} / {MaxHp}";
            if (addedMaxHp != 0)
            {
                ret += $" (+{addedMaxHp})";
            }

            ret += $"\nGold : {Gold} G\n";

            return ret;
        }

        // 장착 아이템의 스탯을 플레이어 스탯에 반영
        public void SetPlayerStat()
        {
            foreach (Item item in playerItemList.itemList)
            {
                if (item.Equipped)
                {
                    Attack += item.AddAttackStat;
                    Defense += item.AddDefenseStat;
                    MaxHp += item.AddMaxHpStat;
                }
            }
        }

        public int Level { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Gold { get; set; }

        public ItemList playerItemList { get; set; }
    }

}
