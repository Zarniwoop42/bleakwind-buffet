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


namespace BleakwindBuffet.DataTests.UnitTests
{
    public class ComboTests
    {
        [Fact]
        public void ComboPriceShouldBePriceOfAllItems()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Combo c = new Combo(s, b, m);

            Assert.Equal(7.96, c.Price);

            s.Size = Size.Medium; m.Size = Size.Large;
            c = new Combo(s, b, m);

            Assert.Equal(8.99, c.Price);
        }
        [Fact]
        public void ComboCaloriesShouldBeCaloriesOfAllItems()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Combo c = new Combo(s, b, m);

            Assert.Equal(954.ToString(), c.Calories.ToString());

            s.Size = Size.Medium; m.Size = Size.Large;
            c = new Combo(s, b, m);

            Assert.Equal(1064.ToString(), c.Calories.ToString());
        }
        
        [Fact]
        public void ComboInstructionsShouldBeInstructionsOfAllItems()
        {
            BriarheartBurger b = new BriarheartBurger(); SailorSoda s = new SailorSoda(); MadOtarGrits m = new MadOtarGrits();
            Combo c = new Combo(s, b, m);
            List<string> test = new List<string>();
            Assert.Equal(test, c.SpecialInstructions);

            s.Size = Size.Medium; m.Size = Size.Large; s.Ice = false; s.Flavor = SodaFlavor.Grapefruit; b.Ketchup = false;
            c = new Combo(s, b, m);

            test = new List<string>();
            test.Add("Hold ice"); test.Add("Hold ketchup");

            Assert.Equal(test, c.SpecialInstructions);
        }
    }
}