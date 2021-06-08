using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S299115_Exam_S21.DataAccess;
using S299115_Exam_S21.Models;

namespace S299115_Exam_S21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase, ITeamController
    {
        private ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }
        
        [HttpPost]
        public async Task<ActionResult<Team>> AddTeam([FromBody]Team team)
        {
            try
            {
               await teamService.AddTeam(team);
                return Ok(team);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<Team>>> GetTeams([FromQuery]int rank, [FromQuery]string TeamName)
        {
            try
            {
                IList<Team> valid = await teamService.GetTeams(rank,TeamName);
                return Ok(valid);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
            
            
        }
    }
}