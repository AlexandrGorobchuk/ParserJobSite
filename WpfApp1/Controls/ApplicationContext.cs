using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Controls
{
    internal class ApplicationContext: DbContext
    {
        public DbSet<EmployeeDb> employees { get; set; }
        public DbSet<HumanDb> humanDb { get; set; }

        public ApplicationContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseMySQL("server=bestadvi.mysql.tools;database=bestadvi_testgorob;user=bestadvi_testgorob;password=3a7#P*px5G");
        }

    }
}
