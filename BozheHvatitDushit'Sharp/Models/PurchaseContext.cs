using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BozheHvatitDushit_Sharp.Models
{
    public class PurchaseContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public PurchaseContext(DbContextOptions<PurchaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }

}
