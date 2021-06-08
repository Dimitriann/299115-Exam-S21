using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using S299115_Exam_S21.Models;

namespace S299115_Exam_S21.DataAccess
{
    public class PlayerServiceSQLITE : IPlayerService
    {
        private FootballDbContext FootballDBContext;

        public PlayerServiceSQLITE(FootballDbContext footballDbContext)
        {
            FootballDBContext = footballDbContext;
        }
        public async Task<Player> AddPlayer(Player player, string TeamName)
        {
            player.TeamName = TeamName;
            await FootballDBContext.Players.AddAsync(player);
            await FootballDBContext.SaveChangesAsync();
            return player;
        }

        public async Task<Player> DeletePLayer(int PlayerID)
        {
            Player toRemove = await FootballDBContext.Players.FirstAsync(a => a.PlayerId==PlayerID);
            Console.WriteLine(JsonSerializer.Serialize(toRemove));
            FootballDBContext.Remove(toRemove);
            await FootballDBContext.SaveChangesAsync();
            return toRemove;
        }
    }
}