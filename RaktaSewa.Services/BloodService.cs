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
    public interface IBloodService
    {
        (bool, string) Create(BloodCreateViewModel model);

        (bool, string) Delete(int id);

        List<BloodViewModel> GetAll();

        (bool, string) HardDelete(int id);
    }
    public class BloodService : IBloodService
    {
        private readonly IBloodRepository bloodRepository;

        public BloodService(
            IBloodRepository bloodRepository
            )
        {
            this.bloodRepository = bloodRepository;
        }
        public (bool, string) Create(BloodCreateViewModel model)
        {
            try
            {
                var blood = new Blood()
                {
                    Id=model.Id,
                    blood_group=model.blood_group,
                };

                return bloodRepository.Create(blood);
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
                var existing = bloodRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                existing.IsDeleted = true;
                return bloodRepository.Edit(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<BloodViewModel> GetAll()
        {
            var data = bloodRepository.GetAll();

            var ret = data.Select(p => new BloodViewModel()
            {
                Id=p.Id,
                blood_group=p.blood_group
            });
            return ret.ToList();
        }

        public (bool, string) HardDelete(int id)
        {
            try
            {
                var existing = bloodRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                return bloodRepository.Delete(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
