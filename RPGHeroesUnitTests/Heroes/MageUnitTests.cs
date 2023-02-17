using RPGHeroes;
using RPGHeroes.HelperFunctions;
using RPGHeroes.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace RPGHeroesUnitTests.Heroes
{
    public class MageUnitTests
    {

        #region Mage creation

        [Fact]
        public void New_Mage_Creation_With_Username()
        {
            string username = "Makkonen";

            Hero test = new Mage(username);

            Assert.Equal(username, test.Name);
        }

        [Fact]
        public void New_Heros_Starting_Level_Is_Expected()
        {
            Hero levelTest = new Mage("Level");

            Assert.Equal(1, levelTest.Level);
        }

        [Fact]

        public void Heros_Starting_Stats_are_Correct()
        {
            Hero statsTest = new Mage("stats");
            int str = 1;
            int dex = 1;
            int intel = 8;

            Assert.Equal(str, statsTest.Attributes.Strength);
            Assert.Equal(dex, statsTest.Attributes.Dexterity);
            Assert.Equal(intel, statsTest.Attributes.Intelligence);
        }

        [Fact]
        public void Hero_LevelUp_Increase_Stats_Correctly()
        {
            Hero levelUp = new Mage("levelUP");

            levelUp.LevelUp();

            int str = 2;
            int dex = 2;
            int intel = 13;
            int lvl = 2;

            Assert.Equal(str, levelUp.Attributes.Strength);
            Assert.Equal(dex, levelUp.Attributes.Dexterity);
            Assert.Equal(intel, levelUp.Attributes.Intelligence);
            Assert.Equal(lvl, levelUp.Level);


        }

        #endregion

        #region Mage Equip Weapon

        [Theory]
        [InlineData("common wand", 5, 1, WeaponType.Wands)]
        [InlineData("common staff", 5, 1, WeaponType.Staffs)]

        public void Mage_Tries_To_Wear_Allowed_Weapon_Success(string name, double damage, int level, WeaponType weapontype)
        {
            Hero test = new Mage("test");
            test.EquipWeapon(new Weapon(name, damage, level, weapontype));


            Assert.Equal(name, test.EquippedWeapon.Name);
        }

        [Theory]
        [InlineData("axe", 5, 1, WeaponType.Axes)]
        [InlineData("bow", 5, 1, WeaponType.Bows)]
        [InlineData("sword", 5, 1, WeaponType.Swords)]
        [InlineData("hammer", 5, 1, WeaponType.Hammers)]
        [InlineData("dagger", 5, 1, WeaponType.Daggers)]
        [InlineData("TooHighLevelWand", 5, 4, WeaponType.Wands)]
        public void Mage_Tries_To_Wear_Unallowed_Weapon_ReturnsException(string name, double damage, int level, WeaponType weapontype)
        {
            Hero test = new Mage("test");

            Assert.Throws<InvalidWeaponException>(() => test.EquipWeapon(new Weapon(name, damage, level, weapontype)));
            


            
        }

        [Fact]
        public void Mage_Wears_New_Weapon_While_Holding_Weapon_OldoneIsDeleted()
        {
            Hero test = new Mage("test");
            string expectedName = "ThisOne";
            test.EquipWeapon(new Weapon("Common Wand", 5, 1, WeaponType.Wands));
            test.EquipWeapon(new Weapon(expectedName, 5, 1, WeaponType.Staffs));

            Assert.Equal(expectedName, test.EquippedWeapon.Name);

        }
        #endregion

        #region Mage Equip Armor

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void MageWearsAllowedGear_Diffrerent_Slots(EquipmentSlot equipmentSlot)
        {
            
            Hero test = new Mage("test");
            string expectedName = "ThisOne";
            int expected = 1;
            test.EquipArmor(new Armor(expectedName, 1, equipmentSlot, ArmorType.Cloth, 0, 1, 3));

            Assert.Equal(expected, test.EquippedArmor.Count);
        }
        [Fact]
        public void MageWearsAllowedGear_InThreeDiffrerent_Slots()
        {

            Hero test = new Mage("test");
            string expectedName = "ThisOne";
            int expected = 3;
            test.EquipArmor(new Armor(expectedName, 1, EquipmentSlot.Legs, ArmorType.Cloth, 0, 1, 3));
            test.EquipArmor(new Armor(expectedName, 1, EquipmentSlot.Head, ArmorType.Cloth, 0, 1, 3));
            test.EquipArmor(new Armor(expectedName, 1, EquipmentSlot.Body, ArmorType.Cloth, 0, 1, 3));

            Assert.Equal(expected, test.EquippedArmor.Count);
        }

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void MageWearsAllowedGear_Diffrerent_Slots_ThenChangeGear(EquipmentSlot equipmentSlot)
        {

            Hero test = new Mage("test");
            string expectedName = "ThisOne";
            int expected = 1;
            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Cloth, 1, 1, 1));
            test.EquipArmor(new Armor(expectedName, 1, equipmentSlot, ArmorType.Cloth, 0, 1, 3));

            Assert.Equal(expected, test.EquippedArmor.Count);
        }

        [Theory]
        [InlineData(ArmorType.Mail, 1)]
        [InlineData(ArmorType.Plate, 1)]
        [InlineData(ArmorType.Leather, 1)]
        [InlineData(ArmorType.Cloth, 2)]

        public void MageWearsUnallowedGear_ThrowsException(ArmorType armorType, int level)
        {

            Hero test = new Mage("test");
            
            

            Assert.Throws<InvalidArmorException>(() => test.EquipArmor(new Armor("not this one", level, EquipmentSlot.Legs, armorType, 1, 1, 1)));

        }


        #endregion

        #region Mage Damage

        [Fact]
        public void MagesDamage_WhenFirstTimeInitialised()
        {
            var test = new Mage("test");
            double damage = test.HeroDamage();

            Assert.Equal(1,damage);
        }

        [Fact]
        public void MagesDamage_WhenUsingWeapon()
        {
            var test = new Mage("test");
            test.EquipWeapon(new Weapon("Common Wand", 100, 1, WeaponType.Wands));
            double actual = test.HeroDamage();

            double expected =Math.Round( 100 * (1 + 8 / 100.0) , MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void MagesDamage_WhenSwitchingWeapon()
        {
            var test = new Mage("test");
            test.EquipWeapon(new Weapon("Common Wand", 100, 1, WeaponType.Wands));
            test.EquipWeapon(new Weapon("Common Wand", 50, 1, WeaponType.Wands));

            double actual = test.HeroDamage();

            double expected = Math.Round(50 * (1 + 8 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void MagesDamage_WhenUsingStatsBoostingArmor(EquipmentSlot equipmentSlot)
        {
            var test = new Mage("test");

            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Cloth, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(1 * (1 + 108 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void MagesDamage_WhenUsingStatsBoostingArmorAndWeapon(EquipmentSlot equipmentSlot)
        {
            var test = new Mage("test");
            test.EquipWeapon(new Weapon("Common Wand", 100, 1, WeaponType.Wands));
            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Cloth, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 108 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void MagesDamage_WhenChangingArmor(EquipmentSlot equipmentSlot)
        {
            var test = new Mage("test");
            test.EquipWeapon(new Weapon("Common Wand", 100, 1, WeaponType.Wands));
            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Cloth, 1, 1, 1));
            test.EquipArmor(new Armor("this one", 1, equipmentSlot, ArmorType.Cloth, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 108 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MagesDamage_WhenFullArmorAndWeapon()
        {
            var test = new Mage("test");
            test.EquipWeapon(new Weapon("Common Wand", 100, 1, WeaponType.Wands));
            test.EquipArmor(new Armor("not this one", 1, EquipmentSlot.Legs, ArmorType.Cloth, 100, 100, 100));
            test.EquipArmor(new Armor("this one", 1, EquipmentSlot.Head, ArmorType.Cloth, 100, 100, 100));
            test.EquipArmor(new Armor("this one", 1, EquipmentSlot.Body, ArmorType.Cloth, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 308 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }










        #endregion


    }
}


