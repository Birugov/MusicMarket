using BozheHvatitDushit_Sharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushitSharp.ViewModels
{
    public class ItemsViewModel
    {
        public IEnumerable<Item> allItems { get; set; }
        public string currCategory { get; set; }

    }
}