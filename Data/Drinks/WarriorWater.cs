using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    public class WarriorWater
    {
        public Size size = Size.Small;

        /// <summary>
        /// Gets drink size
        /// </summary>
        public Size Size { get => size; set => size = value; }

        /// <summary>
        /// Gets price of menu item
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// Thrown if the price for the size of menu item is not known 
        /// </exception>
        public double Price
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// Thrown if the calories for the size of menu item is not known 
        /// </exception>
        public uint Calories
        {
            get
            {
                return 0;
            }
        }

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
        /// <returns>A string naming the menu item</returns>
        public override string ToString()
        {
            return $"{Size} Warrior Water";
        }
    }
}
