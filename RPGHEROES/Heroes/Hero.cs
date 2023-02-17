using RPGHeroes.HelperFunctions;
using RPGHeroes.Inventory;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public abstract class Hero
    {
       
        public string Name { get; set; }

        public int Level { get; set; }

        public string Class { get; set; }

        
        public HeroAttributes Attributes { get; set; }
        public WeaponType[] ValidWeapons { get; set; }
        public ArmorType[] ValidArmor { get; set; } 
        public Weapon EquippedWeapon { get; private set; }
        public Dictionary<EquipmentSlot, Armor> EquippedArmor { get; set; } = new();

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
       /// Display Hero info.
       /// </summary>
        public virtual void Display() 
        {
            int totalStrength = Attributes.Strength;
            int totalDexterity = Attributes.Dexterity;
            int totalIntelligence = Attributes.Intelligence;

            if (EquippedArmor.Count != 0)
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
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Strength: {totalStrength}");
            Console.WriteLine($"Dexterity: {totalDexterity}");
            Console.WriteLine($"Intelligence: {totalIntelligence}");
            Console.WriteLine($"Damage: {HeroDamage()}");
            if (EquippedWeapon != null)
            {
                Console.WriteLine("Weapon: " + EquippedWeapon.Name);
            }
            ShowCurrentArmor();
        }



        /// <summary>
        /// Wearing weapon to Hero
        /// </summary>
        /// <param name="weaponToEquip"></param>
        public virtual void EquipWeapon(Weapon weaponToEquip) 
        {
            if (weaponToEquip.RequiredLevel > Level)
            {
                throw new InvalidWeaponException("You dont have Level to equip this weapon");
               
            }
            else if (!ValidWeapons.Contains(weaponToEquip.WeaponType)) 
            {
                throw new InvalidWeaponException("You cant use this type of weapon");
            }
            else
            {
                EquippedWeapon = weaponToEquip;

            }
        }
        /// <summary>
        /// Adding equipment to Hero
        /// </summary>
        /// <param name="armorToEquip"></param>
        public virtual void EquipArmor(Armor armorToEquip) 
        {
            if(armorToEquip.RequiredLevel > Level)
            {
                throw new InvalidArmorException("You need to level up to wear this!");
            }
            else if (!ValidArmor.Contains(armorToEquip.ArmorType))
            {
                throw new InvalidArmorException("This class cannot wear these kind of armors");

            }
            EquippedArmor.Remove(armorToEquip.Slot);
            EquippedArmor.Add(armorToEquip.Slot, armorToEquip);
            
            
        }
        /// <summary>
        /// List of armor currently on hero
        /// </summary>
        public virtual void ShowCurrentArmor()
        {
            if (EquippedArmor.Count != 0)
            {
                Console.WriteLine("Armors");
                for (int index = 0; index < EquippedArmor.Count; index++)
                {
                    KeyValuePair<EquipmentSlot, Armor> armor = EquippedArmor.ElementAt(index);
                    if (armor.Value == null) continue;
                    Console.WriteLine($"{armor.Value.Slot}: {armor.Value.Name} Str: {armor.Value.StrengthBoost} Dex: {armor.Value.IntelligenceBoost} Intel: {armor.Value.IntelligenceBoost} \n");
                }
            }


        }
        


        /// <summary>
        /// Generate Heros damage
        /// </summary>
        /// <returns></returns>
        public abstract double HeroDamage();

    }
   
}
