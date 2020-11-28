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
        public int DevTeamMemberID { get; set; }

        public DevTeam() { }

        public DevTeam(int teamID, string devTeamName, int devTeamMemberID)    
        {
            TeamID = teamID;
            DevTeamName = devTeamName;
            DevTeamMemberID = devTeamMemberID;
        }
    }
}
