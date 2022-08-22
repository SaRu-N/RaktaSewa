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
    public interface IBloodStockRepository
    {
        (bool, string) Create(BloodStock model);

        (bool, string) Delete(BloodStock model);

        (bool, string) Edit(BloodStock model);

        IQueryable<BloodStock> GetAll();

        BloodStock GetById(int id);
    }
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly ApplicationDbContext db;

        public BloodStockRepository(
            ApplicationDbContext db
            )
        {
            this.db = db;
        }

        public (bool, string) Create(BloodStock model)
        {
            try
            {
                db.BloodStocks.Add(model);
                db.SaveChanges();

                return (true, "Added Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Delete(BloodStock model)
        {
            try
            {
                db.BloodStocks.Remove(model);
                db.SaveChanges();

                return (true, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Edit(BloodStock model)
        {
            try
            {
                db.BloodStocks.Update(model);
                db.SaveChanges();

                return (true, "Updated Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public IQueryable<BloodStock> GetAll()
        {
            return db.BloodStocks.Where(p => !p.IsDeleted);
        }

        public BloodStock GetById(int id)
        {
            var existing = db.BloodStocks.Find(id);
            if (existing == null || existing.IsDeleted) return null;

            return existing;
        }
    }
}
