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
    public class UserSectionConfiguration : IEntityTypeConfiguration<UserSection>
    {
        public void Configure(EntityTypeBuilder<UserSection> modelBuilder)
        {

            modelBuilder.HasKey(a => a.UserSectionId);

            UserTypeSeedData(modelBuilder);
        }

        private void UserTypeSeedData(EntityTypeBuilder<UserSection> modelBuilder)
        {
            modelBuilder.HasData(
                new UserSection ( 1, "Canning"),
                new UserSection (2, "Brewing"),
                new UserSection (3, "Labs"),
                new UserSection (4, "HR"),
                new UserSection (5, "Sales")
                );
        }

    }
}
