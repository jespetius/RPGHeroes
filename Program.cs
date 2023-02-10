namespace RPGHeroes
{


    class Program
    {
        static void Main(string[] args)
        {
            string userName = "";
            string heroClass = "";
            while (userName == "")
            {
              userName = LoginFunctions.getUsername();
            }

            while (true)
            {
                if (heroClass != "wrong input")
                {
                    heroClass = LoginFunctions.getHeroType();
                    break;
                }
                else
                {   
                    Console.WriteLine("You gonna have long journey... Press 1-4 to select a class");
                }
            }

            


            Hero currentPlayer= new Mage(userName)
            {
                 
            };
            currentPlayer.LevelUp();
            Hero allu = new Rogue(userName)
            {

            };
            allu.LevelUp();

            Hero jallu = new Warrior(userName)
            {

            };
            jallu.LevelUp();

            Hero puuhamies = new Ranger(userName)
            {

            };
            puuhamies.LevelUp();
            puuhamies.Display();
            
            


        }
    }
}