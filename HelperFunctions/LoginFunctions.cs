using RPGHeroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class LoginFunctions
    {
        public static string getUsername()
        {
            Console.WriteLine("Welcome Hero to the adventure!");
            Console.WriteLine("What is your name?");
            return Console.ReadLine();




        }

        public static String getHeroType(string userName)
        {
            bool showMenu = true;
            Console.WriteLine("Choose your character:");
            Console.WriteLine("Mage (1)");
            Console.WriteLine("Ranger (2)");
            Console.WriteLine("Rogue (3)");
            Console.WriteLine("Warrior (4)");
            
            switch (Console.ReadLine())
            {
                case "1":
                    Hero mage = new Mage(userName);
                    while (showMenu)
                    {
                        showMenu = DisplayFunctions.MainMenu(mage);
                    }

                    return "Mage";
                case "2":
                    Hero ranger = new Ranger(userName);
                    while (showMenu)
                    {
                        showMenu = DisplayFunctions.MainMenu(ranger);
                    }
                    return "Ranger";
                case "3":
                    Hero rogue = new Rogue(userName);
                    while (showMenu)
                    {
                        showMenu = DisplayFunctions.MainMenu(rogue);
                    }
                    return "Rogue";
                case "4":
                    Hero warrior = new Warrior(userName);
                    while (showMenu)
                    {
                        showMenu = DisplayFunctions.MainMenu(warrior);
                    }
                    return "Warrior";
                   

                default: return "";  

            }

        }
  



    }
}
