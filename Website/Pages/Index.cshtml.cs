///Author: Graham Mathews
///index.cshtml.cs
///Defines index page

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BleakwindBuffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<IOrderItem> MenuItems { get; set; }

        // [BindProperty]
        public string SearchTerms { get; set; }

        public double? calMin { get; set; }

        public double? calMax { get; set; }
        public double? priceMin { get; set; }

        public double? priceMax { get; set; }

        /// <summary>
        /// The filtered types
        /// </summary>
        public string[] itemTypes { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string SearchTerms, string[] itemTypes, double? calMin, double? calMax, double? priceMin, double? priceMax)
        {
            if (calMin != null)
                calMin = double.Parse(Request.Query["calMin"]);
            if (calMax != null)
                calMax = double.Parse(Request.Query["calMax"]);
            if (priceMin != null)
                priceMin = double.Parse(Request.Query["priceMin"]);
            if (priceMax != null)
                priceMax = double.Parse(Request.Query["priceMax"]);

            MenuItems = Menu.Search(SearchTerms);
            MenuItems = Menu.FilterByItemType(MenuItems, itemTypes);
            MenuItems = Menu.FilterByCaloriesRange(MenuItems, calMin, calMax);
            MenuItems = Menu.FilterByPriceRange(MenuItems, priceMin, priceMax);
        }


        public string Name { get; set; }
        public string Price { get; set; }
        public string Calories { get; set; }

    }
}
