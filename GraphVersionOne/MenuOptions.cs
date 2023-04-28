using System;
namespace ConsoleApp3
{
	public class MenuOptions
	{

        private GraphController controller;
        private const int adminPassword = 0000;

        public MenuOptions(GraphController controller)
		{
            this.controller = controller;

        }

        public void managerMenu()
        {
            Console.WriteLine("Please enter the secret password to access this menu");
            //int inputPassword = Convert.ToInt32(Console.ReadLine());
            int inputPassword = int.TryParse(Console.ReadLine(), out int inputValue) ? inputValue : -1;



            if (inputPassword == adminPassword)
            {
                Console.WriteLine("##################################");
                Console.WriteLine("#      Transport for London      #");
                Console.WriteLine("#    Getting you there faster    #");
                Console.WriteLine("################################## ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Add or Remove journey walking time delays ");
                Console.WriteLine("2. Indicate a route is possible or becomes impossible ");
                Console.WriteLine("3. Print out list of impossible walking routes ");
                Console.WriteLine("4. Print out list of delayed routes with normal time and delayed time ");
                Console.WriteLine("5. Open or Close Station ");
                Console.WriteLine();
                Console.WriteLine("   Please enter your choice: ");

                //int managerOption = Convert.ToInt32(Console.ReadLine());
                int managerOption = int.TryParse(Console.ReadLine(), out int inputValue2) ? inputValue2 : -1;


                switch (managerOption)
                {
                    case 1:
                        {
                            //add/remove delay
                            Console.WriteLine("What is the Station you would like to start from?");
                            string sourceStation = Convert.ToString(Console.ReadLine()) ?? ""; //if no input string is then null

                            Console.WriteLine("What is the Station you would like to end at?");  //if no input string is then null
                            string destStation = Convert.ToString(Console.ReadLine()) ?? "";

                            Console.WriteLine("What is the line name?");  //if no input string is then null
                            string line = Convert.ToString(Console.ReadLine()) ?? "";

                            Console.WriteLine("What is the delay time?");
                            int delay = Convert.ToInt32(Console.ReadLine());

                            controller.AddDelayToNetwork(sourceStation, destStation, line, delay);
                        }
                        break;

                    case 2:
                        {
                            //indicate a route is impossible or becomes possible
                        }
                        break;

                    case 3:
                        {
                            controller.PrintAllClosedRoutes();
                        }
                        break;

                    case 4:
                        {
                            controller.PrintAllDelayedRoutes();
                        }
                        break;

                    case 5:
                        {
                            Console.WriteLine("What is the Station you would like to start from?");
                            string? sourceStation = Convert.ToString(Console.ReadLine()) ?? ""; //if no input string is then null

                            Console.WriteLine("What is the Station you would like to end at?");  //if no input string is then null
                            string? destStation = Convert.ToString(Console.ReadLine()) ?? "";

                            Console.WriteLine("What is the line name?");  //if no input string is then null
                            string line = Convert.ToString(Console.ReadLine()) ?? "";

                            Console.WriteLine("What is the reason for closure?");  //if no input string is then null
                            string reason = Convert.ToString(Console.ReadLine()) ?? "";

                            bool closeStatus = true;

                            controller.OpenOrCloseStationsNetwork(sourceStation, destStation, line, reason, closeStatus);
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Please enter a number between 1 - 5");
                        }
                        break;
                }
            }

            else
            {
                Console.WriteLine("Incorrect Password");
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
            Console.WriteLine("1. Find the fastest route between two stations ");
            Console.WriteLine("2. Display Tube Information ");
            Console.WriteLine();
            Console.WriteLine("   Please enter your choice: ");

            //int customerOption = Convert.ToInt32(Console.ReadLine());
            int customerOption = int.TryParse(Console.ReadLine(), out int inputValue) ? inputValue : -1;


            switch (customerOption)
            {
                case 1:
                    {

                        Console.WriteLine("What is the Station you would like to start from?");
                        string? sourceStation = Convert.ToString(Console.ReadLine()) ?? "";

                        if (!sourceStation.GetType().Equals(typeof(string)))
                        {
                            throw new ArgumentException("Input string must be a string data type.", "sourceStation");
                        }

                        Console.WriteLine("What is the Station you would like to end at?");
                        string? destStation = Convert.ToString(Console.ReadLine()) ?? "";

                        if (!destStation.GetType().Equals(typeof(string)))
                        {
                            throw new ArgumentException("Input string must be a string data type.", "destStation");
                        }

                        controller.FindFastestWalkingRoutes(sourceStation, destStation);
                    }
                    break;

                case 2:
                    {
                        Console.WriteLine("What is the Station you would like to get the information of?");
                        string sourceStation = Convert.ToString(Console.ReadLine()) ?? "";

                        if (!sourceStation.GetType().Equals(typeof(string)))
                        {
                            throw new ArgumentException("Input string must be a string data type.", "sourceStation");
                        }

                        controller.DisplayTubeInformation(sourceStation);
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

