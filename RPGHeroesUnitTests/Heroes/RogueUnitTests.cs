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
    public class RogueUnitTests
    {

        #region Rogue creation

        [Fact]
        public void New_Rogue_Creation_With_Username()
        {
            string username = "Makkonen";

            Hero test = new Rogue(username);

            Assert.Equal(username, test.Name);
        }

        [Fact]
        public void New_Heros_Starting_Level_Is_Expected()
        {
            Hero levelTest = new Rogue("Level");

            Assert.Equal(1, levelTest.Level);
        }

        [Fact]

        public void Heros_Starting_Stats_are_Correct()
        {
            Hero statsTest = new Rogue("stats");
            int str = 2;
            int dex = 6;
            int intel = 1;

            Assert.Equal(str, statsTest.Attributes.Strength);
            Assert.Equal(dex, statsTest.Attributes.Dexterity);
            Assert.Equal(intel, statsTest.Attributes.Intelligence);
        }

        [Fact]
        public void Hero_LevelUp_Increase_Stats_Correctly()
        {
            Hero levelUp = new Rogue("levelUP");

            levelUp.LevelUp();

            int str = 3;
            int dex = 10;
            int intel = 2;
            int lvl = 2;

            Assert.Equal(str, levelUp.Attributes.Strength);
            Assert.Equal(dex, levelUp.Attributes.Dexterity);
            Assert.Equal(intel, levelUp.Attributes.Intelligence);
            Assert.Equal(lvl, levelUp.Level);


        }

        #endregion

        #region Rogue Equip Weapon

        [Theory]
        [InlineData("common dagger", 5, 1, WeaponType.Daggers)]
        [InlineData("common sword", 5, 1, WeaponType.Swords)]

        public void Rogue_Tries_To_Wear_Allowed_Weapon_Success(string name, double damage, int level, WeaponType weapontype)
        {
            Hero test = new Rogue("test");
            test.EquipWeapon(new Weapon(name, damage, level, weapontype));


            Assert.Equal(name, test.EquippedWeapon.Name);
        }

        [Theory]
        [InlineData("axe", 5, 1, WeaponType.Axes)]
        [InlineData("bow", 5, 1, WeaponType.Bows)]
        [InlineData("sword", 5, 1, WeaponType.Staffs)]
        [InlineData("hammer", 5, 1, WeaponType.Hammers)]
        [InlineData("dagger", 5, 1, WeaponType.Wands)]
        [InlineData("TooHighLevelWand", 5, 4, WeaponType.Daggers)]
        public void Rogue_Tries_To_Wear_Unallowed_Weapon_ReturnsException(string name, double damage, int level, WeaponType weapontype)
        {
            Hero test = new Rogue("test");

            Assert.Throws<InvalidWeaponException>(() => test.EquipWeapon(new Weapon(name, damage, level, weapontype)));




        }

        [Fact]
        public void Rogue_Wears_New_Weapon_While_Holding_Weapon_OldoneIsDeleted()
        {
            Hero test = new Rogue("test");
            string expectedName = "ThisOne";
            test.EquipWeapon(new Weapon("Common Wand", 5, 1, WeaponType.Daggers));
            test.EquipWeapon(new Weapon(expectedName, 5, 1, WeaponType.Daggers));

            Assert.Equal(expectedName, test.EquippedWeapon.Name);

        }
        #endregion

        #region Rogue Equip Armor

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void RogueWearsAllowedGear_Diffrerent_Slots(EquipmentSlot equipmentSlot)
        {

            Hero test = new Rogue("test");
            string expectedName = "ThisOne";
            int expected = 1;
            test.EquipArmor(new Armor(expectedName, 1, equipmentSlot, ArmorType.Leather, 0, 1, 3));

            Assert.Equal(expected, test.EquippedArmor.Count);
        }
        [Fact]
        public void RogueWearsAllowedGear_InThreeDiffrerent_Slots()
        {

            Hero test = new Rogue("test");
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
        public void RogueWearsAllowedGear_Diffrerent_Slots_ThenChangeGear(EquipmentSlot equipmentSlot)
        {

            Hero test = new Rogue("test");
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

        public void RogueWearsUnallowedGear_ThrowsException(ArmorType armorType, int level)
        {

            Hero test = new Rogue("test");



            Assert.Throws<InvalidArmorException>(() => test.EquipArmor(new Armor("not this one", level, EquipmentSlot.Legs, armorType, 1, 1, 1)));

        }


        #endregion

        #region Rogue Damage

        [Fact]
        public void RoguesDamage_WhenFirstTimeInitialised()
        {
            var test = new Rogue("test");
            double damage = test.HeroDamage();

            Assert.Equal(1, damage);
        }

        [Fact]
        public void RoguesDamage_WhenUsingWeapon()
        {
            var test = new Rogue("test");
            test.EquipWeapon(new Weapon("Common sword", 100, 1, WeaponType.Swords));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 6 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void RoguesDamage_WhenSwitchingWeapon()
        {
            var test = new Rogue("test");
            test.EquipWeapon(new Weapon("Common Wand", 100, 1, WeaponType.Swords));
            test.EquipWeapon(new Weapon("Common Wand", 50, 1, WeaponType.Swords));

            double actual = test.HeroDamage();

            double expected = Math.Round(50 * (1 + 6 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void RogueDamage_WhenUsingStatsBoostingArmor(EquipmentSlot equipmentSlot)
        {
            var test = new Rogue("test");

            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Leather, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(1 * (1 + 106 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void RogueDamage_WhenUsingStatsBoostingArmorAndWeapon(EquipmentSlot equipmentSlot)
        {
            var test = new Rogue("test");
            test.EquipWeapon(new Weapon("Common Wand", 100, 1, WeaponType.Daggers));
            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Leather, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 106 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(EquipmentSlot.Head)]
        [InlineData(EquipmentSlot.Legs)]
        [InlineData(EquipmentSlot.Body)]
        public void RogueDamage_WhenChangingArmor(EquipmentSlot equipmentSlot)
        {
            var test = new Rogue("test");
            test.EquipWeapon(new Weapon("Common Wand", 100, 1, WeaponType.Swords));
            test.EquipArmor(new Armor("not this one", 1, equipmentSlot, ArmorType.Leather, 1, 1, 1));
            test.EquipArmor(new Armor("this one", 1, equipmentSlot, ArmorType.Leather, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 106 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RoguesDamage_WhenFullArmorAndWeapon()
        {
            var test = new Rogue("test");
            test.EquipWeapon(new Weapon("Common Wand", 100, 1, WeaponType.Swords));
            test.EquipArmor(new Armor("not this one", 1, EquipmentSlot.Legs, ArmorType.Leather, 100, 100, 100));
            test.EquipArmor(new Armor("this one", 1, EquipmentSlot.Head, ArmorType.Leather, 100, 100, 100));
            test.EquipArmor(new Armor("this one", 1, EquipmentSlot.Body, ArmorType.Leather, 100, 100, 100));
            double actual = test.HeroDamage();

            double expected = Math.Round(100 * (1 + 306 / 100.0), MidpointRounding.AwayFromZero);

            Assert.Equal(expected, actual);
        }










        #endregion


    }
}
