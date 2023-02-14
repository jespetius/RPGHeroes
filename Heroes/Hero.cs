using RPGHeroes.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public abstract class Hero
    {
       
        public string Name { get; set; }

        public int Level { get; set; }

        public HeroAttributes Attributes { get; set; }
        public WeaponType[] ValidWeapons { get; set; }
        public ArmorType[] ValidArmor { get; set; } 
        public Weapon EquippedWeapon { get; private set; }
        public Dictionary<EquipmentSlot, Armor> EquippedArmor { get; private set; } = new();

        public Hero(string name, int strength, int dexterity, int intelligence)
        {
            Name = name;
            Level = 1;
            Attributes = new HeroAttributes(strength, dexterity, intelligence);


        }
        /// <summary>
        /// Used to Level Up Hero
        /// </summary>
        public abstract void LevelUp();
        /// <summary>
        /// Used to display Hero's info.
        /// </summary>
        public abstract void Display();

        /// <summary>
        /// Wearing weapon to Hero
        /// </summary>
        /// <param name="weaponToEquip"></param>
        public virtual void EquipWeapon(Weapon weaponToEquip) 
        {
            EquippedWeapon = weaponToEquip;
        }
        /// <summary>
        /// Adding equipment to Hero
        /// </summary>
        /// <param name="armorToEquip"></param>
        public virtual void EquipArmor(Armor armorToEquip) 
        {
            EquippedArmor.Add(armorToEquip.Slot, armorToEquip);
        }

    }
   
}
