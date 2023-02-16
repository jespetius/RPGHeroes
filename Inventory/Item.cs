using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Inventory
{
    public abstract class Item
    {
        public Item(string name, int requiredLevel, EquipmentSlot slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;
        }

        public string Name { get; private set; }
        public int RequiredLevel { get; private set; }
        public EquipmentSlot Slot { get; private set; }


    }
}
