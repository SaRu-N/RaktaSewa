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
    public interface IBloodStockService
    {
        (bool, string) Create(BloodStockCreateViewModel model);

        (bool, string) Delete(int id);

        List<BloodStockViewModel> GetAll();

        (bool, string) HardDelete(int id);
    }
    public class BloodStockService : IBloodStockService
    {
        private readonly IBloodStockRepository bloodStockRepository;

        public BloodStockService(
            IBloodStockRepository BloodStockRepository
            )
        {
            this.bloodStockRepository = BloodStockRepository;
        }
        public (bool, string) Create(BloodStockCreateViewModel model)
        {
            try
            {
                var BloodStock = new BloodStock()
                {
                   Available=model.Available,
                   Amount=model.Amount,
                   blood_group=model.blood_group,
                   Stock_Id=model.Stock_Id,
                    Id = model.Id
                };

                return bloodStockRepository.Create(BloodStock);
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
                var existing = bloodStockRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                existing.IsDeleted = true;
                return bloodStockRepository.Edit(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<BloodStockViewModel> GetAll()
        {
            var data = bloodStockRepository.GetAll();

            var ret = data.Select(p => new BloodStockViewModel()
            {
              Amount = p.Amount,
              Available = p.Available,
              Stock_Id=p.Stock_Id,
              blood_group=p.blood_group,
              Created_At=p.Created_At,
            });
            return ret.ToList();
        }

        public (bool, string) HardDelete(int id)
        {
            try
            {
                var existing = bloodStockRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                return bloodStockRepository.Delete(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
