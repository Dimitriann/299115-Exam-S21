using System.Threading.Tasks;
using S299115_Exam_S21.Models;

namespace S299115_Exam_S21.DataAccess
{
    public interface IPlayerService
    {
        Task<Player> AddPlayer(Player player, string TeamName);
        Task<Player> DeletePLayer(int PlayerId);
        
    }
}