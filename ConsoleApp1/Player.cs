using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Player
    {
        /// <summary>
        /// 아이템 리스트 받아오기 / weapon, armor 장착
        /// </summary>
        /// <param name="playerItemList"></param>
        public void Init(ItemList playerItemList)
        {
            this.playerItemList = playerItemList;

            foreach (Item item in playerItemList.itemList)
            {
                if (item.IsEquipped)
                {
                    if (item.ItemType == ItemType.Weapon)
                    {
                        EquippedWeapon = item;
                    }
                    else if (item.ItemType == ItemType.Armor)
                    {
                        EquippedArmor = item;
                    }
                }
            }
        }

        /// <summary>
        /// json 안 쓸 떄 처음 데이터 넣기
        /// </summary>
        /// <param name="playerItemList"></param>
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

        /// <summary>
        /// 인벤토리
        /// </summary>
        public void ShowInventoryDefaultItemList()
        {
            foreach (Item item in playerItemList.itemList)
            {
                Console.WriteLine($"- {item.GetAllInfoInventory()}");
            }
        }

        /// <summary>
        /// 장착 관리 
        /// </summary>
        public void ShowInventoryEqipItemList()
        {
            int index = 1;

            foreach (Item item in playerItemList.itemList)
            {
                Console.WriteLine($"- [{index}] {item.GetAllInfoInventory()}");
                index += 1;
            }
        }

        /// <summary>
        /// 플레이어 정보 출력
        /// </summary>
        public void ShowPlayerInfo()
        {
            Console.WriteLine(GetAllPlayerInfo());
        }

        /// <summary>
        /// 플레이어 정보 string으로 반환
        /// </summary>
        /// <returns></returns>
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
                if (item.IsEquipped)
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

        /// <summary>
        /// 장착 아이템의 스탯을 플레이어 스탯에 반영
        /// </summary>
        public void SetPlayerStat()
        {
            foreach (Item item in playerItemList.itemList)
            {
                if (item.IsEquipped)
                {
                    Attack += item.AddAttackStat;
                    Defense += item.AddDefenseStat;
                    MaxHp += item.AddMaxHpStat;
                }
            }
        }

        /// <summary>
        /// 장착 개선 - - 각 타입별로 하나의 아이템만 장착가능 - ( 방어구 / 무기 ) - 방어구를 장착하면 기존 방어구가 있다면 해제하고 장착 - 무기를 장착하면 기존 무기가 있다면 해제하고 장착
        /// </summary>
        /// <param name="selectedItem"></param>
        public void ChangeEqippedItem(Item selectedItem)
        {
            ItemType selectedItemType = selectedItem.ItemType;

            // 선택한 아이템 Weapon
            if (selectedItemType == ItemType.Weapon)
            {
                // 장착하고 있는 아이템이 없다면
                if (EquippedWeapon == null)
                {
                    EquippedWeapon = selectedItem;
                    EquippedWeapon.IsEquipped = true;
                    Console.WriteLine($"*** {EquippedWeapon.Name} 무기를 장착했습니다. ***");
                }
                // 기존에 장착하고 있던 아이템과 동일
                else if (EquippedWeapon == selectedItem)
                {
                    EquippedWeapon.IsEquipped = false;
                    EquippedWeapon = null;
                    Console.WriteLine($"*** {selectedItem.Name} 무기 장착을 해제했습니다. ***");
                }
                // 다른 아이템 장착
                else
                {
                    EquippedWeapon.IsEquipped = false;
                    EquippedWeapon = selectedItem;
                    EquippedWeapon.IsEquipped = true;
                    Console.WriteLine($"*** {EquippedWeapon.Name} 무기를 장착했습니다. ***");
                }
            }
            // 선택한 아이템 Armor
            else if (selectedItemType == ItemType.Armor)
            {
                // 장착하고 있는 아이템이 없다면
                if (EquippedArmor == null)
                {
                    EquippedArmor = selectedItem;
                    EquippedArmor.IsEquipped = true;
                    Console.WriteLine($"*** {EquippedArmor.Name} 방어구를 장착했습니다. ***");
                }
                // 기존에 장착하고 있던 아이템과 동일
                else if (EquippedArmor == selectedItem)
                {
                    EquippedArmor.IsEquipped = false;
                    EquippedArmor = null;
                    Console.WriteLine($"*** {selectedItem.Name} 방어구 장착을 해제했습니다. ***");
                }
                // 다른 아이템 장착
                else
                {
                    EquippedArmor.IsEquipped = false;
                    EquippedArmor = selectedItem;
                    EquippedArmor.IsEquipped = true;
                    Console.WriteLine($"*** {EquippedArmor.Name} 방어구를 장착했습니다. ***");
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

        public Item? EquippedWeapon { get; set; }
        public Item? EquippedArmor { get; set; }

        public ItemList playerItemList { get; set; }
    }

}
