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

    }
    //public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    //{
    //    public DateOnlyConverter() : base(
    //            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
    //            dateTime => DateOnly.FromDateTime(dateTime))
    //    {
    //    }
    //}
}