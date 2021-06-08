using System.Collections.Generic;
using System.Threading.Tasks;
using S299115_Exam_S21.Models;

namespace S299115_Exam_S21.DataAccess
{
    public interface ITeamService
    {
        Task<Team> AddTeam(Team team);
        Task<IList<Team>> GetTeams(int rank, string TeamName);
    }
}