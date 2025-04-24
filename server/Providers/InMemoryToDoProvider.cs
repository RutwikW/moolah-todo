using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Interfaces;
using server.Models;

namespace server.Providers
{
    public class InMemoryToDoProvider : IToDoProvider
    {
        private readonly List<ToDo> _todos = new();
        private int _nextId = 1;

        public Task<List<ToDo>> GetAllAsync()
        {
           
            return Task.FromResult(_todos.ToList());
        }

        public Task<ToDo?> GetByIdAsync(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(todo);
        }

        public Task<ToDo> CreateAsync(ToDo todo)
        {
            todo.Id = _nextId++;
            _todos.Add(todo);
            return Task.FromResult(todo);
        }

        public Task<ToDo?> UpdateAsync(int id, ToDo todo)
        {
            var existing = _todos.FirstOrDefault(t => t.Id == id);
            if (existing == null) return Task.FromResult<ToDo?>(null);

            existing.Title = todo.Title;
            existing.IsCompleted = todo.IsCompleted;
            return Task.FromResult(existing);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var existing = _todos.FirstOrDefault(t => t.Id == id);
            if (existing == null) return Task.FromResult(false);

            _todos.Remove(existing);
            return Task.FromResult(true);
        }
    }
}