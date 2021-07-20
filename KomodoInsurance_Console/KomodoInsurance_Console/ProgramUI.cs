using KomodoInsurance_Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Console
{
    class ProgramUI
    {
        public DeveloperRepo _devRepo = new DeveloperRepo();
        public DevTeamRepo _teamRepo = new DevTeamRepo();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        // Display Welcome Message and Options
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                // Display menu options
                Console.WriteLine("Welcome to Komodo Insurance's Developer Team Management! Please choose from the following options:\n" +
                    "1. View All Developers\n" +
                    "2. View or Edit Developer Teams\n" +
                    "3. Add Developer\n" +
                    "4. Remove Developer\n" +
                    "5. View Developers who need PluralSight license\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input) { 
                        case "1":
                            ViewListOfDevs();
                            Console.ReadLine();
                            break;
                        case  "2":
                        // Redirect to Team Submenu
                            TeamSubmenu();
                            break;
                        case "3":
                            AddDeveloper();
                            Console.ReadLine();
                            break;
                        case "4":
                            RemoveDeveloper();
                            Console.ReadLine();
                            break;
                        case "5":
                            // view licenses
                            DisplayDevsWithoutLicense();
                            Console.ReadLine();
                            break;
                        case "6": 
                            // Exit program
                            Console.WriteLine("Thank you! Have a great day!");
                            Console.ReadLine();
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid response.");
                            break;
                    }
            }
        }
        private void TeamSubmenu()
        {
            Console.Clear();
            ViewAllTeams();
            Console.WriteLine("Your current teams are listed above. What would you like to do?\n" +
                "1. View members of a team\n" +
                "2. Add member(s) to a team\n" +
                "3. Remove member(s) from a team\n" +
                "4. Add a new team\n" +
                "5. Remove an existing team\n" +
                "6. Back to main menu");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    // View team member of a specific team ID
                    ViewTeamMembers();
                    Console.ReadLine();
                    break;
                case "2":
                    // Add team member by team ID and Developer ID
                    AddMultipleDevelopersToTeam();
                    Console.ReadLine();
                    break;
                case "3":
                    // Remove a team member by team ID and Developer ID
                    RemoveTeamMember();
                    Console.ReadLine();
                    break;
                case "4":
                    // Add an entire new team
                    CreateNewTeam();
                    Console.ReadLine();
                    break;
                case "5":
                    // Remove an entire team
                    RemoveEntireTeam();
                    Console.ReadLine();
                    break;
                case "6":
                    // Exit back to main menu
                    break;
                default:
                    Console.WriteLine("Please enter a valid number.");
                    Console.ReadLine();
                    break;
            }
        }
        // All methods used in menus listed below
        // Add methods:
        private void AddDeveloper()
        {
            Console.Clear();
            Developer newDev = new Developer();

            Console.WriteLine("Enter the First Name:");
            newDev.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the Last Name:");
            newDev.LastName = Console.ReadLine();

            Console.WriteLine("Enter Employee ID:");
            newDev.ID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Do they have a PluralSight license? (y/n)");
            string licenseString = Console.ReadLine().ToLower();

            if (licenseString == "y")
            {
                newDev.HasPSAccess = true;
            }
            else
            {
                newDev.HasPSAccess = false;
            }
            foreach (Developer developer in _devRepo._listOfDevelopers)
            {
                if (newDev.ID == developer.ID)
                {
                    Console.WriteLine("This ID is already in use. ID must be unique. Please try again.");
                    break;
                }
            }
            _devRepo.AddNewDeveloper(newDev);
            if (newDev != null)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("An error occured. Please try again.");
            }
        }
        // FINAL CHALLENGE...how do we make this work?
        private void AddMultipleDevelopersToTeam()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the team you wish to add members to:");
            int teamID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("How many members would you like to add?");
            int count = Int32.Parse(Console.ReadLine());

            Developer[] _developersToAdd = new Developer[count];
            while(count > 0)
            {
                Console.WriteLine("Please enter an ID number:");
                int devID = Int32.Parse(Console.ReadLine());
                Developer dev = _devRepo.GetDevByID(devID);
                int x = count - 1;
                _developersToAdd[x] = dev;
                count--;
            }
           DevTeam team = _teamRepo.GetTeamByID(teamID);
           team._teamMembers.AddRange(_developersToAdd);
           Console.WriteLine("Team Added Successfully");
        }
        
        /* THIS METHOD IS NO LONGER USED -- updated with "AddMultipleDevelopersToTeam();
          private void AddTeamMember()
        {
            Console.Clear();
            Console.WriteLine("Please enter the ID of the team you would like add a member to:");
            int teamID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the ID of the developer you would like to add:");
            int devID = Int32.Parse(Console.ReadLine());

            DevTeam team = _teamRepo.GetTeamByID(teamID);
            Developer dev = _devRepo.GetDevByID(devID);
            if (dev != null && team != null)
            {
                team._teamMembers.Add(dev);
                Console.WriteLine("Member Added!");
            }
            else
            {
                Console.WriteLine("Invalid ID(s). Please try again.");
            }
        } */
        private void CreateNewTeam()
        {
            Console.Clear();
            DevTeam newTeam = new DevTeam();

            Console.WriteLine("Enter the Team Name:");
            newTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Enter the Team ID:");
            newTeam.TeamID = Int32.Parse(Console.ReadLine());

            foreach (DevTeam team in _teamRepo._listOfTeams)
            {
                if (newTeam.TeamID == team.TeamID)
                {
                    Console.WriteLine("That team ID is already in use. ID must be unique. Please try again.");
                    break;
                }
            }
            _teamRepo.AddNewTeam(newTeam);
            Console.WriteLine("Team added successfully!");
        }
        // Remove methods:
        private void RemoveDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Please enter the ID of the developer you would like to remove from the system:");
            int devID = Int32.Parse(Console.ReadLine());
            bool wasRemoved = _devRepo.RemoveDeveloper(devID);
            if (wasRemoved)
            {
                Console.WriteLine("Developer removed from system. Press any key to return to the main menu.");
            }
            else
            {
                Console.WriteLine("An error occured. Exiting to main menu...");
            }
        }
        private void RemoveEntireTeam()
        {
            Console.Clear();
            Console.WriteLine("Please enter the ID of the team you would like to remove:");
            int id = Int32.Parse(Console.ReadLine());
            bool wasRemoved = _teamRepo.RemoveTeam(id);
            if (wasRemoved)
            {
                Console.WriteLine("Team removed from system. Press any key to return to the main menu.");
            }
        }
        private void RemoveTeamMember()
        {
            Console.Clear();
            Console.WriteLine("Please enter the ID of the team you would like to remove a member from:");
            int teamID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the ID of the team member you would like to remove:");
            int devID = Int32.Parse(Console.ReadLine());

            _teamRepo.RemoveDevFromTeam(teamID, devID);
            Console.WriteLine("Removed developer from team.");
        }
        // View Methods:
        private void ViewListOfDevs()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _devRepo.GetDeveloperList();
            foreach (Developer dev in listOfDevelopers)
            {
                Console.WriteLine($"Name: {dev.FirstName} {dev.LastName} ID: {dev.ID}\n");
            }
        }
        private void DisplayDevsWithoutLicense()
        {
            Console.Clear();
            Console.WriteLine("The following developers do not have a PluralSight license:");
            List<Developer> listOfDevelopers = _devRepo.GetDeveloperList();
            foreach (Developer dev in listOfDevelopers)
            {
                if (!dev.HasPSAccess)
                {
                    Console.WriteLine($"Name:{dev.FirstName} {dev.LastName} ID: {dev.ID}\n");
                }
            }
        }
        private void ViewAllTeams()
        {
            Console.Clear();
            List<DevTeam> listOfTeams = _teamRepo.GetTeamList();
            foreach (DevTeam team in listOfTeams)
            {
                Console.WriteLine($"Team Name: {team.TeamName} ID: {team.TeamID}\n");
            }
        }
        private void ViewTeamMembers()
        {
            Console.Clear();
            Console.WriteLine("Enter the Team ID for the team you would like to view:");
            int id = Int32.Parse(Console.ReadLine());
            List<Developer> team = _teamRepo.ViewTeam(id);
            int memberCount = team.Count();
            if (memberCount > 0)
            {
                foreach (Developer dev in team)
                {
                    Console.WriteLine($"Team Member:{dev.FirstName} {dev.LastName} ID: {dev.ID}\n");
                }
            }
            else
            {
                Console.WriteLine("No members on this team.");
            }
        }
        // Other:
        public void SeedContent()
        {
            _devRepo._listOfDevelopers.Add(new Developer("Hermione", "Granger", 10, true));
            _devRepo._listOfDevelopers.Add(new Developer("Ronald", "Weasley", 20, true));
            _devRepo._listOfDevelopers.Add(new Developer("Harry", "Potter", 30, false));
            _devRepo._listOfDevelopers.Add(new Developer("Luna", "Lovegood", 40, false));
            _devRepo._listOfDevelopers.Add(new Developer("Draco", "Malfoy", 50, true));

            _teamRepo._listOfTeams.Add(new DevTeam("Alpha Team", 100));
            _teamRepo._listOfTeams.Add(new DevTeam("Beta Team", 200));
        }
    }
}
