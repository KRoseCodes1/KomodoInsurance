using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repos
{
    public class DeveloperRepo
    {
        public List<Developer> _listOfDevelopers = new List<Developer>();

        // CRUD methods
        // Create:
        public void AddNewDeveloper(Developer dev)
        {
            _listOfDevelopers.Add(dev);
        }
        // Read:
        public List<Developer> GetDeveloperList()
        {
            return _listOfDevelopers;
        }
        // Update:
        public bool UpdateExistingDeveloper(int id, Developer newDev)
        {
            Developer oldDev = GetDevByID(id);
            if (oldDev != null) {
                oldDev.FirstName = newDev.FirstName;
                oldDev.LastName = newDev.LastName;
                oldDev.HasPSAccess = newDev.HasPSAccess;

                return true;
            }
            else
            {
                return false;
            }
        }
        // Delete:
        public bool RemoveDeveloper(int id)
        {
            Developer dev = GetDevByID(id);
            if (dev == null)
            {
                return false;
            }

            int initialCount = _listOfDevelopers.Count;

            _listOfDevelopers.Remove(dev);

            if (initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Helper Methods:
        public Developer GetDevByID(int id)
        {
            foreach (Developer dev in _listOfDevelopers)
            {
                if(dev.ID == id)
                {
                    return dev;
                }
            }
            return null;
        }
    }
}
