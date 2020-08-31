﻿using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace Data.Drinks
{
    class SailorSoda
    {
        private Size size = Size.Small;

        /// <summary>
        /// Gets drink size
        /// </summary>
        public Size Size {get => size; set => size = value; }

        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public double Price { 
            get {
                    switch (size)
                    {
                        case Size.Small:
                            return 1.42; 
                        case Size.Medium:
                            return 1.74; 
                        case Size.Large:
                            return 2.07; 
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
                        return 117; 
                    case Size.Medium:
                        return 153; 
                    case Size.Large:
                        return 205; 
                    default:
                        return -0; //Size calories not specified
                }
            }
        }

        private SodaFlavor flavor = SodaFlavor.Cherry;

        /// <summary>
        /// Gets drink flavor
        /// </summary>
        public SodaFlavor Flavor { get => flavor; set => flavor = value; }

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
