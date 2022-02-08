using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralTypeClass
{
    public class Human : BaseClass
    {
        public string Cedula { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        private static readonly CRUD<Human> HumanCRUD = new();

        private static int IdCounter = 0;
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Human List");
            Console.WriteLine("-------------------------------------------------");
            var list = HumanCRUD.Read();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id}. {item.Name} {item.LastName}, Sex: {item.GetSexName((int)item.Sex)}");
                Console.WriteLine("-------------------------------------------------");
            }
            Console.WriteLine("What you wanna do?");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("0.Back to main menu\n1.Create");
            if( HumanCRUD.ListLength() > 0)
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
                    CreateHuman();
                    break;
                case "2":
                    UpdateHuman();
                    break;
                case "3":
                    DeleteHuman();
                    break;
                case "4":
                    GetHumanById();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        static void CreateHuman()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Last Name:");
            string last_name = Console.ReadLine();

            Console.WriteLine("Identification:");
            string cedula = Console.ReadLine();

            Console.WriteLine("Sex \n1.Male \n2.Female");
            int sex = Convert.ToInt16(Console.ReadLine());

            if (name == "" || last_name == "" || cedula == "")
            {
                Console.WriteLine("Is empty");
                Console.Read();
                Menu();
            }
            var new_human = new Human()
            {
                Id = IdCounter,
                Name = name,
                LastName = last_name,
                Cedula = cedula,
                Sex = (sex > 1) ? (int?)SexType.Female : (int?)SexType.Male
            };
            HumanCRUD.Create(new_human);
            IdCounter++;
            Menu();
        }

        static void UpdateHuman()
        {
            Console.WriteLine("Choose from the list:");
            var id = Convert.ToInt16(Console.ReadLine());

            var old_human = HumanCRUD.GetById(id);

            Console.WriteLine("New Name:");
            string name = Console.ReadLine();

            Console.WriteLine("New Last Name:");
            string last_name = Console.ReadLine();

            Console.WriteLine("New Identification:");
            string cedula = Console.ReadLine();

            if (name == "" || last_name == "" || cedula == "")
            {
                Console.WriteLine("Is empty");
                Console.Read();
                Menu();
            }
            var new_human = new Human()
            {
                Id = old_human.Id,
                Name = name,
                LastName = last_name,
                Cedula = cedula,
                Sex = old_human.Id
            };
            HumanCRUD.Update(new_human);
            Menu();
        }

        static void DeleteHuman()
        {
            Console.WriteLine("Choose from the list:");
            var id = Convert.ToInt16(Console.ReadLine());

            var result = HumanCRUD.Delete(id);

            if (!result)
            {
                Console.WriteLine("Error, human not found");
                Console.Read();
                Menu();
            }
            Menu();
        }

        static void GetHumanById()
        {
            Console.WriteLine("Choose from the list:");
            var id = Convert.ToInt16(Console.ReadLine());

            var human = HumanCRUD.GetById(id);
            if (human == null)
            {
                Menu();
            }

            Console.WriteLine($"{human.Id}. {human.Name} {human.LastName}\n");
            Console.WriteLine("Want to run? 1.Yes\n2.No");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                human.Run();
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
