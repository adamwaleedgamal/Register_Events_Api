using login.DTOs;
using login.Models;
using Microsoft.EntityFrameworkCore;

namespace login.Repo.Events_Repo
{
    public class Eventss : IEvents
    {
        private readonly Appdbcontext _context;
        public Eventss(Appdbcontext context)
        {
            _context = context;
        }
        public void AddEvent(EventsAdd events)
        {
           var e=new Event()
           {
               Date=events.Date,
               ImageUrl=events.ImageUrl,
               Location=events.Location,
               Name=events.Name
           };
            _context.Events.Add(e);
            _context.SaveChanges();

        }

        public EventsMessage DeleteEvent(int id)
        {
            var serach = _context.Events.FirstOrDefault(z => z.Id == id);
            if (serach != null)
            {
                _context.Events.Remove(serach);
                _context.SaveChanges();
                return new EventsMessage
                {
                    Status = true,
                    Message = "Deleted Successfuly",
                    Owner = "Cycleny"
                };
               
            }
            else
            {
                return new EventsMessage
                {
                    Status = false,
                    Message = "Event Not Found",
                    Owner = "Cycleny"
                };
            }
        }

        public List<Event> GetEvent()
        {
            return _context.Events.ToList();
        }

        public EventsMessage UpdateEvent(EventsAdd eventsDTO, int id)
        {
            var serach = _context.Events.FirstOrDefault(z => z.Id == id);
            if (serach == null)
            {
                return new EventsMessage
                {
                    Status = false,
                    Message = "Event Not Found",
                    Owner = "Cycleny"
                };
            }
            else
            {
                serach.Date = eventsDTO.Date;
                serach.ImageUrl = eventsDTO.ImageUrl;
                serach.Location = eventsDTO.Location;
                serach.Name = eventsDTO.Name;
                _context.Events.Update(serach);
                _context.SaveChanges();
                return new EventsMessage
                {
                    Status = true,
                    Message = "Updated Successfuly",
                    Owner = "Cycleny"
                };
            }
        }
    }
}
