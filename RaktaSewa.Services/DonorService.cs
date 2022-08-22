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
    public interface IDonorService
    {
        (bool, string) Create(DonorCreateViewModel model);

        (bool, string) Delete(int id);

        List<DonorViewModel> GetAll();

        (bool, string) HardDelete(int id);
    }
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository DonorRepository;

        public DonorService(
            IDonorRepository DonorRepository
            )
        {
            this.DonorRepository = DonorRepository;
        }
        public (bool, string) Create(DonorCreateViewModel model)
        {
            try
            {
                var Donor = new Donor()
                {
                    Name = model.Name,
                    Address = model.Address,
                    blood_group = model.blood_group,
                    Gender = model.Gender,
                    //DOB = model.DOB,
                    photo = model.photo,
                    Citizenship_No = model.Citizenship_No,
                    Phone = model.Phone,
                    Amount = model.Amount,
                   isEligible=model.isEligible,
                   EventId=model.EventId,
                   HospitalId=model.HospitalId,
                   Date=model.Date,
                    Created_at = DateTime.Now
                };

                return DonorRepository.Create(Donor);
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
                var existing = DonorRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                existing.IsDeleted = true;
                return DonorRepository.Edit(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<DonorViewModel> GetAll()
        {
            var data = DonorRepository.GetAll();

            var ret = data.Select(p => new DonorViewModel()
            {
               citizen_id = p.citizen_id,
                Address = p.Address,
                Name = p.Name,
                Created_at = p.Created_at,
                Phone = p.Phone,
                blood_group=p.blood_group,
                Gender=p.Gender,
               // DOB=p.DOB,
                Citizenship_No=p.Citizenship_No,
                photo=p.photo,
                Amount=p.Amount,
                isEligible=p.isEligible,
                EventId=p.EventId,
                HospitalId=p.HospitalId,
                Date=p.Date,
                Created_At=p.Created_at
            });
            return ret.ToList();
        }

        public (bool, string) HardDelete(int id)
        {
            try
            {
                var existing = DonorRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                return DonorRepository.Delete(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
