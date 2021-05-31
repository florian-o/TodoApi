using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Infrastructures.TypeConfiguration
{
    public class TodoEntityConfiguration : IEntityTypeConfiguration<Domain.Todo>
    {
        public void Configure(EntityTypeBuilder<Domain.Todo> builder)
        {
            builder.HasKey(item => item.idTodo);
            builder.HasOne(item => item.User)
               .WithMany(item => item.Todos)
               .HasForeignKey(item => item.userId);
            
               
        }
    }
}
