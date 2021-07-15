using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repos
{
    public class DevTeam
    {
        // Set properties of POCO
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public List<Developer> _teamMembers = new List<Developer>();

        // Build constructors
        public DevTeam() { }
        public DevTeam(string name, int id)
        {
            TeamName = name;
            TeamID = id;
        }
    }
}
