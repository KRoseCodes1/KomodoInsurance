using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repos
{
    public class DevTeamRepo
    {
        DeveloperRepo repo = new DeveloperRepo();
        public List<DevTeam> _listOfTeams = new List<DevTeam>();

        // CRUD methods
        // Create:
        public void AddNewTeam(DevTeam newTeam)
        {
            _listOfTeams.Add(newTeam);
        }
        // Read:
        public List<DevTeam> GetTeamList()
        {
            return _listOfTeams;
        }
        public List<Developer> ViewTeam(int id)
        {
            DevTeam team = GetTeamByID(id);
            List<Developer> teamList = team._teamMembers;
            return teamList;
        }
        // Update:
        public bool UpdateExistingTeam(DevTeam newTeam, int id)
        {
            DevTeam oldTeam = GetTeamByID(id);

            if(oldTeam != null)
            {
                oldTeam.TeamID = newTeam.TeamID;
                oldTeam.TeamName = newTeam.TeamName;
                return true;
            }
            else
            {
                return false;
            }
        }
        // Delete:
        public bool RemoveTeam(int id)
        {
            DevTeam team = GetTeamByID(id);
            if(team == null)
            {
                return false;
            }

            int initialCount = _listOfTeams.Count;

            _listOfTeams.Remove(team);

            if (initialCount > _listOfTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDevFromTeam(int teamID, int devID)
        {
            DevTeam team = GetTeamByID(teamID);
            Developer dev = repo.GetDevByID(devID);
            if (team == null | dev == null)
            {
                return false;
            }

            int initialCount = team._teamMembers.Count;

            team._teamMembers.Remove(dev);

            if (initialCount > team._teamMembers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Any Helper methods:
        public DevTeam GetTeamByID(int id)
        {
            foreach (DevTeam team in _listOfTeams)
            {
                if (team.TeamID == id)
                {
                    return team;
                }
            }
            return null;
        }
    }
}
