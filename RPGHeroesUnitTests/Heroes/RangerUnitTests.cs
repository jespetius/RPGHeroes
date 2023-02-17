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
    public class RangerUnitTests
    {

        #region Ranger creation

        [Fact]
        public void New_Ranger_Creation_With_Username()
        {
            string username = "Makkonen";

            Hero test = new Ranger(username);

            Assert.Equal(username, test.Name);
        }

        [Fact]
        public void New_Heros_Starting_Level_Is_Expected()
        {
            Hero levelTest = new Ranger("Level");

            Assert.Equal(1, levelTest.Level);
        }

        [Fact]

        public void Heros_Starting_Stats_are_Correct()
        {
            Hero statsTest = new Ranger("stats");
            int str = 1;
            int dex = 7;
            int intel = 1;

            Assert.Equal(str, statsTest.Attributes.Strength);
            Assert.Equal(dex, statsTest.Attributes.Dexterity);
            Assert.Equal(intel, statsTest.Attributes.Intelligence);
        }

        [Fact]
        public void Hero_LevelUp_Increase_Stats_Correctly()
        {
            Hero levelUp = new Ranger("levelUP");

            levelUp.LevelUp();

            int str = 2;
            int dex = 12;
            int intel = 6;
            int lvl = 2;

            Assert.Equal(str, levelUp.Attributes.Strength);
            Assert.Equal(dex, levelUp.Attributes.Dexterity);
            Assert.Equal(intel, levelUp.Attributes.Intelligence);
            Assert.Equal(lvl, levelUp.Level);


        }

        #endregion

        #region Ranger Equip Weapon

        [Theory]
        [InlineData("common bow", 5, 1, WeaponType.Bows)]
        
        public void Ranger_Tries_To_Wear_Allowed_Weapon_Success(string name, double damage, int level, WeaponType weapontype)
        {
            Hero test = new Ranger("test");
            test.EquipWeapon(new Weapon(name, damage, level, weapontype));


            Assert.Equal(name, test.EquippedWeapon.Name);
        }

        [Theory]
        [InlineData("axe", 5, 1, WeaponType.Axes)]
        [InlineData("bow", 5, 1, WeaponType.Daggers)]
        [InlineData("sword", 5, 1, WeaponType.Staffs)]
        [InlineData("hammer", 5, 1, WeaponType.Hammers)]
        [InlineData("dagger", 5, 1, WeaponType.Wands)]
        [InlineData("sword", 5, 1, WeaponType.Swords)]
        [InlineData("TooHighLevelBow", 5, 4, WeaponType.Bows)]
        public void Ranger_Tries_To_Wear_Unallowed_Weapon_ReturnsException(string name, double damage, int level, WeaponType weapontype)
        {
            Hero test = new Ranger("test");

            Assert.Throws<InvalidWeaponException>(() => test.EquipWeapon(new Weapon(name, damage, level, weapontype)));




        }

        [Fact]
        public void Ranger_Wears_New_Weapon_While_Holding_Weapon_OldoneIsDeleted()
        {
            Hero test = new Ranger("test");
            string expectedName = "ThisOne";
            test.EquipWeapon(new Weapon("Common Wand", 5, 1, WeaponType.Bows));
            test.EquipWeapon(new Weapon(expectedName, 5, 1, WeaponType.Bows));

            Assert.Equal(expectedName, test.EquippedWeapon.Name);

        }
        #endregion

        #region Ranger Equip Armor

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void RangerWearsAllowedGear_Diffrerent_Slots(EquipmentSlot equipmentSlot)
        {

            Hero test = new Ranger("test");
            string expectedName = "ThisOne";
            int expected = 1;
            test.EquipArmor(new Armor(expectedName, 1, equipmentSlot, ArmorType.Leather, 0, 1, 3));

            Assert.Equal(expected, test.EquippedArmor.Count);
        }
        [Fact]
        public void RangerWearsAllowedGear_InThreeDiffrerent_Slots()
        {

            Hero test = new Ranger("test");
            string expectedName = "ThisOne";
            int expected = 3;
            test.EquipArmor(new Armor(expectedName, 1, EquipmentSlot.Legs, ArmorType.Mail, 0, 1, 3));
            test.EquipArmor(new Armor(expectedName, 1, EquipmentSlot.Head, ArmorType.Leather, 0, 1, 3));
            test.EquipArmor(new Armor(expectedName, 1, EquipmentSlot.Body, ArmorType.Leather, 0, 1, 3));

            Assert.Equal(expected, test.EquippedArmor.Count);
        }

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void RangerWearsAllowedGear_Diffrerent_Slots_ThenChangeGear(EquipmentSlot equipmentSlot)
        {

            Hero test = new Ranger("test");
            string expectedName = "ThisOne";
            int expected = 1;
            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Leather, 1, 1, 1));
            test.EquipArmor(new Armor(expectedName, 1, equipmentSlot, ArmorType.Leather, 0, 1, 3));

            Assert.Equal(expected, test.EquippedArmor.Count);
        }

        [Theory]
        [InlineData(ArmorType.Plate, 1)]
        [InlineData(ArmorType.Cloth, 1)]
        [InlineData(ArmorType.Mail, 2)]

        public void RangerWearsUnallowedGear_ThrowsException(ArmorType armorType, int level)
        {

            Hero test = new Ranger("test");



            Assert.Throws<InvalidArmorException>(() => test.EquipArmor(new Armor("not this one", level, EquipmentSlot.Legs, armorType, 1, 1, 1)));

        }


        #endregion

        #region Ranger Damage

        [Fact]
        public void RangersDamage_WhenFirstTimeInitialised()
        {
            var test = new Ranger("test");
            double damage = test.HeroDamage();

            Assert.Equal(1, damage);
        }

        [Fact]
        public void RangersDamage_WhenUsingWeapon()
        {
            var test = new Ranger("test");
            test.EquipWeapon(new Weapon("Common bow", 100, 1, WeaponType.Bows));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 7 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void RangerssDamage_WhenSwitchingWeapon()
        {
            var test = new Ranger("test");
            test.EquipWeapon(new Weapon("Common Bow", 100, 1, WeaponType.Bows));
            test.EquipWeapon(new Weapon("Common Bow", 50, 1, WeaponType.Bows));

            double actual = test.HeroDamage();

            double expected = Math.Round(50 * (1 + 7 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void RangerDamage_WhenUsingStatsBoostingArmor(EquipmentSlot equipmentSlot)
        {
            var test = new Ranger("test");

            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Leather, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(1 * (1 + 107 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void RangerDamage_WhenUsingStatsBoostingArmorAndWeapon(EquipmentSlot equipmentSlot)
        {
            var test = new Ranger("test");
            test.EquipWeapon(new Weapon("Common Bow", 100, 1, WeaponType.Bows));
            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Leather, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 107 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void RangerDamage_WhenChangingArmor(EquipmentSlot equipmentSlot)
        {
            var test = new Ranger("test");
            test.EquipWeapon(new Weapon("Common Bow", 100, 1, WeaponType.Bows));
            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Leather, 1, 1, 1));
            test.EquipArmor(new Armor("this one", 1, equipmentSlot, ArmorType.Leather, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 107 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RangersDamage_WhenFullArmorAndWeapon()
        {
            var test = new Ranger("test");
            test.EquipWeapon(new Weapon("bow", 100, 1, WeaponType.Bows));
            test.EquipArmor(new Armor("not this one", 1, EquipmentSlot.Legs, ArmorType.Leather, 100, 100, 100));
            test.EquipArmor(new Armor("this one", 1, EquipmentSlot.Head, ArmorType.Leather, 100, 100, 100));
            test.EquipArmor(new Armor("this one", 1, EquipmentSlot.Body, ArmorType.Leather, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 307 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }










        #endregion


    }
}
