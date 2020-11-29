using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();
        //private readonly List<DeveloperInformation> _devDirectory = new List<DeveloperInformation>();

        //Create Team
        public void AddTeamToList(DevTeam team)
        {
            _devTeams.Add(team);
        }

        //Create Team Member
        public void AddDeveloperToTeam(int teamId, List<int> developer)
        {
            //Search for the team
            var teams = GetTeamByID(teamId);
            if (teams != null)
            {
                //add to dev list
                teams.Developers.AddRange(developer);
            }
        }

       //DevTeam Read
       public List<DevTeam> GetTeamList()
            {
                return _devTeams;
            }

        //DevTeam Update
        public bool UpdateExistingTeam(int originalTeam, DevTeam newTeam)
        {
            //Find the content
            DevTeam existingTeam = GetTeamByID(originalTeam);

            if (existingTeam != null)
            {
                existingTeam.TeamID = newTeam.TeamID;
                existingTeam.DevTeamName = newTeam.DevTeamName;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Remove Developer from Team
        public void RemoveDevelopersFromTeam(int teamId, List<int> developer)
        {
            //Search for the team
            var teams = GetTeamByID(teamId);
            if (teams != null)
            {
                foreach (var i in developer)
                {
                    teams.Developers.RemoveAll(item => item == i);                          //This lambda searches for the item with value "i"
                }
            }
        }

        //DevTeam Delete
        public bool RemoveTeamFromList(int id)
        {
            DevTeam team = GetTeamByID(id);

            if (team == null)
            {
                return false;
            }

            int initialCount = _devTeams.Count;
            _devTeams.Remove(team);

            if (initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetTeamByID(int id)
        {
            foreach (DevTeam team in _devTeams)
            {
                if (team.TeamID == id)
                {
                    return team;
                }
            }

            return null;
        }
    }
}
