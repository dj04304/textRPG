using System.Reflection.Metadata.Ecma335;
using static RPGtext.ICharacterinter;
using static RPGtext.Program;
using static RPGtext.CharacterJob;
using static RPGtext.ItemBunddle;
using ConsoleTables;

namespace RPGtext
{
    internal class Program
    {

        public class Player
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        static void SelectJob(string playerName, out ICharacterinter.ICharacter selectCharacter, Armor armor, Sword sword)
        {
            bool isChoice = false;
            selectCharacter = null;
            Console.Clear();
            Console.WriteLine($"{playerName} 용사님 환영합니다!");

            while (!isChoice)
            {
                Console.WriteLine("직업을 골라주세요");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 궁수");
                Console.WriteLine("3. 마법사");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.ReadLine();

                switch (key.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine("전사를 선택하셨습니다. 아무 키나 눌러 진행해주세요");
                        Console.ReadLine();
                        selectCharacter = new Warrior(playerName, armor, sword);
                        isChoice = true;
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine("궁수를 선택하셨습니다. 아무 키나 눌러 진행해주세요");
                        Console.ReadLine();
                        selectCharacter = new Archer(playerName, armor, sword);
                        isChoice = true;
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.WriteLine("마법사를 선택하셨습니다. 아무 키나 눌러 진행해주세요");
                        Console.ReadLine();
                        selectCharacter = new Magician(playerName, armor, sword);
                        isChoice = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                        break;
                }
            }

        }

        static void CheckCharacter(ref ICharacterinter.ICharacter selectCharacter, Armor armor, Sword sword)
        {
            bool isChoice = false;
            while (!isChoice)
            {

                Console.Clear();
                Console.WriteLine("게임을 시작합니다.");
                Console.WriteLine("게임 시작 전 Status와 인벤토리를 체크하실 수 있습니다.");
                Console.WriteLine("어느것을 하시겠습니까?");
                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine(" ");
                Console.WriteLine("0. 뒤로가기");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.ReadLine();

                switch (key.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine("상태보기로 이동합니다.");
                        isChoice = true;
                        Status(ref selectCharacter, armor, sword);
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine("인벤토리로 이동합니다.");
                        isChoice = true;
                        Inventory(selectCharacter, armor, sword);
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.WriteLine("상점으로 이동합니다..");
                        isChoice = true;
                        Shop();
                        break;
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.D0:
                        Console.WriteLine("뒤로가기.");
                        isChoice = true;
                        SelectJob(selectCharacter.name, out selectCharacter, armor, sword);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                        break;
                }
            }
        }

        static void Status(ref ICharacterinter.ICharacter character, Armor armor, Sword sword)
        {
            bool isBack = false;

            int totalAtkStatus = (character.atk) + ((int)sword.status);
            int totalDefStatus = (character.def) + ((int)armor.status);
            int totalHpStatus = (character.hp) + 0;

            Console.Clear();
            Console.WriteLine("상태보기창 입니다.");
            var table = new ConsoleTable(" ", $"{character.name}", $"{character.job}", " ");
            table.AddRow("스탯", "기본 스탯", "장비 스탯", "총 스탯")
                    .AddRow($"공격력", $"{character.atk}", $"{sword.status}", $"{totalAtkStatus}")
                    .AddRow($"방어력", $"{character.def}", $"{armor.status}", $"{totalDefStatus}")
                    .AddRow($"체력", $"{character.hp}", " 0 ", $"{totalHpStatus}")
                    .AddRow($"소지골드", $"{character.gold}", "", "")
                    .AddRow("무기", "무기이름", "무기스탯", "가격")
                    .AddRow($"장착한 무기", $"{sword.name}", $"{sword.status}", $"{sword.price}")
                    .AddRow($"장착한 방어구", $"{armor.name}", $"{armor.status}", $"{armor.price}")
                    ;


            table.Write();
              

            //Console.WriteLine($"이름: {character.name}");
            //Console.WriteLine($"레벨: {character.level}LV");
            //Console.WriteLine($"직업: {character.job}");
            //if (sword.isEquip)
            //{
            //    //Console.WriteLine($"공격력: {character.atk} + ({(int)sword.status})" 
            //    //        + (character.atk) + ((int)sword.status));
            //    //Console.WriteLine($"방어력: {character.def} + ({(int)armor.status})" 
            //    //        + (character.def) + ((int)armor.status));

            //    Console.WriteLine($"공격력: {character.atk + (int)sword.status}" +
            //        $" / {character.atk} + ({sword.status})");
            //    Console.WriteLine($"방어력: {character.def + (int)armor.status}" +
            //         $" / {character.def} + ({armor.status})");


            //}
            //else
            //{
            //    Console.WriteLine($"공격력: {character.atk}");
            //    Console.WriteLine($"방어력: {character.def}");
            //}
            //Console.WriteLine($"장착한 무기: {sword.name}");
            //Console.WriteLine($"장착한 방어구: {armor.name}");
            //Console.WriteLine($"HP: {character.hp}");
            //Console.WriteLine($"소지골드: {character.gold}");

            Console.WriteLine("0. 나가기");

            ConsoleKeyInfo key = Console.ReadKey();
            Console.ReadLine();

            while (!isBack)
            {
                if (key.Key == ConsoleKey.D0 || key.Key == ConsoleKey.NumPad0)
                {
                    CheckCharacter(ref character, armor, sword);
                }
            }

        }

        static void Inventory(ICharacterinter.ICharacter character, Armor armor, Sword sword)
        {
            bool isChoice = false;

            Console.Clear();
            Console.WriteLine("인벤토리 입니다.");
            Console.WriteLine("1. 무기");
            Console.WriteLine("2. 방어구");

            Console.WriteLine("0. 나가기");

            ConsoleKeyInfo key = Console.ReadKey();
            Console.ReadLine();

            while (!isChoice)
            {
                switch (key.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine("무기 인벤토리로 이동합니다.");
                        SwordInventory(character, armor, sword);
                        isChoice = true;
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine("방어구 인벤토리로 이동합니다.");
                        ArmorInventory(character, armor, sword);
                        isChoice = true;
                        break;
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.D0:
                        Console.WriteLine("나가기.");
                        isChoice = true;
                        CheckCharacter(ref character, armor, sword);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                        break;
                }
            }
        }

        static void SwordInventory(ICharacterinter.ICharacter character, Armor armor, Sword sword)
        {
            bool isChoice = false;
            string userInput = " ";

            //SwordDto swordDto = new SwordDto();
            //List<Sword> swords = swordDto.sword;

            //int index = 1;

            //foreach(Sword newSword in swords)
            //{
            //    Console.WriteLine($"{index}. {newSword.name}, 공격력: {newSword.status}, 가격: {newSword.price}");
            //    index++;
            //}

            //int selectedIndex;
            //if(int.TryParse(Console.ReadLine(), out selectedIndex) && selectedIndex >= 1 && selectedIndex <= swords.Count)
            //{
            //    Console.WriteLine("장착하시겠습니까? (Y/N)");
            //    userInput = Console.ReadLine().ToUpper();
            //    if (userInput == "Y") 
            //    {

            //        swords[selectedIndex - 1].name = "[E]" + swords[selectedIndex - 1].name;
            //        swords[selectedIndex - 1].isEquip = true;
            //        Console.WriteLine("장착되었습니다.");
            //        Console.WriteLine($"{swords[selectedIndex - 1].name}");
            //        Console.WriteLine("아무키나 입력하시면 인벤토리로 이동합니다.");
            //        Console.ReadLine();
            //    }
            //}


            Sword wornSword = new Sword();
            wornSword.SwordInitial("낡은 검", 5, 200, "평범한 낡은 검입니다.", false);
            Sword iceSword = new Sword();
            iceSword.SwordInitial("얼음 검", 10, 500, "얼음으로 만든 검입니다.", false);
            Sword fireSword = new Sword();
            fireSword.SwordInitial("불 검", 10, 500, "불로 만든 검입니다.", false);

            Console.Clear();
            Console.WriteLine("무기 인벤토리입니다.");
            Console.WriteLine("무기 리스트");
            Console.WriteLine($"1.{wornSword.name}");
            Console.WriteLine($"2.{iceSword.name}"); 
            Console.WriteLine($"3.{fireSword.name}");
            Console.WriteLine("장착하실 아이템 번호를 입력해주세요");

            ConsoleKeyInfo key = Console.ReadKey();
            Console.ReadLine();

            while (!isChoice)
            {
                switch (key.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine($"{wornSword.name}, 공격력: {wornSword.status}, 가격: {wornSword.price}, 정보: {wornSword.info}");
                        Console.WriteLine("장착하시겠습니까? (Y/N)");
                        userInput = Console.ReadLine().ToUpper();
                        if (userInput == "Y")
                        {
                            wornSword.SwordInitial("[E]낡은 검", 5, 200, "평범한 낡은 검입니다.", true);
                            Console.WriteLine("장착되었습니다.");
                            Console.WriteLine("아무키나 입력하시면 인벤토리로 이동합니다.");
                            Console.ReadLine();
                            Inventory(character, armor, wornSword);
                            isChoice = true;
                        }
                        else if (userInput == "N")
                        {
                            Console.WriteLine("장착되지 않았습니다. 무기를 다시 선택해주세요");
                            SwordInventory(character, armor, sword);
                            isChoice = true;
                        }
                        else
                        {
                            Console.WriteLine("장착되지 않았습니다 (Y/N)을 눌러주세요");
                            break;
                        }
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine($"{iceSword.name}, 공격력: {iceSword.status}, 가격: {iceSword.price}, 정보: {iceSword.info}");
                        Console.WriteLine("장착하시겠습니까? (Y/N)");
                        userInput = Console.ReadLine().ToUpper();
                        if (userInput == "Y")
                        {
                            iceSword.SwordInitial("[E]얼음 검", 10, 500, "얼음으로 만든 검입니다.", true);
                            Console.WriteLine("장착되었습니다.");
                            Console.WriteLine("아무키나 입력하시면 인벤토리로 이동합니다.");
                            Console.ReadLine();
                            Inventory(character, armor, iceSword);
                            isChoice = true;
                        }
                        else if (userInput == "N")
                        {
                            Console.WriteLine("장착되지 않았습니다. 무기를 다시 선택해주세요");
                            SwordInventory(character, armor, sword);
                            isChoice = true;
                        }
                        else
                        {
                            Console.WriteLine("장착되지 않았습니다");
                            break;
                        }
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.WriteLine($"{fireSword.name}, 공격력: {fireSword.status}, 가격: {fireSword.price}, 정보: {fireSword.info}");
                        Console.WriteLine("장착하시겠습니까? (Y/N)");
                        userInput = Console.ReadLine().ToUpper();
                        if (userInput == "Y")
                        {
                            iceSword.SwordInitial("[E]불 검", 5, 200, "불로 만든 겁입니다.", true);
                            Console.WriteLine("장착되었습니다.");
                            Console.WriteLine("아무키나 입력하시면 인벤토리로 이동합니다.");
                            Console.ReadLine();
                            Inventory(character, armor, fireSword);
                            isChoice = true;
                        }
                        else if (userInput == "N")
                        {
                            Console.WriteLine("장착되지 않았습니다. 무기를 다시 선택해주세요");
                            SwordInventory(character, armor, sword);
                            isChoice = true;
                        }
                        else
                        {
                            Console.WriteLine("장착되지 않았습니다");
                            break;
                        }
                        break;
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.D0:
                        Console.WriteLine("나가기.");
                        CheckCharacter(ref character, armor, sword);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                        SwordInventory(character, armor, sword);
                        isChoice = true;
                        break;
                }
            }

        }

        static void ArmorInventory(ICharacterinter.ICharacter character, Armor armor, Sword sword)
        {
            bool isChoice = false;
            string userInput = " ";

            Armor wornArmor = new Armor();
            wornArmor.ArmorInitial("낡은 방어구", 5, 200, "평범한 낡은 방어구입니다.", false);
            Armor iceArmor = new Armor();
            iceArmor.ArmorInitial("얼음 방어구", 10, 500, "얼음으로 만든 방어구입니다.", false);
            Armor fireArmor = new Armor();
            fireArmor.ArmorInitial("불 방어구", 10, 500, "불로 만든 방어구입니다.", false);

            Console.Clear();
            Console.WriteLine("무기 인벤토리입니다.");
            Console.WriteLine("무기 리스트");
            Console.WriteLine($"1.{wornArmor.name}");
            Console.WriteLine($"2.{iceArmor.name}");
            Console.WriteLine($"3.{fireArmor.name}");
            Console.WriteLine("장착하실 아이템 번호를 입력해주세요");

           
            ConsoleKeyInfo key = Console.ReadKey();
            Console.ReadLine();

            while (!isChoice)
            {
                switch (key.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine($"{wornArmor.name}, 방어력: {wornArmor.status}, 가격: {wornArmor.price}, 정보: {wornArmor.info}");
                        Console.WriteLine("장착하시겠습니까? (Y/N)");
                        userInput = Console.ReadLine().ToUpper();
                        if (userInput == "Y")
                        {
                            wornArmor.ArmorInitial("[E]낡은 방어구", 5, 200, "평범한 낡은 방어구입니다.", true);
                            Console.WriteLine("장착되었습니다.");
                            Console.WriteLine("아무키나 입력하시면 인벤토리로 이동합니다.");
                            Console.ReadLine();
                            Inventory(character, wornArmor, sword);
                            isChoice = true;
                        }
                        else if (userInput == "N")
                        {
                            Console.WriteLine("장착되지 않았습니다. 방어구를 다시 선택해주세요");
                            ArmorInventory(character, armor, sword);
                            isChoice = true;
                        }
                        else
                        {
                            Console.WriteLine("장착되지 않았습니다");
                            break;
                        }
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine($"{iceArmor.name}, 공격력: {iceArmor.status}, 가격: {iceArmor.price}, 정보: {iceArmor.info}");
                        Console.WriteLine("장착하시겠습니까? (Y/N)");
                        userInput = Console.ReadLine().ToUpper();
                        if (userInput == "Y")
                        {
                            iceArmor.ArmorInitial("[E]얼음 방어구", 10, 500, "얼음으로 만든 방어구입니다.", true);
                            Console.WriteLine("장착되었습니다.");
                            Console.WriteLine("아무키나 입력하시면 인벤토리로 이동합니다.");
                            Console.ReadLine();
                            Inventory(character, iceArmor, sword);
                            isChoice = true;
                        }
                        else if (userInput == "N")
                        {
                            Console.WriteLine("장착되지 않았습니다. 방어구를 다시 선택해주세요");
                            ArmorInventory(character, armor, sword);
                            isChoice = true;
                        }
                        else
                        {
                            Console.WriteLine("장착되지 않았습니다");
                            break;
                        }
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.WriteLine($"{fireArmor.name}, 공격력: {fireArmor.status}, 가격: {fireArmor.price}, 정보: {fireArmor.info}");
                        Console.WriteLine("장착하시겠습니까? (Y/N)");
                        userInput = Console.ReadLine().ToUpper();
                        if (userInput == "Y")
                        {
                            fireArmor.ArmorInitial("[E]불 방어구", 5, 200, "불로 만든 방어구입니다.", true);
                            Console.WriteLine("장착되었습니다.");
                            Console.WriteLine("아무키나 입력하시면 인벤토리로 이동합니다.");
                            Console.ReadLine();
                            Inventory(character, fireArmor, sword);
                            isChoice = true;
                        }
                        else if (userInput == "N")
                        {
                            Console.WriteLine("장착되지 않았습니다. 방어구를 다시 선택해주세요");
                            ArmorInventory(character, armor, sword);
                            isChoice = true;
                        }
                        else
                        {
                            Console.WriteLine("장착되지 않았습니다");
                            break;
                        }
                        break;
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.D0:
                        Console.WriteLine("나가기.");
                        CheckCharacter(ref character, armor, sword);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                        ArmorInventory(character, armor, sword);
                        isChoice = true;
                        break;
                }
            }

        }

        static void Shop()
        {
            ShopItemsDto itemsDto = new ShopItemsDto();
            List<Item> itemList = itemsDto.items;

            int index = 1;


            Console.Clear();
            Console.WriteLine("아이템 상점 입니다.");
            Console.WriteLine("아이템을 선택해주세요");
            Console.WriteLine("");

            foreach (Item item in itemList)
            {
                Console.WriteLine($"{index}." + item);
                index++;
            }

            Console.WriteLine("번호를 입력하세요: ");
            int selectedIndex;

            if(int.TryParse(Console.ReadLine(), out selectedIndex) && selectedIndex >= 1 && selectedIndex <= itemList.Count) 
            {
                Item selectShopItem = itemList[selectedIndex - 1];
                Console.WriteLine($"구매한 아이템: {selectShopItem.name}");


                Sword sword = new Sword();
                sword.name = selectShopItem.name;
                sword.price = selectShopItem.price;
                sword.status = selectShopItem.status;
                sword.info = selectShopItem.info;
                sword.isEquip = selectShopItem.isEquip;

                Console.ReadLine();
            }else
            {
                Console.WriteLine("올바르지 않은 번호입니다. ");
            }
         

        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Job job = new Job();
            string playerName = player.Name;
            bool isPlay = false;
            ICharacterinter.ICharacter character = null;
            Armor armor = new Armor();
            Sword sword = new Sword();

            armor.ArmorInitial("기본방어구", 2, 50, "기본 방어구입니다.", true);
            sword.SwordInitial("기본검", 2, 50, "기본 검입니다.", true);

       

            Console.WriteLine("============ 게임 시작 ============");
            Console.WriteLine("마을에 오신 여러분들을 환영합니다");
            Console.WriteLine("던전에 들어가기 전 용사님의 이름을 알려주세요");
            string input = Console.ReadLine();

            while (!isPlay)
            {

                if (!string.IsNullOrEmpty(input))
                {
                    playerName = input;
                    ICharacterinter.ICharacter selectCharacter = null;

                    SelectJob(playerName, out selectCharacter, armor, sword);

                    CheckCharacter(ref selectCharacter, armor, sword);
                }
                else
                {
                    Console.WriteLine("용사님의 이름을 알려주세요!");
                    input = Console.ReadLine();
                }

            }

        }
    }
}