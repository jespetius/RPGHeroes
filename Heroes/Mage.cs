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
            ValidWeapons = new[] { WeaponType.Wands };
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
            if(EquippedWeapon!= null)
            {
                Console.WriteLine("Weapon: " + EquippedWeapon.Name);
            }
            
        }




    }
}
