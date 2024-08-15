using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Model.DataBaseModel
{
    public class WaterContext : DbContext
    {
        public WaterContext() : base("name=SQLiteConnection") { }

        public DbSet<Filter> Filters { get; set; }
        public DbSet<ApplyingFilter> ApplyingFilters { get; set; }
        public DbSet<FilterType> FilterTypes { get; set; }
        public DbSet<OperatingPressureFilter> OperatingPressureFilters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Настройка моделей, если необходимо
        }
    }

    public class Filter
    {
        [Key]
        public int Id { get; set; }
        public int IdApplyingFilters { get; set; }
        public int? IdFilterTypes { get; set; } // IdFilterTypes может быть NULL
        public string Cipheer { get; set; }
        public int IdOperatingPressure { get; set; }
        public int Diameter { get; set; }
        public int FilterLoadHeight { get; set; }
        public int? WaterConsumption { get; set; } // WaterConsumption может быть NULL

        public virtual ApplyingFilter ApplyingFilter { get; set; }
        public virtual FilterType FilterType { get; set; }
        public virtual OperatingPressureFilter OperatingPressureFilter { get; set; }
    }

    public class ApplyingFilter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FilterType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OperatingPressureFilter
    {
        [Key]
        public int Id { get; set; }
        public double Value { get; set; }
    }
}
