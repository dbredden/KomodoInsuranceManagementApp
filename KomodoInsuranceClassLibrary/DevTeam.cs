using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceClassLibrary
{
    public class DevTeam
    {
        public List<Developer> Developers { get; set; }
        public string TeamName { get; set; }
        public int TeamID { get; set; }
    
        public DevTeam()
        {

        }

        public DevTeam (List<Developer> developers, string teamName, int teamId)
        {
            Developers = developers;
            TeamName = teamName;
            TeamID = teamId;
        }
    }
}
