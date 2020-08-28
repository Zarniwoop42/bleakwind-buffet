using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace Data.Drinks
{
    class MarkarthMilk
    {
        /// <summary>
        /// Gets drink size
        /// </summary>
        public Size Size => Size.Small;

        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public double Price { get; set; } = 1.05;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public uint Calories { get; set; } = 56;

        /// <summary>
        /// Sets prices and calories based on size enum
        /// </summary>
        /// <param name="Size"></param>
        public MarkarthMilk(Size Size)
        {
            switch (Size)
            {
                case Size.Small:
                    Price = 1.05; Calories = 56;
                    break;
                case Size.Medium:
                    Price = 1.11; Calories = 72;
                    break;
                case Size.Large:
                    Price = 1.22; Calories = 93;
                    break;
            }
        }

        /// <summary>
        /// Gets/sets Ice preference of menu item
        /// </summary>
        private bool Ice { get; set; } = false;

        /// <summary>
        /// Gets list of special instructions for the menu item.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Ice) instructions.Add("Add ice");
                return instructions;
            }
        }

        /// <summary>
        /// returns name of menu menu item.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} Markarth Milk";
        }
    }
}
