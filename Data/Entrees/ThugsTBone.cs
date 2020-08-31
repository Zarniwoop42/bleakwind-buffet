﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entrees
{
    class ThugsTBone
    {
        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public double Price => 6.44;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public uint Calories => 982;

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
            return "Thugs T-Bone";
        }
    }
}