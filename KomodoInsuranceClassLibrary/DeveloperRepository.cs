using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceClassLibrary
{
    public class DeveloperRepository
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        // CREATE        
        public bool AddDeveloperToDirectory(Developer newDev)
        {
            // could also use a .contains method to see if the variable is in the list
            int startingCount = _developerDirectory.Count;
            _developerDirectory.Add(newDev);
            // did my starting count change? now i give it a bool
            bool wasAdded = _developerDirectory.Count > startingCount ? true : false;
            return wasAdded;
        }
        // READ 
        public List<Developer> GetAllDevelopers()
        {
            return _developerDirectory;
        }
        public Developer GetDeveloperById(int devId)
        {
            foreach(Developer dev in _developerDirectory)
            {
                if (devId == dev.DevID) 
                return dev;
            }
            return null;
        }

        // This method returns devs with no pluralsight access
        public List<Developer> GetDevelopersByAccess()
        {
            List<Developer> devsNoAccess = new List<Developer>();
            foreach(Developer dev in _developerDirectory)
            {
                if(dev.PluralsightAccess == false)
                {
                    devsNoAccess.Add(dev);
                }
            }
            return devsNoAccess;
        }

        // UPDATE
        public bool UpdateDeveloper(int devId, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperById(devId);

            if (oldDeveloper != null)
            {
                oldDeveloper.FirstName = newDeveloper.FirstName;
                oldDeveloper.LastName = newDeveloper.LastName;
                oldDeveloper.PluralsightAccess = newDeveloper.PluralsightAccess;
                return true;
            }
            return false;
        }

        // DELETE
        public bool DeleteExistingDeveloper(Developer existingDevId)
        {
            bool deleteResult = _developerDirectory.Remove(existingDevId);
            return deleteResult;
        }
    }
}
