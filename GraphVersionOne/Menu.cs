using System;
using System.Drawing;

namespace ConsoleApp3
{
	public class Menu
	{
		private GraphController controller;

		public Menu()
		{
			controller = new GraphController();
		}

        public void managerMenu()
        {
            Console.WriteLine("Please enter the secret password to access this menu");
            int password = Convert.ToInt32(Console.ReadLine());

            switch (password)
            {

            }

        }

        public void customerMenu()
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

            int customerOption = Convert.ToInt32(Console.ReadLine());

            switch (customerOption)
            {
                case 1:
                    {

                        Console.WriteLine("What is the Station you would like to start from?");
                        string sourceStation = Convert.ToString(Console.ReadLine()) ?? "";

                        if (!sourceStation.GetType().Equals(typeof(string)))
                        {
                            throw new ArgumentException("Input string must be a string data type.", "sourceStation");
                        }

                        Console.WriteLine("What is the Station you would like to start from?");
                        string destStation = Convert.ToString(Console.ReadLine()) ?? "";

                        if (!destStation.GetType().Equals(typeof(string)))
                        {
                            throw new ArgumentException("Input string must be a string data type.", "destStation");
                        }

                        controller.FindFastestWalkingRoutes(sourceStation,destStation);
                    }
                    break;

                case 2:
                    {

                    }
                    break;
            }


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
                       //access customer menu
                    }

                    break;

                case 2:
                    {
                        //access manager menu
                    }

                    break;

                default:
                    {
                        Console.WriteLine("Please enter a number between 1 - 2");
                    }
                    break;
            }
        }

        public void DoSomething(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str", "Input string cannot be null.");
            }
            else if (!str.GetType().Equals(typeof(string)))
            {
                throw new ArgumentException("Input string must be a string data type.", "str");
            }

            // rest of your code here...
        }

    }
}

