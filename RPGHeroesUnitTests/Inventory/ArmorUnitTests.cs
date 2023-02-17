using RPGHeroes;
using RPGHeroes.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroesUnitTests.Inventory
{
    public class ArmorUnitTests
    {
        [Theory]
        [InlineData(ArmorType.Leather)]
        [InlineData(ArmorType.Cloth)]
        [InlineData(ArmorType.Mail)]
        [InlineData(ArmorType.Plate)]

        public void When_NewArmorIsCreatedDifferentArmorTypes(ArmorType armorType)
        {
            Armor armor = new Armor("test", 1, RPGHeroes.EquipmentSlot.Head, armorType, 1, 1, 1);

            Assert.NotNull(armor);

        }

        [Theory]
        [InlineData(EquipmentSlot.Body)]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]

        public void When_NewArmorIsCreatedDifferentSlots(EquipmentSlot equipment)
        {
            Armor armor = new Armor("test", 1, equipment, ArmorType.Leather, 1, 1, 1);

            Assert.NotNull(armor);

        }

    }
}
