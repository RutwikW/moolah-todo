using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Interfaces;
using server.Models;

namespace server.Providers
{
    public class DbToDoProvider : IToDoProvider
    {
        private readonly ToDoContext _context;

        public DbToDoProvider(ToDoContext context)
        {
            _context = context;
        }

        public async Task<List<ToDo>> GetAllAsync()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<ToDo?> GetByIdAsync(int id)
        {
            return await _context.ToDos.FindAsync(id);
        }

        public async Task<ToDo> CreateAsync(ToDo todo)
        {
            _context.ToDos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<ToDo?> UpdateAsync(int id, ToDo todo)
        {
            var existing = await _context.ToDos.FindAsync(id);
            if (existing == null) return null;

            existing.Title = todo.Title;
            existing.IsCompleted = todo.IsCompleted;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.ToDos.FindAsync(id);
            if (existing == null) return false;

            _context.ToDos.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}