using RPGHeroes.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    class Warrior : Hero

    {
        public Warrior(string name) : base(name, 5, 2, 1)
        {
            Class = "Warrior";
            ValidWeapons = new[] { WeaponType.Axes, WeaponType.Hammers, WeaponType.Swords };
            ValidArmor = new[] { ArmorType.Mail, ArmorType.Plate };

            Console.WriteLine($"Furious {Name} the Warrior was born.");
        }

        public override void LevelUp()
        {
            Level++;
            Attributes.Strength += 3;
            Attributes.Dexterity += 2;
            Attributes.Intelligence += 1;
            Console.WriteLine("Hurray you are now Level " + Level);

        }


        public override double HeroDamage()
        {
            double weaponMultiplier = EquippedWeapon == null ? 1 : EquippedWeapon.Damage;
            int totalStrength = Attributes.Strength;

            if (EquippedArmor.Count != 0)
            {
                for (int index = 0; index < EquippedArmor.Count; index++)
                {
                    KeyValuePair<EquipmentSlot, Armor> armor = EquippedArmor.ElementAt(index);
                    if (armor.Value == null) continue;
                    totalStrength += armor.Value.StrengthBoost;
                }
            }
            double result = Math.Round(weaponMultiplier * (1 + totalStrength / 100.0), MidpointRounding.AwayFromZero);
            return result;
        }





    }
}
