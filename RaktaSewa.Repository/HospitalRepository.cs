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
    public interface IHospitalRepository
    {
        (bool, string) Create(Hospital model);

        (bool, string) Delete(Hospital model);

        (bool, string) Edit(Hospital model);

        IQueryable<Hospital> GetAll();

        Hospital GetById(int id);
    }
    public class HospitalRepository : IHospitalRepository
    {
        private readonly ApplicationDbContext db;

        public HospitalRepository(
            ApplicationDbContext db
            )
        {
            this.db = db;
        }

        public (bool, string) Create(Hospital model)
        {
            try
            {
                db.Hospitals.Add(model);
                db.SaveChanges();

                return (true, "Added Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Delete(Hospital model)
        {
            try
            {
                db.Hospitals.Remove(model);
                db.SaveChanges();

                return (true, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Edit(Hospital model)
        {
            try
            {
                db.Hospitals.Update(model);
                db.SaveChanges();

                return (true, "Updated Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public IQueryable<Hospital> GetAll()
        {
            return db.Hospitals.Where(p => !p.IsDeleted);
        }

        public Hospital GetById(int id)
        {
            var existing = db.Hospitals.Find(id);
            if (existing == null || existing.IsDeleted) return null;

            return existing;
        }
    }
}
