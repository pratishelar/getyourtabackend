using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Helpers;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class EventCrudRepository : IEventCrudRepository
    {
        private readonly UserContext _context;

        public EventCrudRepository(UserContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<Event> AddEvent(Event Event)
        {
            await _context.Events.AddAsync(Event);
            await _context.SaveChangesAsync();

            return Event;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Event> GetEvent(int Id)
        {
            var Event = await _context.Events.FirstOrDefaultAsync(e => e.Id == Id);
            return Event;
        }

        public async Task<PagedList<Event>> GetEvents(EventParams eventParams)
        {
            var events = _context.Events;
            return await PagedList<Event>.CreateAsync(events, eventParams.PageNumber, eventParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}