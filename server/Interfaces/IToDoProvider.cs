using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface IToDoProvider
    {
        Task<List<ToDo>> GetAllAsync();
        Task<ToDo?> GetByIdAsync(int id);
        Task<ToDo> CreateAsync(ToDo todo);
        Task<ToDo?> UpdateAsync(int id, ToDo todo);
        Task<bool> DeleteAsync(int id);
    }
}