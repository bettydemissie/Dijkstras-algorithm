using System;
namespace GraphVersionThree
{
	public class MenuOptions
	{
        private GraphController controller;
        private const int adminPassword = 0000;
        private Logger logger;


        public MenuOptions(GraphController controller)
        {
            this.controller = controller;
            logger = new Logger();

        }

        public void managerMenu()
        {
            logger.Log("Please enter the secret password to access this menu");
            int inputPassword = int.TryParse(Console.ReadLine(), out int inputValue) ? inputValue : -1;
            

            if (inputPassword == adminPassword)
            {
                logger.Log("##################################");
                logger.Log("#      Transport for London      #");
                logger.Log("#    Getting you there faster    #");
                logger.Log("################################## ");
                logger.Log("\n");
                logger.Log("\n");
                logger.Log("1. Add or Remove journey walking time delays ");
                logger.Log("2. Indicate a route is possible or becomes impossible by Opening or Closing Station Network");
                logger.Log("3. Print out list of impossible walking routes ");
                logger.Log("4. Print out list of delayed routes with normal time and delayed time ");
                logger.Log("\n");
                logger.Log("   Please enter your choice: ");

                int managerOption = int.TryParse(Console.ReadLine(), out int inputValue2) ? inputValue2 : -1;


                switch (managerOption)
                {
                    case 1:
                        {
                            //add/remove delay
                            logger.Log("What is the Station you would like to start from?");
                            string sourceStation = Convert.ToString(Console.ReadLine()) ?? ""; //if no input string is then null

                            logger.Log("What is the Station you would like to end at?");  //if no input string is then null
                            string destStation = Convert.ToString(Console.ReadLine()) ?? "";

                            logger.Log("What is the line name?");  //if no input string is then null
                            string line = Convert.ToString(Console.ReadLine()) ?? "";

                            logger.Log("What is the delay time?");
                            int delay = Convert.ToInt32(Console.ReadLine());

                            controller.AddDelayToNetwork(sourceStation, destStation, line, delay);
                        }
                        break;

                    case 2:
                        {
                            //indicate a route is impossible or becomes possible

                            logger.Log("What is the Station you would like to start from?");
                            string? sourceStation = Convert.ToString(Console.ReadLine()) ?? ""; //if no input string is then empty

                            logger.Log("What is the Station you would like to end at?");  //if no input string is then empty
                            string destStation = Convert.ToString(Console.ReadLine()) ?? "";

                            logger.Log("What is the line name?");  //if no input string is then empty
                            string line = Convert.ToString(Console.ReadLine()) ?? "";

                            logger.Log("What is the reason?");  //if no input string is then empty
                            string reason = Convert.ToString(Console.ReadLine()) ?? "";

                            logger.Log("What would be the boolean status? Enter boolean value (true/false) false to close and true to open");
                            bool closeStatus = Convert.ToBoolean(Console.ReadLine());

                            controller.OpenOrCloseStationsNetwork(sourceStation, destStation, line, reason, closeStatus);
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

                    default:
                        {
                            logger.Log("Please enter a number between 1 - 4");
                        }
                        break;
                }
            }

            else
            {
                logger.Log("Incorrect Password");
            }
        }

        public void customerMenu()
        {
            logger.Log("##################################");
            logger.Log("#      Transport for London      #");
            logger.Log("#    Getting you there faster    #");
            logger.Log("################################## ");
            logger.Log("");
            logger.Log("\n");
            logger.Log("1. Find the fastest route between two stations ");
            logger.Log("2. Display Tube Information ");
            logger.Log("\n");
            logger.Log("   Please enter your choice: ");

            int customerOption = int.TryParse(Console.ReadLine(), out int inputValue) ? inputValue : -1;

            switch (customerOption)
            {
                case 1:
                    {

                        logger.Log("What is the Station you would like to start from?");
                        string? sourceStation = Convert.ToString(Console.ReadLine()) ?? "";

                        if (!sourceStation.GetType().Equals(typeof(string)))
                        {
                            throw new ArgumentException("Input string must be a string data type.", "sourceStation");
                        }

                        logger.Log("What is the Station you would like to end at?");
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
                        logger.Log("What is the Station you would like to get the information of?");
                        string? sourceStation = Convert.ToString(Console.ReadLine()) ?? "";

                        if (!sourceStation.GetType().Equals(typeof(string)))
                        {
                            throw new ArgumentException("Input string must be a string data type.", "sourceStation");
                        }

                        controller.DisplayTubeInformation(sourceStation);
                    }
                    break;

                default:
                    {
                        logger.Log("Please enter a number between 1 - 2");
                    }
                    break;
            }


        }
    }
}

