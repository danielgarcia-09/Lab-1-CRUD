namespace GeneralTypeClass
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.Clear();   
            Console.WriteLine("Choose your menu:");
            Console.WriteLine("1.Human\n2.Dog");
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    Human.Menu();
                    break;
                case "2":
                    Dog.Menu();
                    break;
                default:
                    MainMenu();
                    break;
            }

        }

    }
    
}