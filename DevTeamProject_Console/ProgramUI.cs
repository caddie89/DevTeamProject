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
                Console.WriteLine("Please select an option from the menu below (i.e. 1, 2, 3, etc.):\n\n" +
                    "1.  Create New Developer\n" +                                                          //Done
                    "2.  Create New Team\n" +                                                               //Started (runs)
                    "3.  View All Developers\n" +                                                           //Done
                    "4.  View All Teams\n" +                                                                //Done
                    "5.  View Developer by ID\n" +                                                          //Done
                    "6.  View Team by ID\n" +                                                               //Done
                    "7.  View Developers Needing a Pluralsight License\n" +                                 //Done (could use improvement)
                    "8.  Update Existing Developer\n" +                                                     //Done
                    "9.  Update Existing Team\n" +                                                          //Started (runs) - ADD MULTIPLE DEVS AT ONCE
                    "10. Delete Existing Developer\n" +                                                     //Done
                    "11. Delete Existing Team\n" +                                                          //Done
                    "12. Exit");

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
                        ViewAllDevs();
                        break;
                    case "4":
                        ViewAllTeams();
                        break;
                    case "5":
                        ViewDevByID();
                        break;
                    case "6":
                        ViewTeamByID();
                        break;
                    case "7":
                        ViewDevsWithNoPlural();
                        break;
                    case "8":
                        UpdateDev();
                        break;
                    case "9":
                        UpdateTeam();
                        break;
                    case "10":
                        DeleteDev();
                        break;
                    case "11":
                        DeleteTeam();
                        break;
                    case "12":
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
            ViewAllTeams();

            DevTeam newTeam = new DevTeam();

            //Team ID
            Console.WriteLine("Assign a unique 2-digit Team ID (4 would be 04):");
            string teamID = Console.ReadLine();
            newTeam.TeamID = int.Parse(teamID);

            //Team Name
            Console.WriteLine("\nEnter the Team's unique name:");
            newTeam.DevTeamName = Console.ReadLine();

            Console.Clear();

            //Team Members
            Console.WriteLine($"Below is a list of Developers that can be assigned to {newTeam.DevTeamName}:\n");

            List<DeveloperInformation> listOfDevs = _developerRepo.GetDeveloperList();

            foreach (DeveloperInformation developerInfo in listOfDevs)
            {
                Console.WriteLine($"Developer ID: {developerInfo.DevID}\n" +
                    $"Developer Name: {developerInfo.DevName}\n");
            }

            Console.WriteLine($"\nEnter the ID of the Developer you would like to add to {newTeam.DevTeamName} (otherwise enter '0').");
            string teamMemberID = Console.ReadLine();
            newTeam.DevTeamMemberID = int.Parse(teamMemberID);

            _devTeamRepo.AddTeamToList(newTeam);
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
                    $"Team Name: {teamInfo.DevTeamName}\n" +
                    $"Team Member(s): {teamInfo.DevTeamMemberID}\n");
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
                Console.WriteLine("No Developer identified by the ID number.");
            }
        }
        //View Team by ID
        private void ViewTeamByID()
        {
            Console.Clear();

            Console.WriteLine("Enter a Teams's unique 2-digit ID (for 2, enter 02):");
            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);
            DevTeam teamID = _devTeamRepo.GetTeamByID(idAsInt);
            if (teamID != null)
            {
                Console.WriteLine($"\nTeam ID: {teamID.TeamID}\n" +
                   $"Team Name: {teamID.DevTeamName}\n" +
                   $"Team Members(s): {teamID.DevTeamMemberID}\n");
            }
            else
            {
                Console.WriteLine("No Team identified by that ID number.");
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

            Console.WriteLine("Enter the ID of the Developer you'd like to update.");
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

            Console.WriteLine("Enter the ID of the Team you'd like to update (4 would be 04).");
            int oldTeamID = Convert.ToInt32(Console.ReadLine());

            //Team ID
            Console.WriteLine("\nAssign a unique 2-digit Team ID (4 would be 04):");
            string TeamID = Console.ReadLine();
            newTeam.TeamID = int.Parse(TeamID);

            //Team Name
            Console.WriteLine("\nEnter the Team's unique name:");
            newTeam.DevTeamName = Console.ReadLine();

            Console.Clear();

            //Team Members
            Console.WriteLine($"Below is a list of Developers that can be assigned to {newTeam.DevTeamName}:\n");
            List<DeveloperInformation> listOfDevs = _developerRepo.GetDeveloperList();
            foreach (DeveloperInformation developerInfo in listOfDevs)
            {
                Console.WriteLine($"Developer ID: {developerInfo.DevID}\n" +
                    $"Developer Name: {developerInfo.DevName}\n");
            }

            Console.WriteLine($"Enter the ID of the Developer you would like to add to {newTeam.DevTeamName} (otherwise enter '0').");
            string devIDAsString = Console.ReadLine();
            int devIDAsInt = int.Parse(devIDAsString);
            newTeam.DevTeamMemberID = devIDAsInt;

            _devTeamRepo.UpdateExistingTeam(oldTeamID, newTeam);
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
                Console.WriteLine("The Developer was successfully removed.");
            }
            else
            {
                Console.WriteLine("The Developer could not be removed.");
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
                Console.WriteLine("The Team was successfully removed.");
            }
            else
            {
                Console.WriteLine("The Team could not be removed.");
            }
        }
        //Seed Method(s)
        private void SeedDevList()
        {
            DeveloperInformation developer1 = new DeveloperInformation(12345, "Jon Snow", true);
            DeveloperInformation developer2 = new DeveloperInformation(12346, "Daenerys Targaryen", true);
            DeveloperInformation developer3 = new DeveloperInformation(12347, "Cersei Lannister", false);

            _developerRepo.AddDevToList(developer1);
            _developerRepo.AddDevToList(developer2);
            _developerRepo.AddDevToList(developer3);
        }

        private void SeedTeamList()
        {
            DevTeam team1 = new DevTeam(01, "House Stark", 12345);
            DevTeam team2 = new DevTeam(02, "House Targaryen", 12346);
            DevTeam team3 = new DevTeam(03, "House Lannister", 12347);

            _devTeamRepo.AddTeamToList(team1);
            _devTeamRepo.AddTeamToList(team2);
            _devTeamRepo.AddTeamToList(team3);
        }
    }
}
