﻿///Author: Graham Mathews
///Menu.cs
///Offers functions for creating various menus
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using System.Linq;

namespace BleakwindBuffet.Data
{
    /// <summary>
    /// The menu for selecting menu items
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Creates list of all entrees
        /// </summary>
        /// <returns>list of all entrees</returns>
        public static IEnumerable<IOrderItem> Entrees()
        {
            List<IOrderItem> entrees = new List<IOrderItem>();

            BriarheartBurger bb = new BriarheartBurger();
            Entree e = (Entree)bb;
            entrees.Add((IOrderItem)e);

            DoubleDraugr dd = new DoubleDraugr();
            e = (Entree)dd;
            entrees.Add((IOrderItem)e);

            GardenOrcOmelette goo = new GardenOrcOmelette();
            e = (Entree)goo;
            entrees.Add((IOrderItem)e);

            PhillyPoacher pp = new PhillyPoacher();
            e = (Entree)pp;
            entrees.Add((IOrderItem)e);

            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            e = (Entree)shs;
            entrees.Add((IOrderItem)e);

            ThalmorTriple tt = new ThalmorTriple();
            e = (Entree)tt;
            entrees.Add((IOrderItem)e);

            ThugsTBone ttb = new ThugsTBone();
            e = (Entree)ttb;
            entrees.Add((IOrderItem)e);

            return entrees;
        }

        /// <summary>
        /// Creates list of all sides
        /// </summary>
        /// <returns>list of all sides</returns>
        public static IEnumerable<IOrderItem> Sides()
        {
            List<IOrderItem> sides = new List<IOrderItem>();

            DragonbornWaffleFries dbwf = new DragonbornWaffleFries();
            Side e = (Side)dbwf;
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                dbwf = new DragonbornWaffleFries();
                e = (Side)dbwf; e.Size = size;
                sides.Add((IOrderItem)e);
            }

            FriedMiraak fm = new FriedMiraak(); e = (Side)fm;
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                fm = new FriedMiraak();
                e = (Side)fm; e.Size = size;
                sides.Add((IOrderItem)e);
            }

            MadOtarGrits mog = new MadOtarGrits(); e = (Side)mog;
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                mog = new MadOtarGrits();
                e = (Side)mog; e.Size = size;
                sides.Add((IOrderItem)e);
            }

            VokunSalad vs = new VokunSalad(); e = (Side)vs;
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                vs = new VokunSalad();
                e = (Side)vs; e.Size = size;
                sides.Add((IOrderItem)e);
            }

            return sides;
        }

        /// <summary>
        /// Creates list of all drinks
        /// </summary>
        /// <returns>list of all drinks</returns>
        public static IEnumerable<IOrderItem> Drinks()
        {
            List<IOrderItem> drinks = new List<IOrderItem>();

            AretinoAppleJuice aj = new AretinoAppleJuice(); Drink e = (Drink)aj;
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                aj = new AretinoAppleJuice();
                e = (Drink)aj;
                e.Size = size;
                drinks.Add((IOrderItem)e);
            }

            CandlehearthCoffee chc = new CandlehearthCoffee(); e = (Drink)chc;
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                chc = new CandlehearthCoffee();
                e = (Drink)chc;
                e.Size = size;
                drinks.Add((IOrderItem)e);
            }

            MarkarthMilk mm = new MarkarthMilk(); e = (Drink)mm;
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                mm = new MarkarthMilk();
                e = (Drink)mm;
                e.Size = size;
                drinks.Add((IOrderItem)e);
            }

            SailorSoda ss = new SailorSoda(); e = (Drink)ss;
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                ss = new SailorSoda(); e = (Drink)ss; e.Size = size;
                foreach (SodaFlavor flavor in Enum.GetValues(typeof(SodaFlavor)))
                {
                    ss = new SailorSoda(); ss.Flavor = flavor;  e = (Drink)ss; e.Size = size;
                    drinks.Add((IOrderItem)e);
                }
            }

            WarriorWater ww = new WarriorWater(); e = (Drink)ww;
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                ww = new WarriorWater();
                e = (Drink)ww;
                e.Size = size;
                drinks.Add((IOrderItem)e);
            }

            return drinks;
        }

        /// <summary>
        /// Creates list of full menu
        /// </summary>
        /// <returns>list of every menu item</returns>
        public static IEnumerable<IOrderItem> FullMenu()
        {
            IEnumerable<IOrderItem> entrees = Entrees();
            IEnumerable<IOrderItem> sides = Sides();
            IEnumerable<IOrderItem> drinks = Drinks();

            List<IOrderItem> fullMenu = new List<IOrderItem>();
            foreach(IOrderItem entree in entrees)
                fullMenu.Add(entree);
            foreach (IOrderItem drink in drinks)
                fullMenu.Add(drink);
            foreach (IOrderItem side in sides)
                fullMenu.Add(side);
            return fullMenu;
        }




        private static IEnumerable<IOrderItem> menuItems = new List<IOrderItem>();

        /// <summary>
        /// Gets menu item types represented in the database 
        /// </summary>
        public static string[] ItemTypes { get; } = { "Entree", "Side", "Drink" };

        /// <summary>
        /// Gets all the items in the database
        /// </summary>
        public static IEnumerable<IOrderItem> All { get { return menuItems; } }


        /// <summary>
        /// gets the menu database 
        /// </summary>
        static Menu()
        {
            menuItems = Menu.FullMenu();
        }

        /// <summary>
        /// searches items in database for matches
        /// </summary>
        /// <param name="terms">terms to search</param>
        /// <returns>result of search</returns>
        public static IEnumerable<IOrderItem> Search(string terms)
        {
            List<IOrderItem> results = new List<IOrderItem>();
            if (terms == null) return All;

            foreach (IOrderItem menuItem in All)
            {
                if (menuItem.ToString().ToLower().Contains(terms.ToLower()))
                    results.Add(menuItem);
            }
            return results;
        }

        /// <summary>
        /// Gets the possible itemTypes
        /// </summary>
        public static string[] itemTypes
        {
            get => new string[]
            {
            "Entree",
            "Side",
            "Drink"
            };
        }

        /// <summary>
        /// Filters the provided collection of menu items
        /// </summary>
        /// <param name="menuItems">The collection of items to filter</param>
        /// <param name="itemType">The item type to include</param>
        /// <returns>A collection containing only movies that match the filter</returns>
        public static IEnumerable<IOrderItem> FilterByItemType(IEnumerable<IOrderItem> menuItems, IEnumerable<string> itemType)
        {
            if (itemType == null || itemType.Count() == 0) return menuItems;

            List<IOrderItem> results = new List<IOrderItem>();
            foreach (IOrderItem item in menuItems)
            {
                if (itemType.Contains("Drink") && item is Drink)
                    results.Add(item);
                if (itemType.Contains("Side") && item is Side)
                    results.Add(item);
                if (itemType.Contains("Entree") && item is Entree)
                    results.Add(item);
            }
            return results;
        }

        /// <summary>
        /// Filters the provided collection of items
        /// to those with calories falling within
        /// the specified range
        /// </summary>
        /// <param name="menuItems">The collection of items to filter</param>
        /// <param name="min">The minimum range value</param>
        /// <param name="max">The maximum range value</param>
        /// <returns>The filtered menu collection</returns>
        public static IEnumerable<IOrderItem> FilterByCaloriesRange(IEnumerable<IOrderItem> menuItems, double? min, double? max)
        {
            if (min == null && max == null) return menuItems;
            var results = new List<IOrderItem>();

            if (min == null)
            {
                foreach (IOrderItem item in menuItems)
                {
                    if (item.Calories <= max) results.Add(item);
                }
                return results;
            }

            if (max == null)
            {
                foreach (IOrderItem item in menuItems)
                {
                    if (item.Calories >= min) results.Add(item);
                }
                return results;
            }

            foreach (IOrderItem item in menuItems)
            {
                if (item.Calories >= min && item.Calories <= max)
                {
                    results.Add(item);
                }
            }
            return results;
        }

        /// <summary>
        /// Filters the provided collection of items
        /// to those with prices falling within
        /// the specified range
        /// </summary>
        /// <param name="movies">The collection of items to filter</param>
        /// <param name="min">The minimum range value</param>
        /// <param name="max">The maximum range value</param>
        /// <returns>The filtered menu items collection</returns>
        public static IEnumerable<IOrderItem> FilterByPriceRange(IEnumerable<IOrderItem> menuItems, double? min, double? max)
        {
            if (min == null && max == null) return menuItems;
            var results = new List<IOrderItem>();


            if (min == null)
            {
                foreach (IOrderItem item in menuItems)
                {
                    if (item.Price <= max) results.Add(item);
                }
                return results;
            }

            if (max == null)
            {
                foreach (IOrderItem item in menuItems)
                {
                    if (item.Price >= min) results.Add(item);
                }
                return results;
            }

            foreach (IOrderItem item in menuItems)
            {
                if (item.Price >= min && item.Price <= max)
                {
                    results.Add(item);
                }
            }
            return results;
        }

    }
}
