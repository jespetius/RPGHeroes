using RPGHeroes.HelperFunctions;
using RPGHeroes.Inventory;
using RPGHeroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroesUnitTests.Heroes
{
    public class WarriorUnitTests
    {

        #region Warrior creation

        [Fact]
        public void New_Warrior_Creation_With_Username()
        {
            string username = "Makkonen";

            Hero test = new Warrior(username);

            Assert.Equal(username, test.Name);
        }

        [Fact]
        public void New_Heros_Starting_Level_Is_Expected()
        {
            Hero levelTest = new Warrior("Level");

            Assert.Equal(1, levelTest.Level);
        }

        [Fact]

        public void Heros_Starting_Stats_are_Correct()
        {
            Hero statsTest = new Warrior("stats");
            int str = 5;
            int dex = 2;
            int intel = 1;

            Assert.Equal(str, statsTest.Attributes.Strength);
            Assert.Equal(dex, statsTest.Attributes.Dexterity);
            Assert.Equal(intel, statsTest.Attributes.Intelligence);
        }

        [Fact]
        public void Hero_LevelUp_Increase_Stats_Correctly()
        {
            Hero levelUp = new Warrior("levelUP");

            levelUp.LevelUp();

            int str = 8;
            int dex = 4;
            int intel = 2;
            int lvl = 2;

            Assert.Equal(str, levelUp.Attributes.Strength);
            Assert.Equal(dex, levelUp.Attributes.Dexterity);
            Assert.Equal(intel, levelUp.Attributes.Intelligence);
            Assert.Equal(lvl, levelUp.Level);


        }

        #endregion

        #region Warrior Equip Weapon

        [Theory]
        [InlineData("weapon", 5, 1, WeaponType.Axes)]
        [InlineData("weapon", 5, 1, WeaponType.Swords)]
        [InlineData("weapon", 5, 1, WeaponType.Hammers)]
        public void Warrior_Tries_To_Wear_Allowed_Weapon_Success(string name, double damage, int level, WeaponType weapontype)
        {
            Hero test = new Warrior("test");
            test.EquipWeapon(new Weapon(name, damage, level, weapontype));


            Assert.Equal(name, test.EquippedWeapon.Name);
        }

        [Theory]
        [InlineData("dagger", 5, 1, WeaponType.Daggers)]
        [InlineData("sword", 5, 1, WeaponType.Staffs)]
        [InlineData("bow", 5, 1, WeaponType.Bows)]
        [InlineData("dagger", 5, 1, WeaponType.Wands)]
        [InlineData("TooHighLevelAxe", 5, 4, WeaponType.Axes)]
        public void Warrior_Tries_To_Wear_Unallowed_Weapon_ReturnsException(string name, double damage, int level, WeaponType weapontype)
        {
            Hero test = new Warrior("test");

            Assert.Throws<InvalidWeaponException>(() => test.EquipWeapon(new Weapon(name, damage, level, weapontype)));




        }

        [Fact]
        public void Warrior_Wears_New_Weapon_While_Holding_Weapon_OldoneIsDeleted()
        {
            Hero test = new Warrior("test");
            string expectedName = "ThisOne";
            test.EquipWeapon(new Weapon("Common", 5, 1, WeaponType.Axes));
            test.EquipWeapon(new Weapon(expectedName, 5, 1, WeaponType.Axes));

            Assert.Equal(expectedName, test.EquippedWeapon.Name);

        }
        #endregion

        #region Warrior Equip Armor

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void WarriorWearsAllowedGear_Diffrerent_Slots(EquipmentSlot equipmentSlot)
        {

            Hero test = new Warrior("test");
            string expectedName = "ThisOne";
            int expected = 1;
            test.EquipArmor(new Armor(expectedName, 1, equipmentSlot, ArmorType.Plate, 0, 1, 3));

            Assert.Equal(expected, test.EquippedArmor.Count);
        }
        [Fact]
        public void WarriorWearsAllowedGear_InThreeDiffrerent_Slots()
        {

            Hero test = new Warrior("test");
            string expectedName = "ThisOne";
            int expected = 3;
            test.EquipArmor(new Armor(expectedName, 1, EquipmentSlot.Legs, ArmorType.Mail, 0, 1, 3));
            test.EquipArmor(new Armor(expectedName, 1, EquipmentSlot.Head, ArmorType.Plate, 0, 1, 3));
            test.EquipArmor(new Armor(expectedName, 1, EquipmentSlot.Body, ArmorType.Plate, 0, 1, 3));

            Assert.Equal(expected, test.EquippedArmor.Count);
        }

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void WarriorWearsAllowedGear_Diffrerent_Slots_ThenChangeGear(EquipmentSlot equipmentSlot)
        {

            Hero test = new Warrior("test");
            string expectedName = "ThisOne";
            int expected = 1;
            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Plate, 1, 1, 1));
            test.EquipArmor(new Armor(expectedName, 1, equipmentSlot, ArmorType.Plate, 0, 1, 3));

            Assert.Equal(expected, test.EquippedArmor.Count);
        }

        [Theory]
        [InlineData(ArmorType.Leather, 1)]
        [InlineData(ArmorType.Cloth, 1)]
        [InlineData(ArmorType.Mail, 2)]

        public void WarriorWearsUnallowedGear_ThrowsException(ArmorType armorType, int level)
        {

            Hero test = new Warrior("test");



            Assert.Throws<InvalidArmorException>(() => test.EquipArmor(new Armor("not this one", level, EquipmentSlot.Legs, armorType, 1, 1, 1)));

        }


        #endregion

        #region Warrior Damage

        [Fact]
        public void WarriorDamage_WhenFirstTimeInitialised()
        {
            var test = new Warrior("test");
            double damage = test.HeroDamage();

            Assert.Equal(1, damage);
        }

        [Fact]
        public void WarriorsDamage_WhenUsingWeapon()
        {
            var test = new Warrior("test");
            test.EquipWeapon(new Weapon("Axes", 100, 1, WeaponType.Axes));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 5 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void WarriorsDamage_WhenSwitchingWeapon()
        {
            var test = new Warrior("test");
            test.EquipWeapon(new Weapon("Axe", 100, 1, WeaponType.Axes));
            test.EquipWeapon(new Weapon("Axe", 50, 1, WeaponType.Axes));

            double actual = test.HeroDamage();

            double expected = Math.Round(50 * (1 + 5 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void WarriorDamage_WhenUsingStatsBoostingArmor(EquipmentSlot equipmentSlot)
        {
            var test = new Warrior("test");

            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Plate, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(1 * (1 + 105 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void WarriorDamage_WhenUsingStatsBoostingArmorAndWeapon(EquipmentSlot equipmentSlot)
        {
            var test = new Warrior("test");
            test.EquipWeapon(new Weapon("Axe", 100, 1, WeaponType.Axes));
            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Plate, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 105 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void WarriorDamage_WhenChangingArmor(EquipmentSlot equipmentSlot)
        {
            var test = new Warrior("test");
            test.EquipWeapon(new Weapon("Axe", 100, 1, WeaponType.Axes));
            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Plate, 1, 1, 1));
            test.EquipArmor(new Armor("this one", 1, equipmentSlot, ArmorType.Plate, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 105 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WarriorDamage_WhenFullArmorAndWeapon()
        {
            var test = new Warrior("test");
            test.EquipWeapon(new Weapon("axe", 100, 1, WeaponType.Axes));
            test.EquipArmor(new Armor("not this one", 1, EquipmentSlot.Legs, ArmorType.Plate, 100, 100, 100));
            test.EquipArmor(new Armor("this one", 1, EquipmentSlot.Head, ArmorType.Plate, 100, 100, 100));
            test.EquipArmor(new Armor("this one", 1, EquipmentSlot.Body, ArmorType.Plate, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 305 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }










        #endregion


    }
}
