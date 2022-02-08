using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralTypeClass
{
    public class Dog : BaseClass
    {

        public string Name { get; set; }
        public string Breed { get; set; }

        public override void Run()
        {
            Console.WriteLine("Running with four legs");
        }

        private static readonly CRUD<Dog> DogCRUD = new();

        private static int IdCounter = 0;
        public static void Menu()
        {
            Console.Clear();
            var dogHelper = new DogHelper();
            Console.WriteLine("Dog List");
            Console.WriteLine("-------------------------------------------------");
            var list = DogCRUD.Read();
            foreach (var item in list)
            {
                string humanYears = dogHelper.CalculateDogYears(item.Age);
                Console.WriteLine($"{item.Id}. {item.Name} {item.Breed}, Sex: {item.GetSexName((int)item.Sex)}\n{item.Age} Dog Years\n{humanYears}");
                Console.WriteLine("-------------------------------------------------");
            }
            Console.WriteLine("What you wanna do?");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("0.Back to main menu\n1.Create");
            if (DogCRUD.ListLength() > 0)
            {
                Console.WriteLine("2.Update \n3.Delete \n4.Get By ID");
            }
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "0":
                    Program.MainMenu();
                    break;
                case "1":
                    CreateDog();
                    break;

                case "2":
                    UpdateDog();
                    break;
                case "3":
                    DeleteDog();
                    break;
                case "4":
                    GetDogById();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        static void CreateDog()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Breed:");
            string breed = Console.ReadLine();

            Console.WriteLine("Dog age:");
            int age = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Sex \n1.Male \n2.Female");
            int sex = Convert.ToInt16(Console.ReadLine());

            if (name == "" || breed == null)
            {
                Console.WriteLine("Is empty");
                Console.Read();
                Menu();
            }
            var new_dog= new Dog()
            {
                Id = IdCounter,
                Name = name,
                Breed = breed,
                Age = age,
                Sex = (sex > 1) ? (int?)SexType.Female : (int?)SexType.Male
            };
            DogCRUD.Create(new_dog);
            IdCounter++;
            Menu();
        }

        static void UpdateDog()
        {
            Console.WriteLine("Choose from the list:");
            var id = Convert.ToInt16(Console.ReadLine());

            var old_dog = DogCRUD.GetById(id);

            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Breed:");
            string breed = Console.ReadLine();

            Console.WriteLine("Dog age:");
            int age = Convert.ToInt16(Console.ReadLine());

            if (name == "" || breed == null)
            {
                Console.WriteLine("Is empty");
                Console.Read();
                Menu();
            }
            var new_dog= new Dog()
            {
                Id = old_dog.Id,
                Name = name,
                Breed = breed,
                Age = age,
                Sex = old_dog.Sex
            };
            DogCRUD.Update(new_dog);
            Menu();
        }

        static void DeleteDog()
        {
            Console.WriteLine("Choose from the list:");
            var id = Convert.ToInt16(Console.ReadLine());

            var result = DogCRUD.Delete(id);

            if (!result)
            {
                Console.WriteLine("Error, dog not found");
                Console.Read();
                Menu();
            }
            Menu();
        }

        static void GetDogById()
        {
            Console.WriteLine("Choose from the list:");
            var id = Convert.ToInt16(Console.ReadLine());

            var dog = DogCRUD.GetById(id);
            if (dog == null)
            {
                Menu();
            }

            Console.WriteLine($"{dog.Id}. {dog.Name}, {dog.Breed}\n");
            Console.WriteLine("Want to run? 1.Yes\n2.No");
            string answer = Console.ReadLine();
            if( answer == "1" )
            {
                dog.Run();
                Console.Read();
                Menu();
            }
            else
            {
                Console.Read();
                Menu();
            }
        }
    }


}
