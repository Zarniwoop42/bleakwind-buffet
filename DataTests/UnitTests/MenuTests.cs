/*
 * Author: Zachery Brunner
 * Class: AretinoAppleJuiceTests.cs
 * Purpose: Test the AretinoAppleJuice.cs class in the Data library
 */
using Xunit;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Entrees;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Enums;

using System.Collections.Generic;
using System.Linq;

namespace BleakwindBuffet.DataTests.UnitTests
{
    public class MenuTests
    {
        [Fact]
        public void EntreesShouldHaveAllEntrees()
        {
            IEnumerable<IOrderItem> entrees = Menu.Entrees();
            Assert.Collection(entrees, item => Assert.Contains("Briarheart Burger", item.ToString()),
                item => Assert.Contains("Double Draugr", item.ToString()),
                item => Assert.Contains("Garden Orc Omelette", item.ToString()),
                item => Assert.Contains("Philly Poacher", item.ToString()),
                item => Assert.Contains("Smokehouse Skeleton", item.ToString()),
                item => Assert.Contains("Thalmor Triple", item.ToString()),
                item => Assert.Contains("Thugs T-Bone", item.ToString())
            );
        }

        [Fact]
        public void DrinksShouldHaveAllDrinks()
        {
            IEnumerable<IOrderItem> drinks = Menu.Drinks();
            Assert.Collection(drinks,
                item => Assert.Contains("Small Aretino Apple Juice", item.ToString()),
                item => Assert.Contains("Medium Aretino Apple Juice", item.ToString()),
                item => Assert.Contains("Large Aretino Apple Juice", item.ToString()),

                item => Assert.Contains("Small Candlehearth Coffee", item.ToString()),
                item => Assert.Contains("Medium Candlehearth Coffee", item.ToString()),
                item => Assert.Contains("Large Candlehearth Coffee", item.ToString()),

                item => Assert.Contains("Small Markarth Milk", item.ToString()),
                item => Assert.Contains("Medium Markarth Milk", item.ToString()),
                item => Assert.Contains("Large Markarth Milk", item.ToString()),

                item => Assert.Contains("Small Blackberry Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Cherry Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Grapefruit Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Lemon Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Peach Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Watermelon Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Blackberry Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Cherry Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Grapefruit Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Lemon Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Peach Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Watermelon Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Blackberry Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Cherry Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Grapefruit Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Lemon Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Peach Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Watermelon Sailor Soda", item.ToString()),

                item => Assert.Contains("Small Warrior Water", item.ToString()),
                item => Assert.Contains("Medium Warrior Water", item.ToString()),
                item => Assert.Contains("Large Warrior Water", item.ToString())

            );
        }

        [Fact]
        public void SidesShouldHaveAllSides()
        {
            IEnumerable<IOrderItem> sides = Menu.Sides();
            Assert.Collection(sides,
                item => Assert.Contains("Small Dragonborn Waffle Fries", item.ToString()),
                item => Assert.Contains("Medium Dragonborn Waffle Fries", item.ToString()),
                item => Assert.Contains("Large Dragonborn Waffle Fries", item.ToString()),

                item => Assert.Contains("Small Fried Miraak", item.ToString()),
                item => Assert.Contains("Medium Fried Miraak", item.ToString()),
                item => Assert.Contains("Large Fried Miraak", item.ToString()),

                item => Assert.Contains("Small Mad Otar Grits", item.ToString()),
                item => Assert.Contains("Medium Mad Otar Grits", item.ToString()),
                item => Assert.Contains("Large Mad Otar Grits", item.ToString()),

                item => Assert.Contains("Small Vokun Salad", item.ToString()),
                item => Assert.Contains("Medium Vokun Salad", item.ToString()),
                item => Assert.Contains("Large Vokun Salad", item.ToString())
            );
        }

        [Fact]
        public void FullMenuShouldHaveAllMenuItems()
        {
            IEnumerable<IOrderItem> fullMenu = Menu.FullMenu();
            Assert.Collection(fullMenu, item => Assert.Contains("Briarheart Burger", item.ToString()),
                item => Assert.Contains("Double Draugr", item.ToString()),
                item => Assert.Contains("Garden Orc Omelette", item.ToString()),
                item => Assert.Contains("Philly Poacher", item.ToString()),
                item => Assert.Contains("Smokehouse Skeleton", item.ToString()),
                item => Assert.Contains("Thalmor Triple", item.ToString()),
                item => Assert.Contains("Thugs T-Bone", item.ToString()),


                item => Assert.Contains("Small Aretino Apple Juice", item.ToString()),
                item => Assert.Contains("Medium Aretino Apple Juice", item.ToString()),
                item => Assert.Contains("Large Aretino Apple Juice", item.ToString()),

                item => Assert.Contains("Small Candlehearth Coffee", item.ToString()),
                item => Assert.Contains("Medium Candlehearth Coffee", item.ToString()),
                item => Assert.Contains("Large Candlehearth Coffee", item.ToString()),

                item => Assert.Contains("Small Markarth Milk", item.ToString()),
                item => Assert.Contains("Medium Markarth Milk", item.ToString()),
                item => Assert.Contains("Large Markarth Milk", item.ToString()),

                item => Assert.Contains("Small Blackberry Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Cherry Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Grapefruit Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Lemon Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Peach Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Watermelon Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Blackberry Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Cherry Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Grapefruit Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Lemon Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Peach Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Watermelon Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Blackberry Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Cherry Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Grapefruit Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Lemon Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Peach Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Watermelon Sailor Soda", item.ToString()),

                item => Assert.Contains("Small Warrior Water", item.ToString()),
                item => Assert.Contains("Medium Warrior Water", item.ToString()),
                item => Assert.Contains("Large Warrior Water", item.ToString()),


                item => Assert.Contains("Small Dragonborn Waffle Fries", item.ToString()),
                item => Assert.Contains("Medium Dragonborn Waffle Fries", item.ToString()),
                item => Assert.Contains("Large Dragonborn Waffle Fries", item.ToString()),

                item => Assert.Contains("Small Fried Miraak", item.ToString()),
                item => Assert.Contains("Medium Fried Miraak", item.ToString()),
                item => Assert.Contains("Large Fried Miraak", item.ToString()),

                item => Assert.Contains("Small Mad Otar Grits", item.ToString()),
                item => Assert.Contains("Medium Mad Otar Grits", item.ToString()),
                item => Assert.Contains("Large Mad Otar Grits", item.ToString()),

                item => Assert.Contains("Small Vokun Salad", item.ToString()),
                item => Assert.Contains("Medium Vokun Salad", item.ToString()),
                item => Assert.Contains("Large Vokun Salad", item.ToString())
            );
        }

        [Fact]
        public void AllShouldHaveAllMenuItems()
        {
            IEnumerable<IOrderItem> fullMenu = Menu.All;
            Assert.Collection(fullMenu, item => Assert.Contains("Briarheart Burger", item.ToString()),
                item => Assert.Contains("Double Draugr", item.ToString()),
                item => Assert.Contains("Garden Orc Omelette", item.ToString()),
                item => Assert.Contains("Philly Poacher", item.ToString()),
                item => Assert.Contains("Smokehouse Skeleton", item.ToString()),
                item => Assert.Contains("Thalmor Triple", item.ToString()),
                item => Assert.Contains("Thugs T-Bone", item.ToString()),


                item => Assert.Contains("Small Aretino Apple Juice", item.ToString()),
                item => Assert.Contains("Medium Aretino Apple Juice", item.ToString()),
                item => Assert.Contains("Large Aretino Apple Juice", item.ToString()),

                item => Assert.Contains("Small Candlehearth Coffee", item.ToString()),
                item => Assert.Contains("Medium Candlehearth Coffee", item.ToString()),
                item => Assert.Contains("Large Candlehearth Coffee", item.ToString()),

                item => Assert.Contains("Small Markarth Milk", item.ToString()),
                item => Assert.Contains("Medium Markarth Milk", item.ToString()),
                item => Assert.Contains("Large Markarth Milk", item.ToString()),

                item => Assert.Contains("Small Blackberry Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Cherry Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Grapefruit Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Lemon Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Peach Sailor Soda", item.ToString()),
                item => Assert.Contains("Small Watermelon Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Blackberry Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Cherry Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Grapefruit Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Lemon Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Peach Sailor Soda", item.ToString()),
                item => Assert.Contains("Medium Watermelon Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Blackberry Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Cherry Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Grapefruit Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Lemon Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Peach Sailor Soda", item.ToString()),
                item => Assert.Contains("Large Watermelon Sailor Soda", item.ToString()),

                item => Assert.Contains("Small Warrior Water", item.ToString()),
                item => Assert.Contains("Medium Warrior Water", item.ToString()),
                item => Assert.Contains("Large Warrior Water", item.ToString()),


                item => Assert.Contains("Small Dragonborn Waffle Fries", item.ToString()),
                item => Assert.Contains("Medium Dragonborn Waffle Fries", item.ToString()),
                item => Assert.Contains("Large Dragonborn Waffle Fries", item.ToString()),

                item => Assert.Contains("Small Fried Miraak", item.ToString()),
                item => Assert.Contains("Medium Fried Miraak", item.ToString()),
                item => Assert.Contains("Large Fried Miraak", item.ToString()),

                item => Assert.Contains("Small Mad Otar Grits", item.ToString()),
                item => Assert.Contains("Medium Mad Otar Grits", item.ToString()),
                item => Assert.Contains("Large Mad Otar Grits", item.ToString()),

                item => Assert.Contains("Small Vokun Salad", item.ToString()),
                item => Assert.Contains("Medium Vokun Salad", item.ToString()),
                item => Assert.Contains("Large Vokun Salad", item.ToString())
            );
        }

        [Fact]
        public void MenuShouldBeFilterableBySearch()
        {
            Assert.Collection(Menu.Search("Burger"), item => Assert.Single(Menu.Search("Burger")));
            Assert.Equal(9, Menu.Search("B").Count());
        }
        [Fact]
        public void MenuShouldBeFilterableByNullSearch()
        {
            Assert.Equal(49, Menu.Search("").Count());
        }
        [Fact]
        public void MenuShouldBeFilterableByType()
        {
            string[] types = Menu.ItemTypes.Skip(1).ToArray();
            Assert.Equal(42, Menu.FilterByItemType(Menu.All, types).Count());
        }
        [Fact]
        public void MenuShouldBeFilterableByNullType()
        {
            string[] types = Menu.ItemTypes.Skip(3).ToArray();
            Assert.Equal(49, Menu.FilterByItemType(Menu.All, types).Count());
        }
        [Fact]
        public void MenuShouldBeFilterableByCalories()
        {
            Assert.Equal(2, Menu.FilterByCaloriesRange(Menu.All, 10, 40).Count());
        }
        [Fact]
        public void MenuShouldBeFilterableByNullCalories()
        {
            Assert.Equal(6, Menu.FilterByCaloriesRange(Menu.All, null, 40).Count());
            Assert.Equal(45, Menu.FilterByCaloriesRange(Menu.All, 10, null).Count());
            Assert.Equal(49, Menu.FilterByCaloriesRange(Menu.All, null, null).Count());
        }
        [Fact]
        public void MenuShouldBeFilterableByPrice()
        {
            Assert.Equal(4, Menu.FilterByPriceRange(Menu.All, 4, 7).Count());
        }
        [Fact]
        public void MenuShouldBeFilterableByNullPrice()
        {
            Assert.Equal(46, Menu.FilterByPriceRange(Menu.All, null, 7).Count());
            Assert.Equal(7, Menu.FilterByPriceRange(Menu.All, 4, null).Count());
            Assert.Equal(49, Menu.FilterByPriceRange(Menu.All, null, null).Count());
        }
    }
}