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
    public interface IOrganizationRepository
    {
        (bool, string) Create(Organization model);

        (bool, string) Delete(Organization model);

        (bool, string) Edit(Organization model);

        IQueryable<Organization> GetAll();

        Organization GetById(int id);
    }
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext db;

        public OrganizationRepository(
            ApplicationDbContext db
            )
        {
            this.db = db;
        }

        public (bool, string) Create(Organization model)
        {
            try
            {
                db.Organizations.Add(model);
                db.SaveChanges();

                return (true, "Added Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Delete(Organization model)
        {
            try
            {
                db.Organizations.Remove(model);
                db.SaveChanges();

                return (true, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Edit(Organization model)
        {
            try
            {
                db.Organizations.Update(model);
                db.SaveChanges();

                return (true, "Updated Successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public IQueryable<Organization> GetAll()
        {
            return db.Organizations.Where(p => !p.IsDeleted);
        }

        public Organization GetById(int id)
        {
            var existing = db.Organizations.Find(id);
            if (existing == null || existing.IsDeleted) return null;

            return existing;
        }
    }
}
