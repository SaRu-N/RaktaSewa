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
    public interface IDonorRepository
    {
        (bool, string) Create(Donor model);

        (bool, string) Delete(Donor model);

        (bool, string) Edit(Donor model);

        IQueryable<Donor> GetAll();

        Donor GetById(int id);
    }
    public class DonorRepository : IDonorRepository
    {
        private readonly ApplicationDbContext db;

        public DonorRepository(
            ApplicationDbContext db
            )
        {
            this.db = db;
        }

        public (bool, string) Create(Donor model)
        {
            try
            {
                db.Donors.Add(model);
                db.SaveChanges();

                return (true, "Added Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Delete(Donor model)
        {
            try
            {
                db.Donors.Remove(model);
                db.SaveChanges();

                return (true, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Edit(Donor model)
        {
            try
            {
                db.Donors.Update(model);
                db.SaveChanges();

                return (true, "Updated Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public IQueryable<Donor> GetAll()
        {
            return db.Donors.Where(p => !p.IsDeleted);
        }

        public Donor GetById(int id)
        {
            var existing = db.Donors.Find(id);
            if (existing == null || existing.IsDeleted) return null;

            return existing;
        }
    }
}
