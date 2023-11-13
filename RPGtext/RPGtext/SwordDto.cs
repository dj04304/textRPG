using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPGtext.ItemBunddle;

namespace RPGtext
{
    internal class SwordDto
    {
        public List<Sword> sword = new List<Sword>
        {
            new Sword
            {
                name = "낡은 검",
                status = 5,
                price = 200,
                info = "평범한 낡은 검입니다."
            },
              new Sword
            {
                name = "얼음 검",
                status = 10,
                price = 500,
                info = "얼음으로 만든 검입니다."
            },
             new Sword
            {
                name = "불 검",
                status = 10,
                price = 200,
                info = "불로 만든 검입니다."
            }

        };

    }
}
