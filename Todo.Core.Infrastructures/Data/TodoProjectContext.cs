using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Domain;
using Todo.Core.Infrastructures.TypeConfiguration;

namespace Todo.Core.Infrastructures.Data
{
    public class TodoProjectContext : IdentityDbContext<ApplicationUser>
    {
        public TodoProjectContext([NotNullAttribute] DbContextOptions options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new TodoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration() );
            modelBuilder.ApplyConfiguration(new AddressEntityConfiguration() );
        
        }

        public DbSet<Domain.Todo> Todos { get; set; }     
        public DbSet<Domain.Address> Addresses { get; set; }
        public DbSet<Domain.ApplicationUser> ApplicationUsers { get; set; }
        
    }
}
