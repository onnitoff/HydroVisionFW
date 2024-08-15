using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class WaterContext : DbContext
    {
        public DbSet<FilterType> Filters {  get; set; }
        public string DbPath { get; set; }

        public WaterContext()
        {
            DbPath = "Water.sqlite";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    public class FilterType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
