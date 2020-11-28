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

        //DevTeam Create

        //Create Dev Team
        public void AddTeamToList(DevTeam team)
        {
            _devTeams.Add(team);
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
                existingTeam.DevTeamMemberID = newTeam.DevTeamMemberID;

                return true;
            }
            else
            {
                return false;
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
