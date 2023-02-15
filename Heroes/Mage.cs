using RPGHeroes.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    class Mage : Hero
    {
       

        public Mage(string username) : base(username,1,1,8) {
            Class = "Mage";
            ValidWeapons = new[] { WeaponType.Wands, WeaponType.Staffs };
            ValidArmor = new[] { ArmorType.Cloth };
            Console.WriteLine($"{Name} The Mage has born");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Strength: {Attributes.Strength}");
            Console.WriteLine($"Dexterity: {Attributes.Dexterity}");
            Console.WriteLine($"Intelligence: {Attributes.Intelligence}");
        }


        public override void LevelUp()
        {
            Level += 1;
            Attributes.Strength += 1;
            Attributes.Dexterity += 1;
            Attributes.Intelligence += 5;

            
        }
        public override void Display()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Strength: {Attributes.Strength}");
            Console.WriteLine($"Dexterity: {Attributes.Dexterity}");
            Console.WriteLine($"Intelligence: {Attributes.Intelligence}");
            Console.WriteLine($"Damage: {HeroDamage()}");
            if(EquippedWeapon!= null)
            {
                Console.WriteLine("Weapon: " + EquippedWeapon.Name);
            }
            if (EquippedArmor != null)
            {
                Console.WriteLine(EquippedArmor.Count);
            }
        }

        public override double HeroDamage()
        {
            double weaponMultiplier = (EquippedWeapon == null ? 1 : EquippedWeapon.Damage);
            double result = Math.Round(weaponMultiplier * (1 + Attributes.Intelligence / 100.0), MidpointRounding.AwayFromZero);
            return result;
        }




    }
}
