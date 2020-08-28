using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace Data.Drinks
{
    class WarriorWater
    {
        /// <summary>
        /// Gets drink size
        /// </summary>
        public Size Size => Size.Small;

        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public double Price { get; set; } = 0.00;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public uint Calories { get; set; } = 0;

        /// <summary>
        /// Sets prices and calories based on size enum
        /// </summary>
        /// <param name="Size"></param>
        public WarriorWater(Size Size)
        {
            switch (Size)
            {
                case Size.Small:
                    Price = 0.00; Calories = 0;
                    break;
                case Size.Medium:
                    Price = 0.00; Calories = 0;
                    break;
                case Size.Large:
                    Price = 0.00; Calories = 0;
                    break;
            }
        }

        /// <summary>
        /// Gets/sets Ice preference of menu item
        /// </summary>
        private bool Ice { get; set; } = true;
        
        /// <summary>
        /// Gets/sets lemon preference of menu item
        /// </summary>
        private bool Lemon { get; set; } = false;

        /// <summary>
        /// Gets list of special instructions for the menu item.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Ice) instructions.Add("Hold ice");
                if (Lemon) instructions.Add("Add lemon");
                return instructions;
            }
        }

        /// <summary>
        /// returns name of menu menu item.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} WarriorWater";
        }
    }
}
