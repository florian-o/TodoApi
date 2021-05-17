using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Infrastructures.TypeConfiguration;

namespace Todo.Core.Infrastructures.Data
{
    public class TodoProjectContext : DbContext
    {
        public TodoProjectContext([NotNullAttribute] DbContextOptions options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TodoEntityConfiguration());
        }

        public DbSet<Domain.Todo> Todos { get; set; }
    }
}
