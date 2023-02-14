using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Inventory
{
    public class Armor: Item
    {
        public Armor(string name, int requiredLevel, EquipmentSlot equipmentSlot): base(name,requiredLevel, equipmentSlot) 
        { 
        
        }
    }
}
