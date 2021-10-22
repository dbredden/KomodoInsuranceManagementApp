using KomodoInsuranceClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceConsoleApp
{
    public class ProgramUI
    {
        private readonly DeveloperRepository _developerRepository = new DeveloperRepository();
        private readonly DevTeamRepository _devTeamRepository = new DevTeamRepository();

        public void RunMenu()
        {
            Console.WriteLine("Hello! Welcome to Komodo Insurance's HR Platform.\n" +
                "----------------------------------------------------------------------------------------\n" +
                "Here is where we can create and interact with our developers and build developer teams.\n" +
                "Enter the number of the option you would like to select: \n" +
                "----------------------------------------------------------------------------------------\n" +
                "1. Create a new developer \n" +
                "2. Show all developers \n" +
                "3. Find developers who don't have pluralsight access \n" +
                "4. Add developer to team \n" +
                "5. Delete a developer \n" +
                "6. Exit \n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    CreateNewDev();
                    Console.Clear();
                    RunMenu();
                    break;
                case "2":
                    ListAllDevs();
                    Console.Clear();
                    RunMenu();
                    break;
                case "3":
                    ListDevsWithNoAccess();
                    Console.Clear();
                    RunMenu();
                    break;
                case "4":
                    AddDevsToTeam();
                    break;
                case "5":
                    DeleteDeveloper();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter in a valid number between 1 and 5. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
        // Below method relates to Case 1
        private void CreateNewDev()
        {
            Developer developer = new Developer();
            Console.WriteLine("Time to create a new developer. \n" +
                "Let's get started! \n" +
                "Please enter the developers first name: ");
            developer.FirstName = Console.ReadLine();

            Console.WriteLine("Please enter the developers last name: ");
            developer.LastName = Console.ReadLine();

            Console.WriteLine("What is the developers ID number?: ");
            developer.DevID = int.Parse(Console.ReadLine());

            Console.WriteLine("Press Y to give this users Pluralsight Access: ");
            string PluralsightAccess = Console.ReadLine();
            if (PluralsightAccess == "Y")
            {
                Console.WriteLine($"You gave {developer.FirstName} access to Pluralsight");
                developer.PluralsightAccess = true;
            }
            else
            {
                Console.WriteLine($"You didn't give {developer.FirstName} access to Pluralsight");
            }
            _developerRepository.AddDeveloperToDirectory(developer);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
        // Below method relates to Case 2
        private void ListAllDevs()
        {
            List<Developer> listOfDevelopers = _developerRepository.GetAllDevelopers();

            foreach(Developer devVariable in listOfDevelopers)
            {
                DisplayContent(devVariable);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        // Below method relates to Case 3
        private void ListDevsWithNoAccess()
        {
            List<Developer> listOfDevelopers = _developerRepository.GetDevelopersByAccess();

            foreach(Developer devVariable in listOfDevelopers)
            {
                DisplayContent(devVariable);
                Console.WriteLine("--------------------------");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        // Below method relates to Case 4
        private void AddDevsToTeam()
        {
            DevTeam devTeam = new DevTeam();
            Console.WriteLine("First let's create a new team\n" +
                "What is the team name?: ");
            devTeam.TeamName = Console.ReadLine();

            Console.WriteLine("What is the team ID? ");
            devTeam.TeamID = int.Parse(Console.ReadLine());

            List<Developer> devIdInput = new List<Developer>();
            Console.WriteLine("Enter the developer ID numbers you wish to add to this team");
            int input = int.Parse(Console.ReadLine());
            var dev = _developerRepository.GetDeveloperById(input);
            devIdInput.Add(dev);
            _devTeamRepository.CreateDevTeam(devTeam);
            Console.WriteLine("Press any key to continue...");
        }
        // Below method related to Case 5
        private void DeleteDeveloper()
        {
            Console.WriteLine("Enter the ID of the developer you wish to remove: ");
            List<Developer> devList = _developerRepository.GetAllDevelopers();
            int count = 0;
            foreach(Developer dev in devList)
            {
                count++;
                Console.WriteLine($"{ count}.{ dev.DevID}");
            }

            int targetDevId = int.Parse(Console.ReadLine());
            int targetIndex = targetDevId - 1;
            if (targetIndex >= 0 && targetIndex < devList.Count)
            {
                Developer desiredDev = devList[targetIndex];
                if (_developerRepository.DeleteExistingDeveloper(desiredDev))
                {
                    Console.WriteLine($"{desiredDev.DevID} successfully removed.");
                }
                else
                {
                    Console.WriteLine("Developer was not successfully removed.");
                }
            }
            else
            {
                Console.WriteLine("No Developer has that ID");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void DisplayContent(Developer developer)
        {
            Console.WriteLine($"First Name: {developer.FirstName}");
            Console.WriteLine($"Last Name: {developer.LastName}");
            Console.WriteLine($"Developer ID: {developer.DevID}");
            Console.WriteLine($"Pluralsight Access: {developer.PluralsightAccess}");
        }
    }
}
