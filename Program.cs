using RPGHeroes.Inventory;

namespace RPGHeroes
{


    public class Program
    {
        
        static void Main(string[] args)
        {
           
            string userName = "";
            int userChoise = 0;
            int heroClass = 0;
            while (userName == "")
            {
              userName = LoginFunctions.getUsername();
            }
            

            Hero Testman = new Mage("Test Man");
           

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = DisplayFunctions.MainMenu(Testman);
            }
            

            //LoginFunctions.createUser(1, userName);




        }
    }
}