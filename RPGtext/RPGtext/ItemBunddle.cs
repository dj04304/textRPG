using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGtext
{
    internal class ItemBunddle
    {
        public class Item : IItemInter
        {
            public string name { get; set; }
            public int status { get; set; }
            public int price { get; set; }
            public string info { get; set; }
            public bool isEquip { get; set; }

            public override string ToString()
            {
                return $"이름: {name}, 상태: {status}, 가격: {price}, 정보: {info}";
            }

        }

        public class Sword : Item
        {
        
            public void SwordInitial(string name, int status, int price, string info, bool isEquip)
            {
                this.name = name;
                this.status = status;
                this.price = price;
                this.info = info;
                this.isEquip = isEquip;
            }

        }

        public class Armor : Item
        {
            public void ArmorInitial(string name, int status, int price, string info, bool isEquip)
            {
                this.name = name;
                this.status = status;
                this.price = price;
                this.info = info;
                this.isEquip = isEquip;
            }
        }

    }
}
