using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceClassLibrary
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DevID { get; set; }
        public bool PluralsightAccess { get; set; } = false;

        public Developer()
        {

        }

        public Developer (string firstName, string lastName, int devId, bool pluralsightAccess)
        {
            FirstName = firstName;
            LastName = lastName;
            DevID = devId;
            PluralsightAccess = pluralsightAccess;
        }
    }
}
