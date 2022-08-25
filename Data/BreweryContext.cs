using Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Models.Entities;

namespace Data
{
    public class BreweryContext : DbContext
    {
        public BreweryContext(DbContextOptions<BreweryContext>options) : base(options)
        {

        }

        public DbSet<User> User => Set<User>();
        public DbSet<UserSection> UserSection => Set<UserSection>();
        public DbSet<UserType> UserType => Set<UserType>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserSectionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }




        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BreweryContext>
        {
            public BreweryContext CreateDbContext(string[] args)
            {

                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../SwanseaBreweryStaff/appsettings.json").Build();
                var builder = new DbContextOptionsBuilder<BreweryContext>();
                var connectionString = configuration.GetConnectionString("BreweryContext");
                builder.UseSqlServer(connectionString);

                return new BreweryContext(builder.Options);
            }






        }


    }
}