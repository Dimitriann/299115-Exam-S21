using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using S299115_Exam_S21.DataAccess;

namespace S299115_Exam_S21.Models
{
    public class Team
    {
       
        [Key]
        public string TeamName { get; set; }
        [Required,MaxLength(50)]
        public string NameOfCoach { get; set; }
        public int Ranking { get; set; }
        public List<Player> Players { get; set; }

        public Team()
        {
            Players = new List<Player>();
        }
    }
}