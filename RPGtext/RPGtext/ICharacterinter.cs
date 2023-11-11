using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGtext
{
    internal class ICharacterinter
    {
        public interface ICharacter
        {
            int level { get; }
            string name { get; set; }
            string job { get; set; }
            string sword { get; set; }
            string armor { get; set; }
            int atk { get; }
            int def { get; }
            int hp { get; }
            int gold { get; }

        }
    }
}
