using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public abstract class Hero
    {
       
        public string Name { get; set; }

        public int Level { get; set; }

        public HeroAttributes Attributes { get; set; }

        public Hero(string name, int strength, int dexterity, int intelligence)
        {
            Name = name;
            Level = 1;
            Attributes = new HeroAttributes(strength, dexterity, intelligence);


        }

        public abstract void LevelUp();
        public abstract void Display();

    }
   
}
