using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Inventory
{
    public class Weapon : Item
    {
        public double Damage { get; set; }
        public WeaponType WeaponType { get; set; }
        /// <summary>
        /// Weapon for Hero
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="requiredLevel"></param>
        /// <param name="weaponType"></param>
        public Weapon(string name, double damage, int requiredLevel, WeaponType weaponType) :
            base(name, requiredLevel, EquipmentSlot.Weapon)
        {
            Damage = damage;
            WeaponType = weaponType;
        }


    }
}
