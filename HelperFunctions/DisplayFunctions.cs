using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class DisplayFunctions
    {
        public static bool MainMenu(Hero player)
        { 
            Console.WriteLine("Hello");
            Console.WriteLine("(1) Hero Info:");
            Console.WriteLine("(2) Level Up:");
            Console.WriteLine("(3) Wear Armor:");
            Console.WriteLine("(4) Wear Weapon:");
            Console.WriteLine("(5) Log out: ");

            switch (Console.ReadLine())
            {
                case "1":
                    player.Display();
                    return true;
                case "2":
                    player.LevelUp();
                    return true;
                case "3":
                    Console.WriteLine("TODO");
                    return true;
                case"4":
                    Console.WriteLine("TODO");
                    return true;
                case"5":
                    return false;

                default: return true;
            }

        }


    }
}
