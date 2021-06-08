using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S299115_Exam_S21.Models;

namespace S299115_Exam_S21.Controllers
{
    public interface IPlayerController
    {
        Task<ActionResult<Player>> AddPlayer([FromBody]Player player, string TeamName);
        Task<ActionResult<Player>> DeletePLayer([FromBody]int PlayerId);
    }
}