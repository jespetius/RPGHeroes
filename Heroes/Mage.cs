using RPGHeroes.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class Mage : Hero
    {


        public Mage(string username) : base(username, 1, 1, 8)
        {
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

        public override double HeroDamage()
        {
            int totalIntelligence = Attributes.Intelligence;

            if (EquippedArmor.Count != 0)
            {
                for (int index = 0; index < EquippedArmor.Count; index++)
                {
                    KeyValuePair<EquipmentSlot, Armor> armor = EquippedArmor.ElementAt(index);
                    if (armor.Value == null) continue;
                    totalIntelligence += armor.Value.IntelligenceBoost;
                }
            }

            double weaponMultiplier = EquippedWeapon == null ? 1 : EquippedWeapon.Damage;
            double result = Math.Round(weaponMultiplier * (1 + totalIntelligence / 100.0), MidpointRounding.AwayFromZero);
            return result;
        }




    }
}
