using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public interface IPlayerService
    { 
        Task<Player> AddPlayer(Player player);
         Task<Player> DeletePlayer(int PLayerId);
    }
}