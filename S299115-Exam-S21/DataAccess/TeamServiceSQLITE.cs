using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using S299115_Exam_S21.Models;

namespace S299115_Exam_S21.DataAccess
{
    public class TeamServiceSQLITE : ITeamService
    {
        private FootballDbContext FootballDBContext;

        public TeamServiceSQLITE(FootballDbContext footballDbContext)
        {
            FootballDBContext = footballDbContext;
        }
        public async Task<Team> AddTeam(Team team)
        {
            await FootballDBContext.Teams.AddAsync(team);
            await FootballDBContext.SaveChangesAsync();
            return team;
        }

        public async Task<IList<Team>> GetTeams(int rank, string TeamName)
        {if (rank == 0 && TeamName==null)
            {
                return await FootballDBContext.Teams.ToListAsync();
            }

            if (rank == 0)
            {
                return FootballDBContext.Teams.Where(t=>t.TeamName.Contains(TeamName)).ToList();
            }

            if (TeamName==null)
            {
                return FootballDBContext.Teams.Where(t => t.Ranking >= rank).ToList();
            }
            IList<Team> returned = FootballDBContext.Teams.Where(t => t.Ranking >= rank).Where(t=>t.TeamName.Contains(TeamName)).ToList();
            Console.WriteLine("min"+rank);
            Console.WriteLine("name"+TeamName);
            return returned;
        }

    }
}