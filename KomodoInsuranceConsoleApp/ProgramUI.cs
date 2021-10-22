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
        // USER Interface
        // host user interactions
        // point of app is for the users to interact with their collection so they can keep an up to date collection of their streaming content at that time
        // CRUD

        public void RunMenu()
        {
            Console.WriteLine("Hello! Welcome to Komodo Insurance's HR Platform.\n" +
                "Here is where we can create and interact with our developers and build developer teams.\n" +
                "Enter the number of the option you would like to select: \n" +
                "1. Create a new developer \n" +
                "2. Show all developers \n" +
                "3. Find developers who don't have pluralsight access \n" +
                "4. Add developer to team \n" +
                "5. Add multiple developers to team \n" +
                "6. Delete a developer \n" +
                "7. Exit \n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    CreateNewDev();
                    RunMenu();
                    break;
                case "2":
                    ListAllDevs();
                    RunMenu();
                    break;
                case "3":
                    ListDevsWithNoAccess();
                    RunMenu();
                    break;
                case "4":
                    AddDevsToTeam();
                    break;
                case "5":
                    DeleteDeveloper();
                    break;
                    // delete a developer
                default:
                    Console.WriteLine("Please enter in a valid number between 1 and 7. \n" +
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
            Console.ReadKey();

            // AddDevelopertoDirectory takes in deeloper and adds it to my collection

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
            Console.WriteLine("Press any key to continue");
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
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }

        // Below method relates to Case 4
        private void AddDevsToTeam()
        {
            List<Developer> devIdInput = new List<Developer>();

            Console.WriteLine("Enter the developer ID numbers you wish to add to a team");
            int input = int.Parse(Console.ReadLine());
            //look through a collection based 
            var dev = _developerRepository.GetDeveloperById(input);
            devIdInput.Add(dev);

            var newDevTeam = dev;
            //_devTeamRepository.CreateDevTeam(newDevTeam);




            // Create the team here and add that list devIdInput to that team
            // pass in list to my create dev team method
            //make it add multiple devs (do you want to add another dev? main menu, etc)
            // add to dev team repository - get team by ID maybe get the team id before we get the dev id
        }

        // Below method related to Case 5
        private void DeleteDeveloper()
        {
            Console.WriteLine("Enter the developer ID that is associated \n" +
                "to the developer that you like to remove from the database: ");
            Console.WriteLine("You deleted developer ID");
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
