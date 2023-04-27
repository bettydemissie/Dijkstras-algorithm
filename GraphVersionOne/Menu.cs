using System;
using System.Drawing;

namespace ConsoleApp3
{
	public class Menu
	{
		private MenuController controller;
        public StationCreation stations;

		public Menu()
		{
            stations = new StationCreation();
            controller = new MenuController(stations.controller);
        }


        public void runMenu()
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
            int option = Convert.ToInt32(Console.ReadLine());

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

