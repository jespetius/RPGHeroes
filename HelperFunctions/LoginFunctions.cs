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

        public static int getHeroType()
        {
            Console.WriteLine("Choose your character:");
            Console.WriteLine("Mage (1)");
            Console.WriteLine("Ranger (2)");
            Console.WriteLine("Rogue (3)");
            Console.WriteLine("Warrior (4)");
            return Int32.Parse(Console.ReadLine()!);
        }
  
        public void createUser( int heroClass, string username) 
        {
            if (heroClass == 1)
            {
                Hero currentPlayer = new Mage(username);
                Console.WriteLine( username + "Mage was created");
            }
            if (heroClass == 2)
            {
                Hero currentPlayer = new Ranger(username);
                Console.WriteLine("Mage was created");
            }
            if (heroClass== 3) 
            {
                Hero currentPlayer = new Rogue(username);
                Console.WriteLine("Mage was created");
            }
            if (heroClass == 4)
            {
                Hero currentPlayer = new Warrior(username);
            }
            else
            {
                Console.WriteLine(heroClass + username);
            }
        }



    }
}
