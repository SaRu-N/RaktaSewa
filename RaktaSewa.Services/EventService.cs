using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaktaSewa.Models;
using RaktaSewa.Models.ViewModels;
using RaktaSewa.Repository;

namespace RaktaSewa.Services
{
    public interface IEventService
    {
        (bool, string) Create(EventCreateViewModel model);

        (bool, string) Delete(int id);

        List<EventViewModel> GetAll();

        (bool, string) HardDelete(int id);
    }
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;

        public EventService(
            IEventRepository EventRepository
            )
        {
            this.eventRepository = EventRepository;
        }
        public (bool, string) Create(EventCreateViewModel model)
        {
            try
            {
                var Event = new Event()
                {
                   
                    Venue=model.Venue,
                    EventHost=model.EventHost,
                    Date=model.Date,
                    Created_At = DateTime.Now
                };

                return eventRepository.Create(Event);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Delete(int id)
        {
            try
            {
                var existing = eventRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                existing.IsDeleted = true;
                return eventRepository.Edit(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<EventViewModel> GetAll()
        {
            var data = eventRepository.GetAll();

            var ret = data.Select(p => new EventViewModel()
            {
               Id = p.Id,
              Venue = p.Venue,
              Date  =p.Date,
              Created_At=p.Created_At,
              EventHost=p.EventHost
            });
            return ret.ToList();
        }

        public (bool, string) HardDelete(int id)
        {
            try
            {
                var existing = eventRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                return eventRepository.Delete(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
