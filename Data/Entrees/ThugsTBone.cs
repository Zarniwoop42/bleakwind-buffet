﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    public class ThugsTBone : Entree, IOrderItem
    {
        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public override double Price => 6.44;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public override uint Calories => 982;

        /// <summary>
        /// Gets list of special instructions for the menu item.
        /// </summary>
        public override List<string> SpecialInstructions
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
        /// <returns>A string naming the menu item</returns>
        public override string ToString()
        {
            return "Thugs T-Bone";
        }
    }
}
