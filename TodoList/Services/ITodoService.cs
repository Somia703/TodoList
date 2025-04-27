using TodoList.Models;

namespace TodoList.Services
{
    public interface ITodoService
    {
        IEnumerable<Todoitems> GetAll();
        Todoitems? GetById(int id);
        Todoitems Create (Todoitems item);
        bool Delete(int id);
        bool update(int id, Todoitems item);
    }
}
