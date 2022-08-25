using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityConfigurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> modelBuilder)
        {

            modelBuilder.HasKey(a => a.UserTypeId);

            UserTypeSeedData(modelBuilder);
        }

        private void UserTypeSeedData(EntityTypeBuilder<UserType> modelBuilder)
        {
            modelBuilder.HasData(
               new UserType (1,"Assistant" ),
               new UserType (2, "Manager"),
               new UserType (3, "Engineer")

               );
        }

    }
}


