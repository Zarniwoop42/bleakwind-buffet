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
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Entrees;

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
            MenuItems = Menu.All;
            // Filter by item type
            if (itemTypes != null && itemTypes.Length != 0)
            {
                List<IOrderItem> typefilter = new List<IOrderItem>();
                if (itemTypes.Contains("Drink"))
                    foreach (IOrderItem i in MenuItems.Where(item => item is Drink))
                        typefilter.Add(i);
                if (itemTypes.Contains("Entree"))
                    foreach (IOrderItem i in MenuItems.Where(item => item is Entree))
                        typefilter.Add(i);
                if (itemTypes.Contains("Side"))
                    foreach (IOrderItem i in MenuItems.Where(item => item is Side))
                        typefilter.Add(i);
                MenuItems = typefilter;
            }
            // Search item items for the SearchTerms
            if (SearchTerms != null)
            {
                List<IOrderItem> filter = new List<IOrderItem>();
                foreach(string s in SearchTerms.Split(' '))
                {
                    foreach (IOrderItem i in MenuItems.Where(item => item.ToString().Contains(s, StringComparison.InvariantCultureIgnoreCase) || item.Description.Contains(s, StringComparison.InvariantCultureIgnoreCase)))
                        filter.Add(i);
                }
                MenuItems = filter;
            } 
    
               

            // Filter by calories
            if (calMax != null || calMin != null)
            {
                if (calMin == null)
                    MenuItems = MenuItems.Where(item =>
                        item.Calories <= calMax
                        );
                else if (calMax == null)
                    MenuItems = MenuItems.Where(item =>
                        item.Calories >= calMin
                        );
                else
                    MenuItems = MenuItems.Where(item =>
                        item.Calories >= calMin && item.Calories <= calMax
                        );
            }  // Filter by price
            if (priceMax != null || priceMin != null)
            {
                if (priceMin == null)
                    MenuItems = MenuItems.Where(item =>
                        item.Price <= priceMax
                        );
                else if (priceMax == null)
                    MenuItems = MenuItems.Where(item =>
                        item.Price >= priceMin
                        );
                else
                    MenuItems = MenuItems.Where(item =>
                        item.Price >= priceMin && item.Price <= priceMax
                        );
            }
            /*
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
            */
        }


        public string Name { get; set; }
        public string Price { get; set; }
        public string Calories { get; set; }

    }
}
