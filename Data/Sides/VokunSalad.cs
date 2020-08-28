using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace Data.Sides
{
    class VokunSalad
    {
        /// <summary>
        /// Gets drink size
        /// </summary>
        public Size Size => Size.Small;

        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public double Price { get; set; } = 0.93;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public uint Calories { get; set; } = 41;

        /// <summary>
        /// Sets prices and calories based on size enum
        /// </summary>
        /// <param name="Size"></param>
        public VokunSalad(Size Size)
        {
            switch (Size)
            {
                case Size.Small:
                    Price = 0.93; Calories = 41;
                    break;
                case Size.Medium:
                    Price = 1.28; Calories = 52;
                    break;
                case Size.Large:
                    Price = 1.82; Calories = 73;
                    break;
            }
        }

        /// <summary>
        /// Gets list of special instructions for the menu item.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                return instructions;
            }
        }

        /// <summary>
        /// returns name of menu menu item.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} Vokun Salad";
        }
    }
}
