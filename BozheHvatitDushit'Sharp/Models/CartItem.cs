using BozheHvatitDushit_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushitSharp.Models
{
    public class CartItem
    {
        public int id { get; set; }
        public Item item { get; set; }
        public int price { get; set; }
        public string CartId { get; set; }
    }
}
