using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Database.Entity;

namespace ShoppingCart.Database
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Cart> carts{ get; set; }
        public object Cart { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source = .\SQLEXPRESS; initial catalog = ShoppingCart; persist security info = True; Integrated Security = SSPI;");
        }
    }
}
