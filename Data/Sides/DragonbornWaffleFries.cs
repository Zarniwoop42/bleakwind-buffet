using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Sides
{
    public class DragonbornWaffleFries
    {
        public Size size = Size.Small;

        /// <summary>
        /// Gets drink size
        /// </summary>
        public Size Size { get => size; set => size = value; }

        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public double Price
        {
            get
            {
                switch (size)
                {
                    case Size.Small:
                        return 0.42;
                    case Size.Medium:
                        return 0.76;
                    case Size.Large:
                        return 0.96;
                    default:
                        return -0.0; //Size price not specified
                }
            }
        }

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public uint Calories
        {
            get
            {
                switch (size)
                {
                    case Size.Small:
                        return 77;
                    case Size.Medium:
                        return 89;
                    case Size.Large:
                        return 100;
                    default:
                        return -0; //Size calories not specified
                }
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
            return $"{Size} Dragonborn Waffle Fries";
        }
    }
}
