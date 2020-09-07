using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    public class AretinoAppleJuice
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
                switch (size)
                {
                    case Size.Small:
                        return 0.62;
                    case Size.Medium:
                        return 0.87;
                    case Size.Large:
                        return 1.01;
                    default:
                        throw new NotImplementedException($"Unknown size {Size}"); //Size price not specified
                }
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
                switch (size)
                {
                    case Size.Small:
                        return 44;
                    case Size.Medium:
                        return 88;
                    case Size.Large:
                        return 132;
                    default:
                        throw new NotImplementedException($"Unknown size {Size}"); //Size calories not specified
                }
            }
        }

        /// <summary>
        /// Gets/sets Ice preference of menu item
        /// </summary>
        public bool Ice { get; set; } = false;

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
        /// <returns>A string naming the menu item</returns>
        public override string ToString()
        {
            return $"{Size} Aretino Apple Juice";
        }
    }
}
