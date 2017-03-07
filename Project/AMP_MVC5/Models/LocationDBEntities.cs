using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AMP_MVC5.Models
{
    public class LocationDBEntities : DbContext
    {
        public System.Data.Entity.DbSet<AMP_MVC5.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<AMPMVC5.Models.Location> Locations { get; set; }
    }
}