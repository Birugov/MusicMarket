using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushit_Sharp.Models
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string producer { get; set; }
        public int price { get; set; }
        public string image { get; set; }        
        public string description { get; set; }
        public int categoryID { get; set; }
        public Category category { get; set; }
    }
}
