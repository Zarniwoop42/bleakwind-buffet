using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace Data.Drinks
{
    class SailorSoda
    { 
        /// <summary>
        /// Gets drink size
        /// </summary>
        public Size Size => Size.Small;

        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public double Price { get; set; } = 1.42;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public uint Calories { get; set; } = 117;

        /// <summary>
        /// Gets/sets flavor preference of menu item
        /// </summary>
        public SodaFlavor Flavor => SodaFlavor.Cherry;

        /// <summary>
        /// Sets prices and calories based on size enum
        /// </summary>
        /// <param name="Size"></param>
        public SailorSoda(Size Size) {
            switch (Size)
            {
                case Size.Small:
                    Price = 1.42; Calories = 117;
                    break;
                case Size.Medium:
                    Price = 1.74; Calories = 153;
                    break;
                case Size.Large:
                    Price = 2.07; Calories = 205;
                    break;
            }
        }

        /// <summary>
        /// Gets/sets Ice preference of menu item
        /// </summary>
        private bool Ice { get; set; } = true;

        /// <summary>
        /// Gets list of special instructions for the menu item.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Ice) instructions.Add("Hold ice");
                return instructions;
            }
        }

        /// <summary>
        /// returns name of menu menu item.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} {Flavor} Sailor Soda";
        }
    }
}
