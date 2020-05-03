using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushit_Sharp.Models
{
    public class Category
    {
        public int id { get; set; }
        public string categoryName { get; set; }
       public virtual ICollection<Item> Items { get; set; }
    }
}
