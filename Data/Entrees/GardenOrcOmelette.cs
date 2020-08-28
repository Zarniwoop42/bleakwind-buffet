using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entrees
{
    class GardenOrcOmlette
    {
        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public double Price => 4.57;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public uint Calories => 404;

        /// <summary>
        /// Gets/sets Broccoli preference of menu item
        /// </summary>
        private bool Broccoli { get; set; } = true;

        /// <summary>
        /// Gets/sets Mushrooms preference of menu item
        /// </summary>
        private bool Mushrooms { get; set; } = true;

        /// <summary>
        /// Gets/sets Tomato preference of menu item
        /// </summary>
        private bool Tomato { get; set; } = true;

        /// <summary>
        /// Gets/sets Cheddar preference of menu item
        /// </summary>
        private bool Cheddar { get; set; } = true;

        /// <summary>
        /// Gets list of special instructions for the menu item.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Broccoli) instructions.Add("Hold broccoli");
                if (!Mushrooms) instructions.Add("Hold mushrooms");
                if (!Tomato) instructions.Add("Hold tomato");
                if (!Cheddar) instructions.Add("Hold cheddar");
                return instructions;
            }
        }

        /// <summary>
        /// returns name of menu menu item.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Garden Orc Omlette";
        }
    }
}
