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

        public static string getHeroType()
        {
            Console.WriteLine("Choose your character:");
            Console.WriteLine("Mage (1)");
            Console.WriteLine("Ranger (2)");
            Console.WriteLine("Rogue (3)");
            Console.WriteLine("Warrior (4)");
            if (Console.ReadLine() == "1") 
                return "Mage";
            if (Console.ReadLine() == "2")
                return "Ranger";
            if (Console.ReadLine() == "3")
                return "Rogue";
            if (Console.ReadLine() == "4")
                return "Warrior";
            else
            { 
               
                return "wrong input";
            }
        }
  


    }
}
