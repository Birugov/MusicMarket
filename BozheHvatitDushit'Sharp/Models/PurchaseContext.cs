using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozheHvatitDushitSharp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BozheHvatitDushit_Sharp.Models
{
    public class PurchaseContext:IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        //public DbSet<Purchase> Purchases { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ApplicationUser> Customers { get; set; }
        public PurchaseContext(DbContextOptions<PurchaseContext> options) : base(options)
        {

            Database.EnsureCreated();
        }
    }

}
