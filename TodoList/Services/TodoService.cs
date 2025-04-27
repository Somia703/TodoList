using System.Net.WebSockets;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Services
{
    public class TodoService : ITodoService
    {

        private readonly TodoContext _context;
        public TodoService(TodoContext context)
        {
            _context = context;
        }
        public Todoitems Create(Todoitems item)
        {
            _context.Todoitems.Add(item);
            _context.SaveChanges();
            return item;

        }

        public bool Delete(int id)
        {
           var item=_context.Todoitems.Find(id);
            if (item != null) return false;

            _context.Todoitems.Remove(item);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Todoitems> GetAll()
        {
            return _context.Todoitems.ToList();
        }
            
        public Todoitems? GetById(int id)
        {
            return _context.Todoitems.Find(id);

        }

        public bool update(int id, Todoitems item)
        {
            var existing=_context.Todoitems.Find(id);
            if (existing != null) return false;
            existing.Title = item.Title;
            existing.IsComplete = item.IsComplete;
            _context.SaveChanges();
            return true;
        }

        
    }
}
