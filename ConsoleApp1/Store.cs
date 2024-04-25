using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Store
    {
        public Store(ItemList storeItemList)
        {
            this.storeItemList = storeItemList;
        }

        public void ShowStoreDefaultItemList()
        {
            foreach (Item item in storeItemList.itemList)
            {
                Console.WriteLine($"- {item.GetAllInfoStore()}");
            }
        }

        public void ShowStoreBuyItemList()
        {
            int index = 1;

            foreach (Item item in storeItemList.itemList)
            {
                Console.WriteLine($"- [{index}] {item.GetAllInfoStore()}");
                index += 1;
            }
        }

        public ItemList storeItemList { get; set; }

    }
}
