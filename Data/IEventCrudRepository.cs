using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Helpers;
using backend.Models;

namespace backend.Data
{
    public interface IEventCrudRepository
    {
         void Add<T>(T entity) where T:class;
         void Delete<T>(T entity) where T:class;
         Task<bool> SaveAll();
        Task<PagedList<Event>> GetEvents(EventParams eventParams);
        Task<Event> GetEvent(int Id);
        Task<Event> AddEvent(Event Event);
    }
}