using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.HelperFunctions
{
    public class DisplayWeaponTypes
    {
        public static bool ShowAxes(Hero player)
        {
            Console.WriteLine("(1) Rusted Axe. DMG: 5, LVL 1");
            Console.WriteLine("(2) Fiskars. DMG: 60, LVL 16");
            Console.WriteLine("(3) Back to Menu");

            switch (Console.ReadLine())
            {
                case "1":
                    player.EquipWeapon(new Weapon("Rusted Axe", 5, 1, WeaponType.Axes));
                    Console.WriteLine("You are now using Rusted Axe");
                    return true;
                case "2":
                    player.EquipWeapon(new Weapon("harrys wand", 60, 16, WeaponType.Axes));
                    Console.WriteLine("Did you know? Fiskars can also be used in the kitchen.");
                    return true;

                default: return false;
            }
        }

        public static bool ShowBows(Hero player)
        {
            Console.WriteLine("(1) Mini Bow. DMG: 5, LVL 1");
            Console.WriteLine("(2) RainBow. DMG: 75, LVL 18");
            Console.WriteLine("(3) Back to Menu");

            switch (Console.ReadLine())
            {
                case "1":
                    player.EquipWeapon(new Weapon("Mini Bow", 5, 1, WeaponType.Bows));
                    Console.WriteLine("You are now using Mini Bow");
                    return true;
                case "2":
                    player.EquipWeapon(new Weapon("RainBow", 75, 18, WeaponType.Bows));
                    Console.WriteLine("If you follow the arrow, you might found pot of gold.");
                    return true;

                default: return false;
            }
        }


        public static bool ShowDaggers(Hero player)
        {
            Console.WriteLine("(1) Small Dagger. DMG: 5, LVL 1");
            Console.WriteLine("(2) Swiss Army Knife. DMG: 99, LVL 19");
            Console.WriteLine("(3) Back to Menu");

            switch (Console.ReadLine())
            {
                case "1":
                    player.EquipWeapon(new Weapon("Small Dagger", 5, 1, WeaponType.Daggers));
                    Console.WriteLine("You are now using Rusted Axe");
                    return true;
                case "2":
                    player.EquipWeapon(new Weapon("Swiss Army Dagger", 99, 19, WeaponType.Daggers));
                    Console.WriteLine("Is there anything that this bad boy can't do?");
                    return true;

                default: return false;
            }
        }




    }
}
