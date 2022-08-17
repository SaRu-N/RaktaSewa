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
    public interface IBloodRepository
    {
        (bool, string) Create(Blood model);

        (bool, string) Delete(Blood model);

        (bool, string) Edit(Blood model);

        IQueryable<Blood> GetAll();

        Blood GetById(int id);
    }
    public class BloodRepository : IBloodRepository
    {
        private readonly ApplicationDbContext db;

        public BloodRepository(
            ApplicationDbContext db
            )
        {
            this.db = db;
        }

        public (bool, string) Create(Blood model)
        {
            try
            {
                db.Bloods.Add(model);
                db.SaveChanges();

                return (true, "Added Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Delete(Blood model)
        {
            try
            {
                db.Bloods.Remove(model);
                db.SaveChanges();

                return (true, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Edit(Blood model)
        {
            try
            {
                db.Bloods.Update(model);
                db.SaveChanges();

                return (true, "Updated Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public IQueryable<Blood> GetAll()
        {
            return db.Bloods.Where(p => !p.IsDeleted);
        }

        public Blood GetById(int id)
        {
            var existing = db.Bloods.Find(id);
            if (existing == null || existing.IsDeleted) return null;

            return existing;
        }
    }
}
