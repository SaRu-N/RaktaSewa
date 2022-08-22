using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaktaSewa.Data;
using RaktaSewa.Data.Data;
using RaktaSewa.Models;

namespace RaktaSewa.Repository
{
    public interface IEventRepository
    {
        (bool, string) Create(Event model);

        (bool, string) Delete(Event model);

        (bool, string) Edit(Event model);

        IQueryable<Event> GetAll();

        Event GetById(int id);
    }
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext db;

        public EventRepository(
            ApplicationDbContext db
            )
        {
            this.db = db;
        }

        public (bool, string) Create(Event model)
        {
            try
            {
                db.Events.Add(model);
                db.SaveChanges();

                return (true, "Added Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Delete(Event model)
        {
            try
            {
                db.Events.Remove(model);
                db.SaveChanges();

                return (true, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Edit(Event model)
        {
            try
            {
                db.Events.Update(model);
                db.SaveChanges();

                return (true, "Updated Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public IQueryable<Event> GetAll()
        {
            return db.Events.Where(p => !p.IsDeleted);
        }

        public Event GetById(int id)
        {
            var existing = db.Events.Find(id);
            if (existing == null || existing.IsDeleted) return null;

            return existing;
        }
    }
}
