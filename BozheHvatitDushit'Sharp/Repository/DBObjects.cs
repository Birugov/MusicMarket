using BozheHvatitDushit_Sharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushit_Sharp.Repository
{
    public class DBObjects
    {
        private readonly PurchaseContext itemContext;
        public DBObjects(PurchaseContext itemContext)
        {
            this.itemContext = itemContext;
        }
        public static void Initial(PurchaseContext content)
        {
            if (!content.Categories.Any())
            {
                content.Categories.Add(new Category { categoryName = "Струнные" });
                content.Categories.Add(new Category { categoryName = "Ударные" });
                content.Categories.Add(new Category { categoryName = "Духовые" });
                content.SaveChanges();
            }
            
            if (!content.Items.Any())
            {
                content.Items.Add(new Item { name = "FENDER CD-60 DREAD V3 DS BLK WN", price=19400, producer="FENDER", description="", image="/img/guitar2.jpg", category=content.Categories.First(x=>x.categoryName=="Духовые")});
                content.Items.Add(new Item { name = "Ударные", price = 19400, producer = "FENDER", description = "", image = "/img/guitar.jpg", category = content.Categories.First(x => x.categoryName == "Струнные")});
                content.Items.Add(new Item { name = "Ударные", price = 19400, producer = "FENDER", description = "", image = "/img/guitar.jpg", category = content.Categories.First(x => x.categoryName == "Ударные")});
                content.SaveChanges();
            }
            content.SaveChanges();

        }
        public IEnumerable<Item> Items => itemContext.Items.Include(c => c.category);
        
    }
}
