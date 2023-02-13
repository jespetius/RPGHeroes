using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class Weapon : Item
    {
        public double Damage { get; set; }
        public WeaponType WeaponType { get; set; }
        public Weapon(string name, double damage, int requiredLevel, WeaponType weaponType) :
            base(name,requiredLevel,EquipmentSlot.Weapon)
        {
            Damage= damage;
            WeaponType= weaponType;
        }


    }
}
