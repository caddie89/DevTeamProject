using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamProject_Console
{
    class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        public void Run()
        {
            SeedDevList();
            SeedTeamList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Please select an option from the menu below (i.e. 1, 2, 3, etc.):\n\n" +
                    "1.  Create New Developer\n" +
                    "2.  Create New Team\n" +
                    "3.  Add Developers to Team\n" +
                    "4.  View All Developers\n" +
                    "5.  View All Teams\n" +
                    "6.  View Developer by ID\n" +
                    "7.  View Team by ID\n" +
                    "8.  View Developers Needing a Pluralsight License\n" +
                    "9.  Update Existing Developer\n" +
                    "10. Update Existing Team\n" +
                    "11. Delete Existing Developer\n" +
                    "12. Delete Existing Team\n" +
                    "13. Delete Developers from Team\n" +
                    "14. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewDev();
                        break;
                    case "2":
                        CreateNewTeam();
                        break;
                    case "3":
                        AddDevelopersToTeam();
                        break;
                    case "4":
                        ViewAllDevs();
                        break;
                    case "5":
                        ViewAllTeams();
                        break;
                    case "6":
                        ViewDevByID();
                        break;
                    case "7":
                        ViewTeamByID();
                        break;
                    case "8":
                        ViewDevsWithNoPlural();
                        break;
                    case "9":
                        UpdateDev();
                        break;
                    case "10":
                        UpdateTeam();
                        break;
                    case "11":
                        DeleteDev();
                        break;
                    case "12":
                        DeleteTeam();
                        break;
                    case "13":
                        DeleteDevelopersFromTeam();
                        break;
                    case "14":
                        Console.WriteLine("Goodbye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid number option.\n");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Create New Developer
        private void CreateNewDev()
        {
            ViewAllDevs();

            DeveloperInformation newDeveloper = new DeveloperInformation();

            //Developer ID
            Console.WriteLine("Assign a unique 5-digit Developer ID:");
            string devID = Console.ReadLine();
            newDeveloper.DevID = int.Parse(devID);

            //Developer Name
            Console.WriteLine("\nEnter the Developer's full name (First & Last):");
            newDeveloper.DevName = Console.ReadLine();

            //Plural License Access
            Console.WriteLine("\nDoes the Developer have a Pluralsight license (yes/no)?");
            string pluralsightAccess = Console.ReadLine().ToLower();

            if (pluralsightAccess == "yes")
            {
                newDeveloper.HasPluralAccess = true;
            }
            else
            {
                newDeveloper.HasPluralAccess = false;
            }

            _developerRepo.AddDevToList(newDeveloper);
        }
        //Create New Team
        private void CreateNewTeam()
        {
            Console.Clear();

            Console.WriteLine("List of all Teams:\n");
            List<DevTeam> listOfTeams = _devTeamRepo.GetTeamList();
            foreach (DevTeam teamInfo in listOfTeams)
            {
                Console.WriteLine($"Team ID: {teamInfo.TeamID}\n" +
                  $"Team Name: {teamInfo.DevTeamName}\n" +
                  $"Team Members(s): { string.Join(";", teamInfo.Developers.ToArray())}\n");
            }

            DevTeam newTeam = new DevTeam();

            //Team ID
            Console.WriteLine("Assign a unique 2-digit Team ID:");
            string teamID = Console.ReadLine();
            newTeam.TeamID = int.Parse(teamID);

            //Team Name
            Console.WriteLine("\nEnter the Team's unique name:");
            newTeam.DevTeamName = Console.ReadLine();

            _devTeamRepo.AddTeamToList(newTeam);
        }
        //Add Developers to Team
        private void AddDevelopersToTeam()
        {
            ViewAllDevs();

            List<int> listOfDevelopersID = new List<int>();

            bool keepAdding = true;
            while (keepAdding)
            {
                keepAdding = false;

                Console.WriteLine("Enter a valid Developer ID:");
                string inputAsString = Console.ReadLine();
                int devID = int.Parse(inputAsString);

                listOfDevelopersID.Add(devID);

                Console.WriteLine("\nWould you like to add another Developer to this Team (yes/no)?");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "yes")
                {
                    keepAdding = true;
                }
            }
            Console.Clear();

            Console.WriteLine("List of all Teams:\n");
            List<DevTeam> listOfTeams = _devTeamRepo.GetTeamList();
            foreach (DevTeam teamInfo in listOfTeams)
            {

                Console.WriteLine($"Team ID: {teamInfo.TeamID}\n" +
                  $"Team Name: {teamInfo.DevTeamName}");
                if (teamInfo.Developers == null)
                {
                    Console.WriteLine("Developers need to be added to this team.");
                }
                else
                {
                    Console.WriteLine($"Team Members(s): { string.Join(";", teamInfo.Developers.ToArray())}\n");
                }
            }

            Console.WriteLine("\nEnter a valid 2-digit Team ID:");
            string inputAsString2 = Console.ReadLine();
            int teamID = int.Parse(inputAsString2);

            _devTeamRepo.AddDeveloperToTeam(teamID, listOfDevelopersID);
        }
        //View All Developers
        private void ViewAllDevs()
        {
            Console.Clear();

            Console.WriteLine("List of all Developers:\n");
            List<DeveloperInformation> listOfDevs = _developerRepo.GetDeveloperList();
            foreach (DeveloperInformation developerInfo in listOfDevs)
            {
                Console.WriteLine($"Developer ID: {developerInfo.DevID}\n" +
                    $"Developer Name: {developerInfo.DevName}\n" +
                    $"Has Pluralsight License (yes or no)? {developerInfo.HasPluralAccess}\n");
            }
        }
        //View All Teams
        private void ViewAllTeams()
        {
            Console.Clear();

            Console.WriteLine("List of all Teams:\n");
            List<DevTeam> listOfTeams = _devTeamRepo.GetTeamList();
            foreach (DevTeam teamInfo in listOfTeams)
            {
                Console.WriteLine($"Team ID: {teamInfo.TeamID}\n" +
                  $"Team Name: {teamInfo.DevTeamName}");
                if (teamInfo.Developers == null)
                {
                    Console.WriteLine("Developers need to be added to this team.");
                }
                else
                {
                    Console.WriteLine($"Team Members(s): { string.Join(";", teamInfo.Developers.ToArray())}\n");
                }
            }

            Console.WriteLine("To see additional information about a Team, enter its unique 2-digit ID:");
            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);

            DevTeam teamID = _devTeamRepo.GetTeamByID(idAsInt);

            if (teamID != null)
            {
                string developers = "";
                foreach (var i in teamID.Developers)
                {
                    var devInfo = _developerRepo.GetDeveloperByID(i);
                    if (devInfo != null)
                    {
                        developers = developers + devInfo.DevID + ": " + devInfo.DevName + "\n";
                    }
                }

                Console.WriteLine($"\nTeam ID: {teamID.TeamID}\n" +
                   $"Team Name: {teamID.DevTeamName}\n" +
                   $"Team Members(s): {string.Join(";", teamID.Developers.ToArray())}\n" +
                    developers);
            }
            else
            {
                Console.WriteLine("\nNo Team identified by that ID number.");
            }
        }
        //View Developer by ID
        private void ViewDevByID()
        {
            Console.Clear();

            Console.WriteLine("Enter a Developer's unique 5-digit ID:");
            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);
            DeveloperInformation devID = _developerRepo.GetDeveloperByID(idAsInt);
            if (devID != null)
            {
                Console.WriteLine($"\nDeveloper ID: {devID.DevID}\n" +
                   $"Developer Name: {devID.DevName}\n" +
                   $"Has Pluralsight License (yes or no)? {devID.HasPluralAccess}\n");
            }
            else
            {
                Console.WriteLine("\nNo Developer identified by the ID number.");
            }
        }
        //View Team by ID
        private void ViewTeamByID()
        {
            Console.Clear();

            Console.WriteLine("Enter a Teams's unique 2-digit ID:");
            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);

            DevTeam teamID = _devTeamRepo.GetTeamByID(idAsInt);

            if (teamID != null)
            {
                string developers = "";
                foreach (var i in teamID.Developers)
                {
                    var devInfo = _developerRepo.GetDeveloperByID(i);
                    if (devInfo != null)
                    {
                        developers = developers + devInfo.DevID + ": " + devInfo.DevName + "\n";
                    }
                }

                Console.WriteLine($"\nTeam ID: {teamID.TeamID}\n" +
                   $"Team Name: {teamID.DevTeamName}\n" +
                   $"Team Members(s): {string.Join(";", teamID.Developers.ToArray())}\n" +
                    developers);
            }
            else
            {
                Console.WriteLine("\nNo Team identified by that ID number.");
            }
        }
        //View Developers Needing Pluralsight License
        private void ViewDevsWithNoPlural()
        {
            Console.Clear();
            Console.WriteLine("These Developers still need a Pluralsight license:");

            List<DeveloperInformation> listOfDevs = _developerRepo.GetDeveloperList();

            foreach (DeveloperInformation developerInfo in listOfDevs)
            {
                if (developerInfo.HasPluralAccess == false)
                {
                    Console.WriteLine($"Developer ID: {developerInfo.DevID}\n" +
                    $"Developer Name: {developerInfo.DevName}\n");
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }
        //Update Existing Developer
        private void UpdateDev()
        {
            ViewAllDevs();

            Console.WriteLine("Enter the ID of the Developer you'd like to update:");
            int oldDeveloperID = Convert.ToInt32(Console.ReadLine());

            DeveloperInformation newDeveloper = new DeveloperInformation();

            //Developer ID
            Console.WriteLine("\nAssign a unique 5-digit Developer ID:");
            string developerIDAsString = Console.ReadLine();
            int developerIDAsInt = int.Parse(developerIDAsString);
            newDeveloper.DevID = developerIDAsInt;

            //Developer Name
            Console.WriteLine("\nEnter the Developer's full name (First & Last):");
            newDeveloper.DevName = Console.ReadLine();

            //Plural License Access
            Console.WriteLine("\nDoes the Developer have a Pluralsight license (yes/no)?");
            string pluralsightAccess = Console.ReadLine().ToLower();

            if (pluralsightAccess == "yes")
            {
                newDeveloper.HasPluralAccess = true;
            }
            else
            {
                newDeveloper.HasPluralAccess = false;
            }

            _developerRepo.UpdateExistingDeveloper(oldDeveloperID, newDeveloper);
        }
        //Update Existing Team
        private void UpdateTeam()
        {
            ViewAllTeams();

            DevTeam newTeam = new DevTeam();

            Console.WriteLine("Enter the ID of the Team you'd like to update:");
            int oldTeamID = Convert.ToInt32(Console.ReadLine());
            DevTeam oldTeam = _devTeamRepo.GetTeamByID(oldTeamID);

            //Team ID
            Console.WriteLine("\nAssign a unique 2-digit Team ID:");
            string TeamID = Console.ReadLine();
            newTeam.TeamID = int.Parse(TeamID);
            oldTeam.TeamID = newTeam.TeamID;

            //Team Name
            Console.WriteLine("\nEnter the Team's unique name:");
            newTeam.DevTeamName = Console.ReadLine();
            oldTeam.DevTeamName = newTeam.DevTeamName;
        }
        //Delete Existing Developer
        private void DeleteDev()
        {
            ViewAllDevs();

            Console.WriteLine("Enter the ID of the Developer that you would like to remove:");
            string inputAsString = Console.ReadLine();
            int inputAsInt = int.Parse(inputAsString);

            bool wasDeleted = _developerRepo.RemoveDeveloperFromList(inputAsInt);
            if (wasDeleted)
            {
                Console.WriteLine("\nThe Developer was successfully removed.");
            }
            else
            {
                Console.WriteLine("\nThe Developer could not be removed.");
            }
        }
        //Delete Developers from Team
        private void DeleteDevelopersFromTeam()
        {
            ViewAllTeams();

            Console.WriteLine("Enter a valid 2-digit Team ID:");
            string inputAsString2 = Console.ReadLine();
            int idAsInt = int.Parse(inputAsString2);

            DevTeam teamID = _devTeamRepo.GetTeamByID(idAsInt);
            if (teamID != null)
            {
                Console.WriteLine($"\nTeam ID: {teamID.TeamID}\n" +
                   $"Team Name: {teamID.DevTeamName}\n" +
                   $"Team Members(s): {string.Join(";", teamID.Developers.ToArray())}\n");

                List<int> listOfDevelopersID = new List<int>();

                bool keepAdding = true;
                while (keepAdding)
                {
                    keepAdding = false;

                    Console.WriteLine("Enter the 5-digit ID of the Developer that you would like to remove:");
                    string inputAsString = Console.ReadLine();
                    int devID = int.Parse(inputAsString);

                    listOfDevelopersID.Add(devID);

                    Console.WriteLine("\nWould you like to remove another Developer from this Team (yes/no)?");
                    string userInput = Console.ReadLine().ToLower();

                    if (userInput == "yes")
                    {
                        keepAdding = true;
                    }
                }

                _devTeamRepo.RemoveDevelopersFromTeam(idAsInt, listOfDevelopersID);
            }
            else
            {
                Console.WriteLine("\nNo Team identified by that ID number.");
            }

        }
        //Delete Existing Team
        private void DeleteTeam()
        {
            ViewAllTeams();

            Console.WriteLine("Enter the ID of the Team that you would like to remove:");
            string inputAsString = Console.ReadLine();
            int inputAsInt = int.Parse(inputAsString);

            bool wasDeleted = _devTeamRepo.RemoveTeamFromList(inputAsInt);
            if (wasDeleted)
            {
                Console.WriteLine("\nThe Team was successfully removed.");
            }
            else
            {
                Console.WriteLine("\nThe Team could not be removed.");
            }
        }
        //Seed Method(s)
        private void SeedDevList()
        {
            DeveloperInformation developer1 = new DeveloperInformation(12345, "Jon Snow", true);
            DeveloperInformation developer2 = new DeveloperInformation(12346, "Daenerys Targaryen", true);
            DeveloperInformation developer3 = new DeveloperInformation(12347, "Cersei Lannister", false);
            DeveloperInformation developer4 = new DeveloperInformation(12348, "Robert Baratheon", false);
            DeveloperInformation developer5 = new DeveloperInformation(12349, "Margaery Tyrell", true);

            _developerRepo.AddDevToList(developer1);
            _developerRepo.AddDevToList(developer2);
            _developerRepo.AddDevToList(developer3);
            _developerRepo.AddDevToList(developer4);
            _developerRepo.AddDevToList(developer5);
        }

        private void SeedTeamList()
        {
            DevTeam team1 = new DevTeam(10, "House Stark", new List<int> { 12345 });
            DevTeam team2 = new DevTeam(11, "House Targaryen", new List<int> { 12346 });
            DevTeam team3 = new DevTeam(12, "House Lannister", new List<int> { 12347 });

            _devTeamRepo.AddTeamToList(team1);
            _devTeamRepo.AddTeamToList(team2);
            _devTeamRepo.AddTeamToList(team3);
        }
    }
}
