using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Team
    {
        [Key]
        public string TeamName {get; set; }
        [Required,MaxLength(50)]
        public string NameOfCoach {get; set; }
        public int Ranking {get; set; }
        public IList<Player> Players { get; set; }
    }
}