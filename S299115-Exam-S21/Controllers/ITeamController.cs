using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S299115_Exam_S21.Models;

namespace S299115_Exam_S21.Controllers
{
    public interface ITeamController
    {
        Task<ActionResult<Team>> AddTeam([FromBody]Team team);
        Task<ActionResult<IList<Team>>> GetTeams([FromQuery] int rank,[FromQuery] string TeamName);

    }
}