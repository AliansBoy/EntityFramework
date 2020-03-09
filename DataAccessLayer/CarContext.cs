using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class CarContext : DbContext
    {
        public CarContext() : base(@"Data Source=.; Initial Catalog=CarDetail; Integrated Security=true;")
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<DetailType> Types { get; set; }
    }
}
