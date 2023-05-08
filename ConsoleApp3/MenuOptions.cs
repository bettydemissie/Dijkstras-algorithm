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
                            logger.Log("What is the Station you would like to start from?");
                            string sourceStation;

                            // Loop until a valid input is entered
                            while (true)
                            {
                                sourceStation = Console.ReadLine();

                                // Check if the input is not null or empty and contains only letters and spaces
                                if (!string.IsNullOrWhiteSpace(sourceStation) && sourceStation.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                                {
                                    break; // Exit the loop if input is valid
                                }

                                // Prompt the user to enter a valid input
                                logger.Log("Please enter a valid string for the station name (letters and spaces only):");
                            }

                            logger.Log("What is the Station you would like to end at?");
                            string destStation;

                            // Loop until a valid input is entered
                            while (true)
                            {
                                destStation = Console.ReadLine();

                                // Check if the input is not null or empty and contains only letters and spaces
                                if (!string.IsNullOrWhiteSpace(destStation) && destStation.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                                {
                                    break; // Exit the loop if input is valid
                                }

                                // Prompt the user to enter a valid input
                                logger.Log("Please enter a valid string for the station name (letters and spaces only):");
                            }

                            logger.Log("What is the line name?");
                            string line;
                            while (true)
                            {
                                line = Console.ReadLine();

                                if (!string.IsNullOrWhiteSpace(line) && line.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                                {
                                    break; // Exit the loop if input is valid
                                }
                                logger.Log("Invalid input. Please enter a valid line name:");
                            }


                            logger.Log("What is the delay time?");
                            int delay;
                            while (true)
                            {
                                string input = Console.ReadLine();

                                if (int.TryParse(input, out delay) && delay > 0)
                                {
                                    break; // Exit the loop if input is valid
                                }

                                logger.Log("Please enter a valid positive integer for the delay time:");
                            }

                            controller.AddDelayToNetwork(sourceStation, destStation, line, delay);
                        }
                        break;

                    case 2:
                        {
                            logger.Log("What is the Station you would like to start from?");
                            string sourceStation;

                            // Loop until a valid input is entered
                            while (true)
                            {
                                sourceStation = Console.ReadLine();

                                // Check if the input is not null or empty and contains only letters and spaces
                                if (!string.IsNullOrWhiteSpace(sourceStation) && sourceStation.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                                {
                                    break; // Exit the loop if input is valid
                                }

                                // Prompt the user to enter a valid input
                                logger.Log("Please enter a valid string for the station name (letters and spaces only):");
                            }

                            logger.Log("What is the Station you would like to end at?");
                            string destStation;

                            // Loop until a valid input is entered
                            while (true)
                            {
                                destStation = Console.ReadLine();

                                // Check if the input is not null or empty and contains only letters and spaces
                                if (!string.IsNullOrWhiteSpace(destStation) && destStation.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                                {
                                    break; // Exit the loop if input is valid
                                }

                                // Prompt the user to enter a valid input
                                logger.Log("Please enter a valid string for the station name (letters and spaces only):");
                            }

                            logger.Log("What is the line name?");
                            string line;

                            // Loop until a valid input is entered
                            while (true)
                            {
                                line = Console.ReadLine();

                                // Check if the input is not null or empty and contains only letters and spaces
                                if (!string.IsNullOrWhiteSpace(line) && line.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                                {
                                    break; // Exit the loop if input is valid
                                }

                                // Prompt the user to enter a valid input
                                logger.Log("Please enter a valid string for the line name (letters and spaces only):");
                            }

                            logger.Log("What is the reason?");
                            string reason;

                            // Loop until a valid input is entered
                            while (true)
                            {
                                reason = Console.ReadLine();

                                // Check if the input is not null or empty and contains only letters and spaces
                                if (!string.IsNullOrWhiteSpace(reason) && reason.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                                {
                                    break; // Exit the loop if input is valid
                                }

                                // Prompt the user to enter a valid input
                                logger.Log("Please enter a valid string for the reason (letters and spaces only):");
                            }

                            logger.Log("What would be the boolean status? Enter boolean value (true/false) false to close and true to open");
                            bool closeStatus;

                            // Loop until a valid input is entered
                            while (true)
                            {
                                if (bool.TryParse(Console.ReadLine(), out closeStatus))
                                {
                                    break; // Exit the loop if input is valid
                                }

                                // Prompt the user to enter a valid input
                                logger.Log("Please enter a valid boolean value (true/false):");
                            }


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
                        string sourceStation;

                        // Loop until a valid input is entered
                        while (true)
                        {
                            sourceStation = Console.ReadLine();

                            // Check if the input is not null or empty and contains only letters and spaces
                            if (!string.IsNullOrWhiteSpace(sourceStation) && sourceStation.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                            {
                                break; // Exit the loop if input is valid
                            }

                            // Prompt the user to enter a valid input
                            logger.Log("Please enter a valid string for the station name (letters and spaces only):");
                        }



                        logger.Log("What is the Station you would like to end at?");
                        string destStation;

                        // Loop until a valid input is entered
                        while (true)
                        {
                            destStation = Console.ReadLine();

                            // Check if the input is not null or empty and contains only letters and spaces
                            if (!string.IsNullOrWhiteSpace(destStation) && destStation.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                            {
                                break; // Exit the loop if input is valid
                            }

                            // Prompt the user to enter a valid input
                            logger.Log("Please enter a valid string for the station name (letters and spaces only):");
                        }


                        controller.FindFastestWalkingRoutes(sourceStation, destStation);
                    }
                    break;

                case 2:
                    {
                        logger.Log("What is the Station you would like to get the information of?");
                        string sourceStation;

                        // Loop until a valid input is entered
                        while (true)
                        {
                            sourceStation = Console.ReadLine();

                            // Check if the input is not null or empty and contains only letters and spaces
                            if (!string.IsNullOrWhiteSpace(sourceStation) && sourceStation.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                            {
                                break; // Exit the loop if input is valid
                            }

                            // Prompt the user to enter a valid input
                            logger.Log("Please enter a valid string for the station name (letters and spaces only):");
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

