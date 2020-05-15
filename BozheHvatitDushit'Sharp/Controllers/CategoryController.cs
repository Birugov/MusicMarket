using BozheHvatitDushit_Sharp.Models;
using BozheHvatitDushit_Sharp.Repository;
using BozheHvatitDushitSharp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozheHvatitDushitSharp.Controllers
{
    public class CategoryController:Controller
    {
        private readonly DBObjects _dbObj;
        private readonly Category _category;
        public CategoryController( DBObjects dB, Category categ)
        {
            _dbObj = dB;
            _category = categ;
        }
        [Route("Category/List")]
        [Route("Category/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Item> items = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                items = _dbObj.Items.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("Drums", category, StringComparison.OrdinalIgnoreCase))
                {
                    items = _dbObj.Items.Where(i => i.category.categoryName.Equals("Ударные")).OrderBy(i => i.id);
                    currCategory = "Drums";
                }
                if (string.Equals("Strings", category, StringComparison.OrdinalIgnoreCase))
                {                   
                        items = _dbObj.Items.Where(i => i.category.categoryName.Equals("Струнные")).OrderBy(i => i.id);
                    currCategory = "Strings";
                }
                if (string.Equals("Wind", category, StringComparison.OrdinalIgnoreCase))
                {
                    items = _dbObj.Items.Where(i => i.category.categoryName.Equals("Духовые")).OrderBy(i => i.id);
                    currCategory = "Wind";
                }
            }
            var carObject = new ItemsViewModel
            {
                allItems = items,
                currCategory = currCategory
            };
            return View(carObject);
        }
    }

}

