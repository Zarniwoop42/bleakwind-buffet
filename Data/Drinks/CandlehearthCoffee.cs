using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace Data.Drinks
{
    class CandlehearthCoffee
    {
        /// <summary>
        /// Gets drink size
        /// </summary>
        public Size Size => Size.Small;

        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public double Price { get; set; } = 0.75;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public uint Calories { get; set; } = 7;

        /// <summary>
        /// Sets prices and calories based on size enum
        /// </summary>
        /// <param name="Size"></param>
        public CandlehearthCoffee(Size Size)
        {
            switch (Size)
            {
                case Size.Small:
                    Price = 0.75; Calories = 7;
                    break;
                case Size.Medium:
                    Price = 1.25; Calories = 10;
                    break;
                case Size.Large:
                    Price = 1.75; Calories = 20;
                    break;
            }
        }

        /// <summary>
        /// Gets/sets Ice preference of menu item
        /// </summary>
        private bool Ice { get; set; } = false;

        /// <summary>
        /// Gets/sets cream  preference of menu item
        /// </summary>
        private bool RoomForCream { get; set; } = false;
        
        /// <summary>
        /// Gets/sets decaf  preference of menu item
        /// </summary>
        private bool Decaf { get; set; } = false;

        /// <summary>
        /// Gets list of special instructions for the menu item.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Ice) instructions.Add("Add ice");
                if (RoomForCream) instructions.Add("Add cream");
                return instructions;
            }
        }

        /// <summary>
        /// returns name of menu menu item.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if(Decaf)
                return $"{Size} Decaf Candlehearth Coffee";
            else
                return $"{Size} Candlehearth Coffee";
        }
    }
}
