using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaktaSewa.Data;
using RaktaSewa.Data.Data;
using RaktaSewa.Model;
using RaktaSewa.Models;

namespace RaktaSewa.Repository
{
    public interface ICitizenRepository
    {
        (bool, string) Create(Citizen model);

        (bool, string) Delete(Citizen model);

        (bool, string) Edit(Citizen model);

        IQueryable<Citizen> GetAll();

        Citizen GetById(int id);
    }
    public class CitizenRepository : ICitizenRepository
    {
        private readonly ApplicationDbContext db;

        public CitizenRepository(
            ApplicationDbContext db
            )
        {
            this.db = db;
        }

        public (bool, string) Create(Citizen model)
        {
            try
            {
                db.Citizens.Add(model);
                db.SaveChanges();

                return (true, "Added Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Delete(Citizen model)
        {
            try
            {
                db.Citizens.Remove(model);
                db.SaveChanges();

                return (true, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Edit(Citizen model)
        {
            try
            {
                db.Citizens.Update(model);
                db.SaveChanges();

                return (true, "Updated Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public IQueryable<Citizen> GetAll()
        {
            return db.Citizens.Where(p => !p.IsDeleted);
        }

        public Citizen GetById(int id)
        {
            var existing = db.Citizens.Find(id);
            if (existing == null || existing.IsDeleted) return null;

            return existing;
        }
    }
}
