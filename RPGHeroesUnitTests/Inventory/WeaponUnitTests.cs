using RPGHeroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RPGHeroesUnitTests.Inventory
{
    public class WeaponUnitTests
    {
        [Theory]
        [InlineData(WeaponType.Axes)]
        [InlineData(WeaponType.Bows)]
        [InlineData(WeaponType.Hammers)]
        [InlineData(WeaponType.Daggers)]
        [InlineData(WeaponType.Swords)]
        [InlineData(WeaponType.Staffs)]
        [InlineData(WeaponType.Wands)]

        public void When_WeaponIsCreated(WeaponType weaponType)
        {
            string expectedName = "this one";
            Weapon weapon = new Weapon(expectedName, 10, 1, weaponType);
            
            Assert.Equal(expectedName, weapon.Name);
        }


    }
}
