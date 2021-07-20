using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repos
{
    public class Developer
    {
        // Set properies of POCO
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public bool HasPSAccess { get; set; }

        // Build constructors
        public Developer() { }
        public Developer(string first, string last, int id, bool access)
        {
            FirstName = first;
            LastName = last;
            ID = id;
            HasPSAccess = access;
        }
    }
}