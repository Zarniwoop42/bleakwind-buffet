///Author: Graham Mathews
///IOrderItem.cs
///Define Properties for all items to inherit
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data
{
    /// <summary>
    /// An interface for menu items
    /// </summary>
    public interface IOrderItem
    {
        /// <summary>
        /// The price of the item
        /// </summary>
        /// <value>In US dollars</value>
        double Price { get; }

        /// <summary>
        /// The calories of the item
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// The special instructions to prepare the item
        /// </summary>
        List<string> SpecialInstructions { get; }

        /// <summary>
        /// The description
        /// </summary>
        string Description { get; }
    }
}
