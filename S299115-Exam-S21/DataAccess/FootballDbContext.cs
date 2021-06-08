using Microsoft.EntityFrameworkCore;
using S299115_Exam_S21.Models;

namespace S299115_Exam_S21.DataAccess
{
    public class FootballDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Football.db");
        }
    }
}