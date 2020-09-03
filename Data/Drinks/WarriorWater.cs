using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    public class WarriorWater
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
        /// Gets/sets Ice preference of menu item
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// Gets/sets lemon preference of menu item
        /// </summary>
        public bool Lemon { get; set; } = false;

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
