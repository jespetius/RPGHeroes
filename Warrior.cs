using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    class Warrior :Hero

    {
        public Warrior(string name) : base(name,5,2,1) 
        {
            Console.WriteLine($"Furious {Name} the Warrior was born.");
        }

        public override void LevelUp()
        {
            Level++;
            Attributes.Strength += 3;
            Attributes.Dexterity += 2;
            Attributes.Intelligence += 1;

          
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
