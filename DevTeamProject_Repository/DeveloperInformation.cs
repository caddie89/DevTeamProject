using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperInformation
    {
        public int DevID { get; set; }
        public string DevName { get; set; }
        public bool HasPluralAccess { get; set; }

        public DeveloperInformation() { }

        public DeveloperInformation(int devID, string devName, bool hasPluralAccess)
        {
            DevID = devID;
            DevName = devName;
            HasPluralAccess = hasPluralAccess;
        }
    }
}

//Info from Instructors:
//You will need to give the POCOs properties and and Repos need CRUD methods as appropriate. You will then create a User Interface (Console Application) to build the functionality Komodo Insurance requires utilizing these classes. We have provided you with a few fields in the appropriate classes to help you in writing the CRUD Methods for the Developer and DevTeam POCOs.

//You need to adhere to the guidelines from Komodo Insurance while writing their application to meet their needs in managing the DevTeams and Developers. Clients will typically not give you all the info you need, so you may need to use your brain and peers to fill in the blanks!

//Info from Komodo Insurance:
//Developers have names and ID numbers;
//we need to be able to identify one developer without mistaking them for another. We also need to know whether or not they have access to the online learning tool: Pluralsight.

//Challenge: Our HR Department uses the software monthly to get a list of all our Developers that need a Pluralsight license. Create this functionality in the Console Application

//Our managers need to be able to add and remove members to/from a team by their unique identifier. They should be able to see a list of existing developers to choose from and add to existing teams. Odds are, the manager will create a team, and then add Developers individually from the Developer Directory to that team.

//Challenge: Some of our managers are nitpicky and would like the functionality to add multiple Developers to a team at once, rather than one by one. Integrate this into your application.

