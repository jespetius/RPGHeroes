using RPGHeroes.Inventory;

namespace RPGHeroes
{


    class Program
    {
        static void Main(string[] args)
        {
           
            string userName = "";
            int userChoise = 0;
            int heroClass = 0;
            while (userName == "")
            {
              userName = LoginFunctions.getUsername();
            }

            while (true)
            {
                userChoise = LoginFunctions.getHeroType();
                if (userChoise>0 && userChoise <= 4) 
                {
                    heroClass = userChoise;
                    if (heroClass == 1)
                    {
                        Hero currentPlayer = new Mage(userName);
                        break;
                    }
                    if (heroClass == 2)
                    {
                        Hero currentPlayer = new Ranger(userName);
                        Console.WriteLine("Mage was created");
                        break;
                    }
                    if (heroClass == 3)
                    {
                        Hero currentPlayer = new Rogue(userName);
                        Console.WriteLine("Mage was created");
                        break;
                    }
                    if (heroClass == 4)
                    {
                        Hero currentPlayer = new Warrior(userName);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("kääkkääk");
                    }

                }
                else 
                {
                    Console.WriteLine("KÄÄK");
                }
            }
            

            Hero Testman = new Mage("Test Man");
            Testman.Display();
            Testman.LevelUp();
            Testman.EquipWeapon(new Weapon("harrys wand", 12, 1, WeaponType.Wands));
            Testman.EquipArmor(new Armor("Suoja", 1, EquipmentSlot.Head));
            Testman.Display();
            
            //LoginFunctions.createUser(1, userName);
       
            
     

        }
    }
}