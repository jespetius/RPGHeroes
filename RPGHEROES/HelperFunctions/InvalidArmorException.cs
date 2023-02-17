using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.HelperFunctions
{/// <summary>
/// If armor is invaliod give this exception
/// </summary>
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException(string message) :base(message) 
        { 
        
        }
        public override string Message => "Invalid Armor Exception";
    }

}
