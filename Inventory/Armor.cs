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
        public Armor(string name, int requiredLevel, EquipmentSlot equipmentSlot): base(name,requiredLevel, equipmentSlot) 
        { 
        
        }
    }
}
