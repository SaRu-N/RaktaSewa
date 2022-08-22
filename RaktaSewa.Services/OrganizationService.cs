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
    public interface IOrganizationService
    {
        (bool, string) Create(OrganizationCreateViewModel model);

        (bool, string) Delete(int id);

        List<OrganizationViewModel> GetAll();

        (bool, string) HardDelete(int id);
    }
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;

        public OrganizationService(
            IOrganizationRepository OrganizationRepository
            )
        {
            this.organizationRepository = OrganizationRepository;
        }
        public (bool, string) Create(OrganizationCreateViewModel model)
        {
            try
            {
                var Organization = new Organization()
                {
                    Name = model.Name,
                    Address=model.Address,
                  Type = model.Type,
                  Contact=model.Contact,
                    Created_At = DateTime.Now
                };

                return organizationRepository.Create(Organization);
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
                var existing = organizationRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                existing.IsDeleted = true;
                return organizationRepository.Edit(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<OrganizationViewModel> GetAll()
        {
            var data = organizationRepository.GetAll();

            var ret = data.Select(p => new OrganizationViewModel()
            {
               Id = p.Id,
                Address = p.Address,
                Name = p.Name,
                Type = p.Type,
                Contact=p.Contact,
                Created_At = p.Created_At,
              
            });
            return ret.ToList();
        }

        public (bool, string) HardDelete(int id)
        {
            try
            {
                var existing = organizationRepository.GetById(id);
                if (existing == null) return (false, $"Record with {id} not found");

                return organizationRepository.Delete(existing);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
