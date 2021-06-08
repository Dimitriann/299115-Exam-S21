using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public interface ITeamService
    {
        Task<IList<Team>> GetAllTeams(int rank,string TeamName);
        Task<Team> AddTeam(Team team);
        
    }
}