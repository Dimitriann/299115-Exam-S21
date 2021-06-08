using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S299115_Exam_S21.DataAccess;
using S299115_Exam_S21.Models;

namespace S299115_Exam_S21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase, IPlayerController
    {
        private IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }
        
        [HttpPost]
        public async Task<ActionResult<Player>> AddPlayer([FromBody]Player player, string TeamName)
        {
            try
            {
                Player valid = await playerService.AddPlayer(player,TeamName);
                return Ok(valid);
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Player>> DeletePLayer(int PlayerId)
        {
            try
            {
                Player valid = await playerService.DeletePLayer(PlayerId);
                return Ok(valid);
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }        }
    }
}