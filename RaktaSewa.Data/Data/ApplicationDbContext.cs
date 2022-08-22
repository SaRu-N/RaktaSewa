using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RaktaSewa.Models;

namespace RaktaSewa.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Blood> Bloods { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Donor> Donors { get; set; }

        public DbSet<Seeker> Seekers { get; set; }
        public DbSet<Organization> Organizations {get;set;}


    }

}