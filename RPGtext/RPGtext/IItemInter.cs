using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGtext
{
    internal interface IItemInter
    {
        public string name { get; set; }
        public int status { get; set; }
        public int price { get; set; }
        public string info { get; set; }
        public bool isEquip { get; set; }

    }
}
