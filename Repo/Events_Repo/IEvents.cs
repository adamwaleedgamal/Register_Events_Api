using login.DTOs;
using login.Models;

namespace login.Repo.Events_Repo
{
    public interface IEvents
    {
        public void AddEvent(EventsAdd events); 
        public List<Event> GetEvent();
        public EventsMessage UpdateEvent(EventsAdd eventsDTO, int id);
        public EventsMessage DeleteEvent(int id);
    }
}
