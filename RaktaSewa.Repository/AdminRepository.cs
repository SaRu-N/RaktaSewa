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
    public interface IAdminRepository
    {
        (bool, string) Create(Admin model);

        (bool, string) Delete(Admin model);

        (bool, string) Edit(Admin model);

        IQueryable<Admin> GetAll();

        Admin GetById(int id);
    }
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext db;

        public AdminRepository(
            ApplicationDbContext db
            )
        {
            this.db = db;
        }

        public (bool, string) Create(Admin model)
        {
            try
            {
                db.Admins.Add(model);
                db.SaveChanges();

                return (true, "Added Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Delete(Admin model)
        {
            try
            {
                db.Admins.Remove(model);
                db.SaveChanges();

                return (true, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Edit(Admin model)
        {
            try
            {
                db.Admins.Update(model);
                db.SaveChanges();

                return (true, "Updated Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public IQueryable<Admin> GetAll()
        {
            return db.Admins.Where(p => !p.IsDeleted);
        }

        public Admin GetById(int id)
        {
            var existing = db.Admins.Find(id);
            if (existing == null || existing.IsDeleted) return null;

            return existing;
        }
    }
}
