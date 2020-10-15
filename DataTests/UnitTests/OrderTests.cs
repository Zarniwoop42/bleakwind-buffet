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
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace BleakwindBuffet.DataTests.UnitTests
{
    public class OrderTests
    {
        [Fact]
        public void OrderSubtotalShouldBeSubtotalOfAllItems()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Order c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            Assert.Equal(8.96, c.Subtotal);

            s.Size = Size.Medium; m.Size = Size.Large;
            c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            Assert.Equal(9.99, c.Subtotal);
        }
        [Fact]
        public void OrderTotalShouldBeTotalOfAllItemsAndTax()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Order c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            Assert.Equal(10.04, c.Total);

            s.Size = Size.Medium; m.Size = Size.Large;
            c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            Assert.Equal(11.19, c.Total);
        }
        [Fact]
        public void OrderTaxShouldBeTaxOnAllItems()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Order c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            Assert.Equal(1.08, c.Tax);

            s.Size = Size.Medium; m.Size = Size.Large;
            c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            Assert.Equal(1.2, c.Tax);
        }
        [Fact]
        public void OrderTaxShouldBeCorrect()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Order c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            Assert.Equal(0.12, c.SalesTaxRate);

            c.SalesTaxRate = .14;

            Assert.Equal(0.14, c.SalesTaxRate);
        }
        [Fact]
        public void OrderCaloriesShouldBeCaloriesOfAllItems()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Order c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            Assert.Equal(954.ToString(), c.Calories.ToString());

            s.Size = Size.Medium; m.Size = Size.Large;
            c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            Assert.Equal(1064.ToString(), c.Calories.ToString());
        }
        
        [Fact]
        public void OrderInstructionsShouldBeInstructionsOfAllItems()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Order c = new Order(); c.Add(b); c.Add(s); c.Add(m);
            List<string> test = new List<string>();
            Assert.Equal(test, c.SpecialInstructions);

            s.Size = Size.Medium; m.Size = Size.Large; s.Ice = false; s.Flavor = SodaFlavor.Grapefruit; b.Ketchup = false;
            c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            test = new List<string>();
            test.Add("Hold ketchup"); test.Add("Hold ice");

            Assert.Equal(test, c.SpecialInstructions);
        }

        [Fact]
        public void OrderShouldRemainCorrectAfterItemRemoved()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Order c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            List<IOrderItem> test = new List<IOrderItem>();
            test.Add(b); test.Add(s); test.Add(m);

            Assert.Equal(test, c.orderList);

            c.Remove(s);

            test.Remove(s);

            Assert.Equal(test, c.orderList);
        }  
        [Fact]
        public void OrderShouldRemainCorrectAfterCleared()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Order c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            List<IOrderItem> test = new List<IOrderItem>();
            test.Add(b); test.Add(s); test.Add(m);

            Assert.Equal(test, c.orderList);

            c.Clear();

            test = new List<IOrderItem>();

            Assert.Equal(test, c.orderList);
        }
        
        [Fact]
        public void OrderShouldHaveCorrectCount()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Order c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            Assert.Equal(3, c.Count);
        }   
        [Fact]
        public void OrderShouldHaveCorrectPrice()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Order c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            Assert.Equal(0, c.Price);

            c.Price = 1;
            Assert.Equal(1, c.Price);
        }
        [Fact]
        public void OrderShouldHaveCorrectNumber()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Order c = new Order(); c.Add(b); c.Add(s); c.Add(m);

            Assert.Equal(8, c.Number);
            
            Order d = new Order(); d.Add(b); d.Add(s);

            Assert.Equal(9, d.Number);
        }
    }
}