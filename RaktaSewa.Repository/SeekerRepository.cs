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
    public interface ISeekerRepository
    {
        (bool, string) Create(Seeker model);

        (bool, string) Delete(Seeker model);

        (bool, string) Edit(Seeker model);

        IQueryable<Seeker> GetAll();

        Seeker GetById(int id);
    }
    public class SeekerRepository : ISeekerRepository
    {
        private readonly ApplicationDbContext db;

        public SeekerRepository(
            ApplicationDbContext db
            )
        {
            this.db = db;
        }

        public (bool, string) Create(Seeker model)
        {
            try
            {
                db.Seekers.Add(model);
                db.SaveChanges();

                return (true, "Added Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Delete(Seeker model)
        {
            try
            {
                db.Seekers.Remove(model);
                db.SaveChanges();

                return (true, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Edit(Seeker model)
        {
            try
            {
                db.Seekers.Update(model);
                db.SaveChanges();

                return (true, "Updated Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public IQueryable<Seeker> GetAll()
        {
            return db.Seekers.Where(p => !p.IsDeleted);
        }

        public Seeker GetById(int id)
        {
            var existing = db.Seekers.Find(id);
            if (existing == null || existing.IsDeleted) return null;

            return existing;
        }
    }
}
