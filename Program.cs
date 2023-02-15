using RPGHeroes.Heroes;
using RPGHeroes.Inventory;

namespace RPGHeroes
{


    public class Program
    {
 

        static void Main(string[] args)
        {
            
            string userName = "";
            string heroClass = "";
            while (userName == "")
            {
              userName = LoginFunctions.getUsername();
            }
            
            while (heroClass == "")
            {
                heroClass = LoginFunctions.getHeroType(userName);

            }
           
            
            //Hero Testman = new Mage("Test Man");
            

            //bool showMenu = true;
            //while (showMenu)
            //{
            //    showMenu = DisplayFunctions.MainMenu(player);
            //}
            

            //LoginFunctions.createUser(1, userName);




        }
    }
}