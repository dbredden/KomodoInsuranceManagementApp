using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceClassLibrary
{
    public class DevTeamRepository
    {

        protected readonly List<DevTeam> _devTeamDirectory = new List<DevTeam>();
        // CREATE
        public bool CreateDevTeam(DevTeam newDevTeam)
        {

            int startingCount = _devTeamDirectory.Count;
            _devTeamDirectory.Add(newDevTeam);
            bool wasAdded = _devTeamDirectory.Count > startingCount ? true : false;
            return wasAdded;
        }
        // READ 
        public List<DevTeam> GetAllDevTeams()
        {
            return _devTeamDirectory;
        }

        public DevTeam GetDevTeamById(int teamId)
        {
            foreach(DevTeam devTeam in _devTeamDirectory)
            {
                if (teamId == devTeam.TeamID)
                    return devTeam;
            }
            return null;
        }
        // UPDATE
        public bool UpdateDevTeam(int teamId, DevTeam newDevTeam)
        {
            DevTeam oldDevTeam = GetDevTeamById(teamId); 
            if (oldDevTeam != null)
            {
                oldDevTeam.Developers = newDevTeam.Developers;
                oldDevTeam.TeamName = newDevTeam.TeamName;
                oldDevTeam.TeamID = oldDevTeam.TeamID;
                return true;
            }
            else
            {
                return false;
            }
        }
        // DELETE
        public bool DeleteDevTeam(DevTeam existingDevTeamId)
        {
            bool deleteResult = _devTeamDirectory.Remove(existingDevTeamId);
            return deleteResult;
        }
    }
}
