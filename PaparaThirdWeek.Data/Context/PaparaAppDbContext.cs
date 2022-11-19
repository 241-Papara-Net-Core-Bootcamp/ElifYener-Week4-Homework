using Microsoft.EntityFrameworkCore;
using PaparaThirdWeek.Data.Configurations;
using PaparaThirdWeek.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PaparaThirdWeek.Data.Context
{
    public class PaparaAppDbContext : DbContext
    {
        public PaparaAppDbContext(DbContextOptions<PaparaAppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
        public DbSet<Company> Companies { get; set; }


    }
}
