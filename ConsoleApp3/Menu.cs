using System;
namespace GraphVersionThree
{
	public class Menu
	{
        private MenuOptions controller;
        public StationCreation stations;
        private Logger logger;

        public Menu()
        {
            stations = new StationCreation();
            controller = new MenuOptions(stations.controller);
            logger = new Logger();
        }


        public void runMenu()
        {
            while (true)
            {
                logger.Log("##################################");
                logger.Log("#      Transport for London      #");
                logger.Log("#    Getting you there faster    #");
                logger.Log("################################## ");
                logger.Log("\n");
                logger.Log("\n");
                logger.Log("1. Customer Menu ");
                logger.Log("2. Admin Menu ");
                logger.Log("\n");
                logger.Log("   Please enter your choice: ");

                int option = int.TryParse(Console.ReadLine(), out int inputValue) ? inputValue : -1;

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
                            logger.Log("Please enter a number between 1 - 2");
                        }
                        break;
                }
            }
        }
    }
}

