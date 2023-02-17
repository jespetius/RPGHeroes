using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Inventory
{
    public class Armor: Item
    {
        /// <summary>
        /// Armor for hero
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requiredLevel"></param>
        /// <param name="equipmentSlot"></param>
        public Armor(string name, int requiredLevel, EquipmentSlot equipmentSlot, ArmorType armorType, int strengthBoost, int dexterityBoost, int intelligenceBoost) : base(name,requiredLevel, equipmentSlot) 
        { 
        
            ArmorType = armorType;
            StrengthBoost = strengthBoost;
            DexterityBoost = dexterityBoost;
            IntelligenceBoost = intelligenceBoost;
            
        }
        public ArmorType ArmorType { get; set; }
        public int StrengthBoost { get;set; }   
        public int DexterityBoost { get;set;}
        public int IntelligenceBoost { get;set; }  


    }
}
