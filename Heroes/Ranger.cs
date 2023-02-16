using RPGHeroes.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class Ranger : Hero
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
