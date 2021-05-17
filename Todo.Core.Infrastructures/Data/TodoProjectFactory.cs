using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Infrastructures.Data
{
    class TodoProjectFactory : IDesignTimeDbContextFactory<TodoProjectContext>
    {
        public TodoProjectContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory() ,"Settings" ,"appSettings.json"))
                .Build();

            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(configurationRoot.GetConnectionString("DefaultConnection"));
            TodoProjectContext context = new TodoProjectContext(builder.Options);
            return context;
        }
        
    }
}
