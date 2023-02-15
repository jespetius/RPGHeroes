using RPGHeroes.HelperFunctions;
using RPGHeroes.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class DisplayFunctions
    {
        /// <summary>
        /// Main menu for navigation
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
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
                    WearArmorDisplay(player);
                    return true;
                case"4":
                    ShowWeaponTypes(player);
                    return true;
                case"5":
                    return false;

                default: return true;
            }

        }

        public static bool WearArmorDisplay(Hero player) 
        {
            Console.WriteLine("(1) Head: ");
            Console.WriteLine("(2) Body: ");
            Console.WriteLine("(3) Legs: ");
            Console.WriteLine("(4) Back to Main Menu");

            switch(Console.ReadLine()) 
            { 
                case"1":
                    ArmorListDisplayHead(player);
                    return true;
                case "2":
                    ArmorListDisplayBody(player);
                    return true;
                case "3":
                    ArmorListDisplayLegs(player);
                    return true;


                default : return true;
            }
        }
        /// <summary>
        /// Display possible Headwear and wear wanted Headwear
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool ArmorListDisplayHead(Hero player)
        {
            Console.WriteLine("(1) Cloth Beanie. STR: 0, DEX: 2, INT: 3, LVL 1");
            Console.WriteLine("(2) Leather Mask. STR: 1, DEX: 3, INT: 1, LVL 2");
            Console.WriteLine("(3) Mail Helmet. STR: 7, DEX: 0, INT: 1, LVL 2");
            Console.WriteLine("(4) Plate Helmet. STR: 5, DEX: 5, INT: 5, LVL 5");
            Console.WriteLine("(5) Back to Menu");

            switch (Console.ReadLine())
            {
                case "1":
                    player.EquipArmor(new Armor("Cloth Beanie", 1, EquipmentSlot.Head, ArmorType.Cloth, 0, 2, 3));
                    Console.WriteLine("You just wore beanie");
                    return true;
                case "2":
                    player.EquipArmor(new Armor("Leather Mask", 2, EquipmentSlot.Head, ArmorType.Leather, 1, 3, 1));
                    Console.WriteLine("You just wore Leather Mask");
                    return true;
                case "3":
                    player.EquipArmor(new Armor("Mail Helmet", 2, EquipmentSlot.Head, ArmorType.Mail, 7, 0, 1));
                    Console.WriteLine("You just wore Mail Helmet");
                    return true;
                case "4":
                    player.EquipArmor(new Armor("Plate Helmet", 5, EquipmentSlot.Head, ArmorType.Plate, 5, 5, 5));
                    Console.WriteLine("You just wore Plate Helmet");
                    return true;


                default : return false;
        }



        }
        /// <summary>
        /// Display Body Armors and wear wanted Armor
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool ArmorListDisplayBody(Hero player)
        {
            Console.WriteLine("(1) Cloth Shirt. STR: 0, DEX: 2, INT: 1, LVL 1");
            Console.WriteLine("(2) Leather Jacket. STR: 2, DEX: 2, INT: 1, LVL 2");
            Console.WriteLine("(3) Mail Armor. STR: 5, DEX: 0, INT: 2, LVL 2");
            Console.WriteLine("(4) Plate Armor. STR: 7, DEX: 2, INT: 4, LVL 5");
            Console.WriteLine("(5) Back to Menu");

            switch (Console.ReadLine())
            {
                case "1":
                    player.EquipArmor(new Armor("Cloth Shirt", 1, EquipmentSlot.Body, ArmorType.Cloth, 0, 2, 1));
                    Console.WriteLine("You just wore Cloth Shirt");
                    return true;
                case "2":
                    player.EquipArmor(new Armor("Leather Jacket", 2, EquipmentSlot.Body, ArmorType.Leather, 2, 2, 1));
                    Console.WriteLine("You just wore Leather Jacket");
                    return true;
                case "3":
                    player.EquipArmor(new Armor("Mail Armor", 2, EquipmentSlot.Body, ArmorType.Mail, 5, 0, 2));
                    Console.WriteLine("You just wore Mail Armor");
                    return true;
                case "4":
                    player.EquipArmor(new Armor("Plate Armor", 5, EquipmentSlot.Body, ArmorType.Plate, 7, 2, 4));
                    Console.WriteLine("You just wore Plate Armor");
                    return true;

                default: return false;
            }
        }
        /// <summary>
        /// Display Legs Armor and wear them
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool ArmorListDisplayLegs(Hero player)
        {
            Console.WriteLine("(1) Cloth Pants. STR: 0, DEX: 1, INT: 3, LVL 1");
            Console.WriteLine("(2) Leather Pants. STR: 2, DEX: 2, INT: 2, LVL 2");
            Console.WriteLine("(3) Mail Pants. STR: 4, DEX: 1, INT: 1, LVL 2");
            Console.WriteLine("(4) Plate Pants. STR: 8, DEX: 1, INT: 3, LVL 5");
            Console.WriteLine("(5) Back to Menu");

            switch (Console.ReadLine())
            {
                case "1":
                    player.EquipArmor(new Armor("Cloth Pants", 1, EquipmentSlot.Legs, ArmorType.Cloth, 0, 1, 3));
                    Console.WriteLine("You just wore Cloth Pants");
                    return true;
                case "2":
                    player.EquipArmor(new Armor("Leather Pants", 2, EquipmentSlot.Legs, ArmorType.Leather, 2, 2, 2));
                    Console.WriteLine("You just wore Leather Pants");
                    return true;
                case "3":
                    player.EquipArmor(new Armor("Mail Pants", 2, EquipmentSlot.Legs, ArmorType.Mail, 4, 1, 1));
                    Console.WriteLine("You just wore Mail Pants");
                    return true;
                case "4":
                    player.EquipArmor(new Armor("Plate Pants", 5, EquipmentSlot.Legs, ArmorType.Plate, 8, 1, 3));
                    Console.WriteLine("You just wore Plate Pants");
                    return true;

                default: return false;
            }
        }

        public static bool ShowWeaponTypes(Hero player)
        {
            Console.WriteLine("(1) Axes: ");
            Console.WriteLine("(2) Bows: ");
            Console.WriteLine("(3) Daggers: ");
            Console.WriteLine("(4) Hammers: ");
            Console.WriteLine("(5) Staffs: ");
            Console.WriteLine("(6) Swords: ");
            Console.WriteLine("(7) Wands:");
            Console.WriteLine("(8) Back to Main Menu");

            switch(Console.ReadLine())
            {
                case "1":
                    DisplayWeaponTypes.ShowAxes(player);
                    return true;
                case "2":
                    DisplayWeaponTypes.ShowBows(player);
                    return true;
                case "3":
                    DisplayWeaponTypes.ShowDaggers(player);
                    return true;
                case "4":
                    DisplayWeaponTypes.ShowHammers(player);
                    return true;
                case "5":
                    DisplayWeaponTypes.ShowStaffs(player);
                    return true;
                case "6": 
                    DisplayWeaponTypes.ShowSwords(player);
                    return true;
                case "7": 
                    DisplayWeaponTypes.ShowWands(player);
                    return true;
                default : return false;
            }
        } 

    }
}
