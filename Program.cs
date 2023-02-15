using RPGHeroes.Inventory;

namespace RPGHeroes
{


    public class Program
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
            

            Hero Testman = new Mage("Test Man");
            Testman.EquipWeapon(new Weapon("harrys wand", 100, 1, WeaponType.Wands));
            Testman.EquipArmor(new Armor("Suoja", 1, EquipmentSlot.Head, ArmorType.Cloth, 10, 0, 0));
            Testman.EquipArmor(new Armor("Beanie", 1, EquipmentSlot.Head, ArmorType.Cloth, 1, 2, 4));
            Testman.EquipArmor(new Armor("Leather Boots", 1, EquipmentSlot.Legs, ArmorType.Cloth, 0, 5, 0));
            Testman.EquipArmor(new Armor("Leather Vest", 1, EquipmentSlot.Body, ArmorType.Cloth, 2, 3, 5));

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = DisplayFunctions.MainMenu(Testman);
            }
            

            //LoginFunctions.createUser(1, userName);




        }
    }
}