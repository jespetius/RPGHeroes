using RPGHeroes.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    class Rogue : Hero
    {
        public Rogue(string name) : base(name, 2, 6, 1)
        {
            Class = "Rogue";
            ValidWeapons = new[] { WeaponType.Daggers, WeaponType.Swords };
            ValidArmor = new[] { ArmorType.Leather, ArmorType.Mail };
            Console.WriteLine($"Mighty {Name} the Rogue was born.");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Strength: {Attributes.Strength}");
            Console.WriteLine($"Dexterity: {Attributes.Dexterity}");
            Console.WriteLine($"Intelligence: {Attributes.Intelligence}");


        }
        public override void LevelUp()
        {
            Level += 1;
            Attributes.Strength += 1;
            Attributes.Dexterity += 4;
            Attributes.Intelligence += 1;
            Console.WriteLine("Hurray you are now Level " + Level);


        }


        public override double HeroDamage()
        {
            int totalDexterity = Attributes.Dexterity;

            if (EquippedArmor.Count != 0)
            {
                for (int index = 0; index < EquippedArmor.Count; index++)
                {
                    KeyValuePair<EquipmentSlot, Armor> armor = EquippedArmor.ElementAt(index);
                    if (armor.Value == null) continue;
                    totalDexterity += armor.Value.DexterityBoost;
                }
            }

            double weaponMultiplier = (EquippedWeapon == null ? 1 : EquippedWeapon.Damage);
            double result = Math.Round(weaponMultiplier * (1 + totalDexterity / 100.0), MidpointRounding.AwayFromZero);
            return result;
        }


    }
}
