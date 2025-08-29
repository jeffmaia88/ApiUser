using API.Entities;
using Microsoft.EntityFrameworkCore;
using API.Data.Mapping;

namespace API.Data
{
    public class UserDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=ApiDatabase;User ID=sa;Password=Figure09LP$;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }


        public DbSet<UserEntity> Users { get; set; }

    }
}
