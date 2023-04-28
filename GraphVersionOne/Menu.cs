using System;
using System.Drawing;

namespace ConsoleApp3
{
	public class Menu
	{
		private MenuOptions controller;
        public StationCreation stations;

		public Menu()
		{
            stations = new StationCreation();
            controller = new MenuOptions(stations.controller);
        }


        public void runMenu()
        {
            while (true)
            {
                Console.WriteLine("##################################");
                Console.WriteLine("#      Transport for London      #");
                Console.WriteLine("#    Getting you there faster    #");
                Console.WriteLine("################################## ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Customer Menu ");
                Console.WriteLine("2. Admin Menu ");
                Console.WriteLine();
                Console.WriteLine("   Please enter your choice: ");


                //perform necessary checks for input
                //int option = Convert.ToInt32(Console.ReadLine());
                //int.TryParse(Console.ReadLine(), out option);

                int option = int.TryParse(Console.ReadLine(), out int inputValue) ? inputValue : 0;



                //if (!option.GetType().Equals(typeof(int)))
                //{
                //    throw new ArgumentException("Input must be an integer data type.", "option");
                //}

                switch (option)
                {
                    case 1:
                        {
                            controller.customerMenu();
                        }

                        break;

                    case 2:
                        {
                            controller.managerMenu();
                        }

                        break;

                    default:
                        {
                            Console.WriteLine("Please enter a number between 1 - 2");
                        }
                        break;
                }
            }
        }
            
    }
}

