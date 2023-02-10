using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    class Rogue : Hero
    {
        public Rogue(string name) : base(name, 2, 6, 1)
        {
            Console.WriteLine($"Mighty {Name} the Rogue was born.");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Strength: {Attributes.Strength}");
            Console.WriteLine($"Dexterity: {Attributes.Dexterity}");
            Console.WriteLine($"Intelligence: {Attributes.Intelligence}");


        }
        public override void LevelUp()
        {
            Level += 1;
            Attributes.Strength += 1;
            Attributes.Dexterity += 4;
            Attributes.Intelligence += 1;

            Console.WriteLine($"Mighty {Name} the Rogue Leveled Up.");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Strength: {Attributes.Strength}");
            Console.WriteLine($"Dexterity: {Attributes.Dexterity}");
            Console.WriteLine($"Intelligence: {Attributes.Intelligence}");


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
