namespace RPGHeroes
{


    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome Hero to the adventure!");
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            Console.WriteLine("Username is: " + userName);
        }
    }
}