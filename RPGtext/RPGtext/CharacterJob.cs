using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPGtext.ItemBunddle;

namespace RPGtext
{
    internal class CharacterJob
    {
        public class Job : ICharacterinter.ICharacter
        {
            public int level { get; set; }
            public string name { get; set; }
            public string job { get; set; }
            public string sword { get; set; }
            public string armor { get; set; }
            public int atk { get; set; }
            public int def { get; set; }
            public int hp { get; set; }
            public int gold { get; set; }
        }

        public class Warrior : Job
        {
            public Warrior(string playerName, Armor armor, Sword sword)
            {
                this.job = "전사";
                this.name = playerName;
                this.level = 1;
                this.sword = sword.name;
                this.armor = armor.name;
                this.atk = 5;
                this.def = 7;
                this.hp = 200;
                this.gold = 1500;
            }
        }

        public class Archer : Job
        {
            public Archer(string playerName, Armor armor, Sword sword)
            {
                this.job = "궁수";
                this.name = playerName;
                this.level = 1;
                this.sword = sword.name;
                this.armor = armor.name;
                this.atk = 15;
                this.def = 5;
                this.hp = 100;
                this.gold = 1500;
            }
        }

        public class Magician : Job
        {
            public Magician(string playerName, Armor armor, Sword sword)
            {
                this.job = "마법사";
                this.name = playerName;
                this.level = 1;
                this.sword = sword.name;
                this.armor = armor.name;
                this.atk = 10;
                this.def = 5;
                this.hp = 150;
                this.gold = 1500;
            }
        }
    }
}
