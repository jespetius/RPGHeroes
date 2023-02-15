using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message) 
        { 
            
        }

        public override string Message => "Invalid Weapon Exception";

    }


}
