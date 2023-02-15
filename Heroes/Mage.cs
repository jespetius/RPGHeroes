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
            Console.WriteLine("Hurray you are now Level " + Level);

            
        }
        public override void Display()
        {
            int totalStrength = Attributes.Strength;
            int totalDexterity = Attributes.Dexterity;
            int totalIntelligence = Attributes.Intelligence;
            
            if(EquippedArmor.Count != 0 ) 
            {
                for (int index = 0; index < EquippedArmor.Count; index++)
                {
                    KeyValuePair<EquipmentSlot, Armor> armor = EquippedArmor.ElementAt(index);
                    if (armor.Value == null) continue;
                    totalStrength += armor.Value.StrengthBoost;
                    totalDexterity += armor.Value.DexterityBoost;
                    totalIntelligence += armor.Value.IntelligenceBoost;
                }
            }

            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Strength: {totalStrength}");
            Console.WriteLine($"Dexterity: {totalDexterity}");
            Console.WriteLine($"Intelligence: {totalIntelligence}");
            Console.WriteLine($"Damage: {HeroDamage()}");
            if(EquippedWeapon!= null)
            {
                Console.WriteLine("Weapon: " + EquippedWeapon.Name);
            }
           ShowCurrentArmor();

        }

        public override double HeroDamage()
        {
            double weaponMultiplier = (EquippedWeapon == null ? 1 : EquippedWeapon.Damage);
            double result = Math.Round(weaponMultiplier * (1 + Attributes.Intelligence / 100.0), MidpointRounding.AwayFromZero);
            return result;
        }




    }
}
