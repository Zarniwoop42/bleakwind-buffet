using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    public class SailorSoda : Drink, IOrderItem
    {
        /// <summary>
        /// Private variables
        /// </summary>
        private bool ice = true;
        private Size size = Size.Small;
        private SodaFlavor flavor = SodaFlavor.Cherry;


        /// <summary>
        /// Gets price of menu item
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// Thrown if the price or calories for the size of menu item is not known 
        /// </exception>
        public override double Price { 
            get {
                    switch (Size)
                    {
                        case Size.Small:
                            return 1.42; 
                        case Size.Medium:
                            return 1.74; 
                        case Size.Large:
                            return 2.07; 
                    default:
                        throw new NotImplementedException($"Unknown size {Size}"); //Size price not specified
                    }
                }
        }

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// Thrown if the price or calories for the size of menu item is not known 
        /// </exception>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 117; 
                    case Size.Medium:
                        return 153; 
                    case Size.Large:
                        return 205; 
                    default:
                        throw new NotImplementedException($"Unknown size {Size}"); //Size calories not specified
                }
            }
        }

        /// <summary>
        /// Gets drink flavor
        /// </summary>
        public SodaFlavor Flavor { get => flavor; set => flavor = value; }

        /// <summary>
        /// Gets/sets Ice preference of menu item
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// Gets list of special instructions for the menu item.
        /// </summary>
        public override List<string> SpecialInstructions
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
        /// <returns>A string naming the menu item</returns>
        public override string ToString()
        {
            return $"{Size} {Flavor} Sailor Soda";
        }
    }
}
