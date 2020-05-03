using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BozheHvatitDushit_Sharp.Models;

namespace BozheHvatitDushit_Sharp.Controllers
{
    public class HomeController : Controller
    {
         public readonly PurchaseContext itemContext;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, PurchaseContext _itemContext)
        {
            itemContext = _itemContext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> items = itemContext.Items.ToList();
            ViewBag.Items = items;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
