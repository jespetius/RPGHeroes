using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.HelperFunctions
{
    public class DisplayWeaponTypes
    {
        /// <summary>
        /// Show Axes and equip wanted weapon
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Show Bows and equip wanted weapon
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Show Daggers and equip wanted weapon
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Show Hammers and equip wanted weapon
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool ShowHammers(Hero player)
        {
            Console.WriteLine("(1) Iron Hammer. DMG: 5, LVL 1");
            Console.WriteLine("(2) Mjölnir. DMG: 130, LVL 17");
            Console.WriteLine("(3) Back to Menu");

            switch (Console.ReadLine())
            {
                case "1":
                    player.EquipWeapon(new Weapon("Iron Hammer", 5, 1, WeaponType.Hammers));
                    Console.WriteLine("You are now using Iron Hammer");
                    return true;
                case "2":
                    player.EquipWeapon(new Weapon("Mjölnir", 130, 17, WeaponType.Hammers));
                    Console.WriteLine("Isn't it heavy?");
                    return true;

                default: return false;
            }
        }
        /// <summary>
        /// Show Staffs and equip wanted weapon
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool ShowStaffs(Hero player)
        {
            Console.WriteLine("(1) Wooden Staff. DMG: 5, LVL 1");
            Console.WriteLine("(2) Gandalf's Stick. DMG: 999, LVL 99");
            Console.WriteLine("(3) Back to Menu");

            switch (Console.ReadLine())
            {
                case "1":
                    player.EquipWeapon(new Weapon("Wooden Staff", 5, 1, WeaponType.Staffs));
                    Console.WriteLine("You are now using Wooden Staff");
                    return true;
                case "2":
                    player.EquipWeapon(new Weapon("Gandalf's Stick", 999, 99, WeaponType.Staffs));
                    Console.WriteLine("YOU SHALL NOT PASS!!!");
                    return true;

                default: return false;
            }
        }
        /// <summary>
        /// Show Swords and equip wanted weapon
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool ShowSwords(Hero player)
        {
            Console.WriteLine("(1) Practice Sword. DMG: 5, LVL 1");
            Console.WriteLine("(2) Excalibur. DMG: 109, LVL 12");
            Console.WriteLine("(3) Back to Menu");

            switch (Console.ReadLine())
            {
                case "1":
                    player.EquipWeapon(new Weapon("Practice Sword", 5, 1, WeaponType.Swords));
                    Console.WriteLine("You are now using Practice Sword");
                    return true;
                case "2":
                    player.EquipWeapon(new Weapon("Excalibur", 109, 12, WeaponType.Swords));
                    Console.WriteLine("Arthur is that you?");
                    return true;

                default: return false;
            }
        }
        /// <summary>
        /// Show Wands and equip wanted weapon
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool ShowWands(Hero player)
        {
            Console.WriteLine("(1) Common Wand. DMG: 5, LVL 1");
            Console.WriteLine("(2) Phoenix Feather Yew Wand. DMG: 89, LVL 9");
            Console.WriteLine("(3) Back to Menu");

            switch (Console.ReadLine())
            {
                case "1":
                    player.EquipWeapon(new Weapon("Common Wand", 5, 1, WeaponType.Wands));
                    Console.WriteLine("You are now using Common Wand");
                    return true;
                case "2":
                    player.EquipWeapon(new Weapon("Phoenix Feather Yew Wand", 89, 9, WeaponType.Wands));
                    Console.WriteLine("The boy who lived should be careful...");
                    return true;

                default: return false;
            }
        }



    }
}
