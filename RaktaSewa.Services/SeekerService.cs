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
    public interface ISeekerService
    {
        (bool, string) Create(SeekerCreateViewModel model);

        (bool, string) Delete(int id);

        List<SeekerViewModel> GetAll();

        (bool, string) HardDelete(int id);
    }
    public class SeekerService : ISeekerService
    {
        private readonly ISeekerRepository seekerRepository;

        public SeekerService(
            ISeekerRepository SeekerRepository
            )
        {
            this.seekerRepository = SeekerRepository;
        }
        public (bool, string) Create(SeekerCreateViewModel model)
        {
            try
            {
                var Seeker = new Seeker()
                {
                    Name = model.Name,
                    Address = model.Address,
                    blood_group = model.blood_group,
                    Gender = model.Gender,
                    //DOB = model.DOB,
                    photo = model.photo,
                    Citizenship_No = model.Citizenship_No,
                    Phone = model.Phone,
                    Patient_Name = model.Patient_Name,
                    Patient_Address=model.Patient_Address,
                    Patient_BloodGroup=model.Patient_BloodGroup,
                   Patient_Age=model.Patient_Age,
                   Amount=model.Amount,
                   PatientId=model.PatientId,
                    Created_at = DateTime.Now
                };

                return seekerRepository.Create(Seeker);
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
                var existing = seekerRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                existing.IsDeleted = true;
                return seekerRepository.Edit(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<SeekerViewModel> GetAll()
        {
            var data = seekerRepository.GetAll();

            var ret = data.Select(p => new SeekerViewModel()
            {
                citizen_id=p.citizen_id,
                PatientId = p.PatientId,
                Address = p.Address,
                Name = p.Name,
                Created_at = p.Created_at,
                Phone = p.Phone,
                blood_group=p.blood_group,
                Gender=p.Gender,
               // DOB=p.DOB,
              Patient_Address=p.Patient_Address,
              Patient_BloodGroup=p.Patient_BloodGroup,
              Patient_Age=p.Patient_Age,
              Patient_Name=p.Patient_Name,
              Amount=p.Amount,
                photo=p.photo
            });
            return ret.ToList();
        }

        public (bool, string) HardDelete(int id)
        {
            try
            {
                var existing = seekerRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                return seekerRepository.Delete(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
