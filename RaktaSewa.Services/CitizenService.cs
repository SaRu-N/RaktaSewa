using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaktaSewa.Model;
using RaktaSewa.Models.ViewModels;
using RaktaSewa.Repository;

namespace RaktaSewa.Services
{
    public interface ICitizenService
    {
        (bool, string) Create(CitizenCreateViewModel model);

        (bool, string) Delete(int id);

        List<CitizenViewModel> GetAll();

        (bool, string) HardDelete(int id);
    }
    public class CitizenService : ICitizenService
    {
        private readonly ICitizenRepository citizenRepository;

        public CitizenService(
            ICitizenRepository citizenRepository
            )
        {
            this.citizenRepository = citizenRepository;
        }
        public (bool, string) Create(CitizenCreateViewModel model)
        {
            try
            {
                var citizen = new Citizen()
                {
                    Name = model.Name,
                    Address=model.Address,
                    blood_group=model.blood_group,
                    Gender=model.Gender,
                    //DOB = model.DOB,
                    photo =model.photo,
                    Citizenship_No=model.Citizenship_No,
                    Phone = model.Phone,
                    Created_at = DateTime.Now
                };

                return citizenRepository.Create(citizen);
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
                var existing = citizenRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                existing.IsDeleted = true;
                return citizenRepository.Edit(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<CitizenViewModel> GetAll()
        {
            var data = citizenRepository.GetAll();

            var ret = data.Select(p => new CitizenViewModel()
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
                photo=p.photo
            });
            return ret.ToList();
        }

        public (bool, string) HardDelete(int id)
        {
            try
            {
                var existing = citizenRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                return citizenRepository.Delete(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
