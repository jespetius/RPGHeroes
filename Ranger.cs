﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    class Ranger : Hero
    {
        public Ranger(string name) :base(name,1,7,1) {
            Console.WriteLine($"{Name} Ranger in danger.");

        }

        public override void LevelUp()
        {
            Level++;
            Attributes.Strength += 1;
            Attributes.Dexterity+= 5;
            Attributes.Intelligence+= 1;
        }

        public override void Display()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Strength: {Attributes.Strength}");
            Console.WriteLine($"Dexterity: {Attributes.Dexterity}");
            Console.WriteLine($"Intelligence: {Attributes.Intelligence}");
        }

    }
}