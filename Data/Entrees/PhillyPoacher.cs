using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    public class PhillyPoacher
    {
        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public double Price => 7.23;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public uint Calories => 784;

        /// <summary>
        /// Gets/sets Sirloin preference of menu item
        /// </summary>
        public bool Sirloin { get; set; } = true;

        /// <summary>
        /// Gets/sets Onion preference of menu item
        /// </summary>
        public bool Onion { get; set; } = true;

        /// <summary>
        /// Gets/sets Roll preference of menu item
        /// </summary>
        public bool Roll { get; set; } = true;

        /// <summary>
        /// Gets list of special instructions for the menu item.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Sirloin) instructions.Add("Hold sirloin");
                if (!Onion) instructions.Add("Hold onions");
                if (!Roll) instructions.Add("Hold roll");
                return instructions;
            }
        }

        /// <summary>
        /// returns name of menu menu item.
        /// </summary>
        /// <returns>A string naming the menu item</returns>
        public override string ToString()
        {
            return "Philly Poacher";
        }
    }
}
