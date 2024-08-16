using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Test
{
    public class WaterDbContext : DbContext
    {
        public WaterDbContext(string connectionString) : base(new SQLiteConnection(connectionString), true)
        {
        }

        public DbSet<FilterType> Filter { get; set; }
    }

    public class FilterType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
