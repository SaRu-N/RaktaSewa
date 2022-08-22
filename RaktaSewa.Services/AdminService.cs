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
    public interface IAdminService
    {
        (bool, string) Create(AdminCreateViewModel model);

        (bool, string) Delete(int id);

        List<AdminViewModel> GetAll();

        (bool, string) HardDelete(int id);
    }
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository adminRepository;

        public AdminService(
            IAdminRepository AdminRepository
            )
        {
            this.adminRepository = AdminRepository;
        }
        public (bool, string) Create(AdminCreateViewModel model)
        {
            try
            {
                var Admin = new Admin()
                {
                    Name = model.Name,
                    Address=model.Address,
                    blood_group=model.blood_group,
                    Emp_Id=model.Emp_Id,
                    Email=model.Email,
                    Phone_Number=model.Phone_Number,
                    
                    Created_At = DateTime.Now
                };

                return adminRepository.Create(Admin);
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
                var existing = adminRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                existing.IsDeleted = true;
                return adminRepository.Edit(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<AdminViewModel> GetAll()
        {
            var data = adminRepository.GetAll();

            var ret = data.Select(p => new AdminViewModel()
            {
                Id = p.Id,
                Address = p.Address,
                Name = p.Name,
                Created_At = p.Created_At,
                Phone_Number = p.Phone_Number,
                blood_group=p.blood_group,
               Email=p.Email,
               Emp_Id=p.Emp_Id
            });
            return ret.ToList();
        }

        public (bool, string) HardDelete(int id)
        {
            try
            {
                var existing = adminRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                return adminRepository.Delete(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
