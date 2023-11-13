using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPGtext.ItemBunddle;

namespace RPGtext
{
    internal class ShopItemsDto
    {
        public List<Item> items = new List<Item>
        {
          new Item {
            name = "다이아몬드 검",
            status = 50,
            price = 2000,
            info = "다이아몬드로 만들어진 강한 검입니다.",
            isEquip = false
        },

        new Item
        {
            name = "암흑 검",
            status = 20,
            price = 1000,
            info = "암흑세계에서 만든 검입니다.",
            isEquip = false
        },

        new Item
        {
            name = "번개 검",
            status = 20,
            price = 1000,
            info = "번개로 만든 검입니다.",
            isEquip = false
        },

        new Item
        {
            name = "BF 대검",
            status = 35,
            price = 5000,
            info = "어디서 본 듯한 대검, 성능은 굉장합니다.",
            isEquip = false
        },

       new Item
        {
            name = "장미 검",
            status = 200,
            price = 10000,
            info = "장미문양이 그려진 검, 출처를 알 수 없지만 강력한 검.",
            isEquip = false
        }
    };

    }
}
