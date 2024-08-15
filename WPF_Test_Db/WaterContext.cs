using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Test_Db
{
    public class WaterContext : DbContext
    {
        public DbSet<FilterType> Filters { get; set; }

        public WaterContext() : base("name=WaterDbContext")
        {

        }

    }

    public class FilterType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
