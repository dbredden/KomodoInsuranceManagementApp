using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceClassLibrary
{
    public class DeveloperRepository
    {
        //This is where our developer CRUD methods will live
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        // CREATE - take in a new developer object and adds it to my list
        
        public bool AddDeveloperToDirectory(Developer newDev)
        {
            // could also use a .contains method to see if the variable is in the list
            int startingCount = _developerDirectory.Count;
            _developerDirectory.Add(newDev);
            // did my starting count change? now i give it a bool
            bool wasAdded = _developerDirectory.Count > startingCount ? true : false;
            return wasAdded;
        }

        // READ - give me every item in my collection

        public List<Developer> GetAllDevelopers()
        {
            return _developerDirectory;
        }

        // get developer by develper ID

        public Developer GetDeveloperById(int devId)
        {
            foreach(Developer dev in _developerDirectory)
            {
                if (devId == dev.DevID) 
                return dev;
            }
            return null;
        }

        // find developers by PluralSight access
        // THIS METHOD WILL GET DEVS WITH NO PLURALSIGHT ACCESS
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
        // need to update a developer to have new values to its properties
        // find the existing developer by the dev ID in the list and update its properties
        
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
        // Take in an existing developer object and delete from my list

        public bool DeleteExistingDeveloper(Developer existingDevId)
        {
            bool deleteResult = _developerDirectory.Remove(existingDevId);
            return deleteResult;
        }
    }
}
