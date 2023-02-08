namespace RPGHeroes
{


    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome Hero to the adventure!");
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            Console.WriteLine(userName+ " please tell me more about yourself");
            Console.WriteLine("Mage (1)");
            Console.WriteLine("Ranger (2)");
            Console.WriteLine("Rogue (3)");
            Console.WriteLine("Warrior (4)");
            string heroClass = Console.ReadLine();
            Console.WriteLine("NAME: " + userName);
            Console.WriteLine("CLASS: " + heroClass);
            Console.WriteLine("LEVEL: 1");


        }
    }
}