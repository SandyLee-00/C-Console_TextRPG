using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Item
    {
        public int Id { get; set; } = -1;
        public bool IsEquipped { get; set; } = false;
        public string Name { get; set; } = "무기";
        public int AddAttackStat { get; set; } = 0;
        public int AddDefenseStat { get; set; } = 0;
        public int AddMaxHpStat { get; set; } = 0;
        public string Description { get; set; } = "무기입니다.";
        public int Price { get; set; } = 0;
        public bool IsSold { get; set; } = false;
        public ItemType ItemType { get; set; } = ItemType.Weapon;

        private string GetStatInfo()
        {
            string retStat = "";

            if (AddAttackStat > 0)
            {
                retStat += $"공격력 +{AddAttackStat} ";
            }
            if (AddDefenseStat > 0)
            {
                retStat += $"방어력 +{AddDefenseStat} ";
            }
            if (AddMaxHpStat > 0)
            {
                retStat += $"최대 체력 +{AddMaxHpStat} ";
            }

            return retStat;
        }

        public string GetAllInfoInventory()
        {
            string ret = "";
            if (IsEquipped)
            {
                ret += "[E]";
            }
            else
            {
                ret += "";
            }
            ret += $"{Name} | {GetStatInfo()} | {Description}";

            return ret;
        }

        private string GetPriceInfo()
        {
            if (IsSold)
            {
                return "구매완료";
            }
            else
            {
                return $"{Price} G";
            }
        }

        public string GetAllInfoStore()
        {
            string ret = "";
            ret += $"{Name} | {GetStatInfo()} | {Description} | {GetPriceInfo()} G";
            
            return ret;
        }

    }
}
