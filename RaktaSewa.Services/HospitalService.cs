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
    public interface IHospitalService
    {
        (bool, string) Create(HospitalCreateViewModel model);

        (bool, string) Delete(int id);

        List<HospitalViewModel> GetAll();

        (bool, string) HardDelete(int id);
    }
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository hospitalRepository;

        public HospitalService(
            IHospitalRepository HospitalRepository
            )
        {
            this.hospitalRepository = HospitalRepository;
        }
        public (bool, string) Create(HospitalCreateViewModel model)
        {
            try
            {
                var Hospital = new Hospital()
                {
                    Name = model.Name,
                    Address=model.Address,
                    Contact=model.Contact,
                    Email=model.Email,
                    Reg_No=model.Reg_No,
                    Created_at = DateTime.Now
                };

                return hospitalRepository.Create(Hospital);
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
                var existing = hospitalRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                existing.IsDeleted = true;
                return hospitalRepository.Edit(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<HospitalViewModel> GetAll()
        {
            var data = hospitalRepository.GetAll();

            var ret = data.Select(p => new HospitalViewModel()
            {
                Id = p.Id,
                Address = p.Address,
                Name = p.Name,
                Created_at = p.Created_at,
                Contact = p.Contact,
                Reg_No = p.Reg_No,
                Email=p.Email,
            });
            return ret.ToList();
        }

        public (bool, string) HardDelete(int id)
        {
            try
            {
                var existing = hospitalRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                return hospitalRepository.Delete(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
