using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Domain;

namespace Todo.Core.Infrastructures.TypeConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<Domain.ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<Domain.ApplicationUser> builder)
        {
            builder.HasKey(item => item.Id);

            builder.HasOne(u => u.Address)
             .WithOne(u => u.User)
             .HasForeignKey<Address>(u => u.adresseId)
             .IsRequired();
             
        }


    }

}