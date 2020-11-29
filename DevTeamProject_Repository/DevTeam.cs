using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{ 
    public class DevTeam
    {
        public int TeamID { get; set; }
        public string DevTeamName { get; set; }
        public List<DeveloperInformation> Developers { get; set; } = new List<DeveloperInformation>();

        public DevTeam() { }

        public DevTeam(int teamID, string devTeamName, List<DeveloperInformation> devTeamMember)    
        {
            TeamID = teamID;
            DevTeamName = devTeamName;
            Developers = devTeamMember;
        }
    }
}
