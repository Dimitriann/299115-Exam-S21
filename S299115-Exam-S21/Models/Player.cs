using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace S299115_Exam_S21.Models
{
    public class Player
    {
        public string TeamName{ get; set; }
        [Key]
        public int PlayerId { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Range(1,99)]
        public int ShirtNumber { get; set; }
        public decimal Salary { get; set; }
        public int GoalsThisSeason { get; set; }
        [Required]
        public string Position { get; set; }
        
    }
}