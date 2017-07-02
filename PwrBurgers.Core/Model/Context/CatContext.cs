using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PwrBurgers.Core.Model.Context
{
    public class CatContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

        private string DatabasePath { get; set; }

        public CatContext()
        {

        }

        public CatContext(string databasePath)
        {
            DatabasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }
    }
}
