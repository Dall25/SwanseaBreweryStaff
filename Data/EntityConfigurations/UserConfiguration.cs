using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
           
               modelBuilder.HasKey(a => a.UserId);


            modelBuilder.HasOne(a => a.UserType)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.UserTypeId);

            modelBuilder.HasOne(a => a.UserSection)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.UserSectionId);

            UserSeedData(modelBuilder);
        }

        private void UserSeedData(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.HasData(
               new User ( Guid.Parse("d818a056-1d33-4276-bc80-c8dcf128fe20"), 2, 4, "Ben", "Sztucki", "Ben@SWBC.com" ),
               new User ( Guid.Parse("630958ef-30c8-4c43-a822-f5b3b5192bd1"), 2, 3, "Luke", "Dallimore","Luke@SWBC.com"),
               new User ( Guid.Parse("ff96657b-00c1-4c68-a6d6-4bd213777f53"), 3, 2, "Mike", "Prosser",  "Mike@SWBC.com" ),
               new User ( Guid.Parse("42481486-17f2-4cd3-bda2-04d3b46c8e0f"), 1, 3, "Maddie", "Williams", "Maddie@SWBC.com" ),
               new User ( Guid.Parse("ef258c81-b08e-4b73-9173-956db34a6e7b"), 2, 4, "Sarah",  "Williams","Sarah@SWBC.com" ),
               new User ( Guid.Parse("39b79056-d79a-4672-a068-104cc3d77116"), 2, 5, "Jamie", "Buckley", "Jamie@SWBC.com" ),
               new User ( Guid.Parse("bf445a42-b936-44d4-90b4-00cc4a9189b7"), 1, 1, "Henry", "Dallimore", "Henry@SWBC.com"),
               new User ( Guid.Parse("120d5ff6-1d0a-4915-88b3-450cdaf9fb6d"), 1, 4, "Ellie", "Dallimore", "Ellie@SWBC.com"),
               new User ( Guid.Parse("6325b363-02c5-4d36-bb95-a232b226e95f"), 2, 1, "Alan", "Grant", "Alan@SWBC.com"),
               new User ( Guid.Parse("822bfbc5-f936-4da2-93af-d0caf7efa97d"), 1, 2, "Ian", "Malcome", "Ian@SWBC.com")
               );
        }
    }
}
