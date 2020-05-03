using BozheHvatitDushit_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushit_Sharp.Repository
{
    public class DBObjects
    {
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
                content.Items.Add(new Item { name = "FENDER CD-60 DREAD V3 DS BLK WN", price=19400, producer="FENDER", description="", image="", category=content.Categories.First(x=>x.categoryName=="Струнные")});
                content.Items.Add(new Item { name = "Ударные", price = 19400, producer = "FENDER", description = "", image = "", category = content.Categories.First(x => x.categoryName == "Струнные")});
                content.Items.Add(new Item { name = "Ударные", price = 19400, producer = "FENDER", description = "", image = "", category = content.Categories.First(x => x.categoryName == "Струнные") });
                content.SaveChanges();
            }
            content.SaveChanges();
        }
        
    }
}
