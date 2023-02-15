using RPGHeroes.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    class Ranger : Hero
    {
        public Ranger(string name) :base(name,1,7,1) {
            Class = "Ranger";
            ValidWeapons = new[] { WeaponType.Bows };
            ValidArmor = new[] { ArmorType.Leather, ArmorType.Mail };
            Console.WriteLine($"{Name} Ranger in danger.");

        }

        public override void LevelUp()
        {
            Level++;
            Attributes.Strength += 1;
            Attributes.Dexterity+= 5;
            Attributes.Intelligence+= 1;
        }

        public override void Display()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Strength: {Attributes.Strength}");
            Console.WriteLine($"Dexterity: {Attributes.Dexterity}");
            Console.WriteLine($"Intelligence: {Attributes.Intelligence}");
        }

        
        public override double HeroDamage()
        {
            double weaponMultiplier = (EquippedWeapon == null ? 1 : EquippedWeapon.Damage);
            double result = Math.Round(weaponMultiplier * (1 + Attributes.Dexterity / 100.0), MidpointRounding.AwayFromZero);
            return result;
        }

    }
}
