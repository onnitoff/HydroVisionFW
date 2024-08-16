using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Design_Test
{
    public class Model : DbContext
    {

        public DbSet<FilterType> Filters { get; set; }

        public Model() : base("Default")
        {

        }

    }

    public class FilterType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
