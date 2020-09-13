 using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    public class BriarheartBurger : Entree, IOrderItem
    {
        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public override double Price => 6.32; 
        
        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public override uint Calories => 732;

        /// <summary>
        /// Gets/sets bun preference of menu item
        /// </summary>
        public bool Bun { get; set; } = true;

        /// <summary>
        /// Gets/sets ketchup preference of menu item
        /// </summary>
        public bool Ketchup { get; set; }  = true;

        /// <summary>
        /// Gets/sets mustard preference of menu item
        /// </summary>
        public bool Mustard { get; set; } = true;

        /// <summary>
        /// Gets/sets pickle preference of menu item
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// Gets/sets cheese preference of menu item
        /// </summary>
        public bool Cheese { get; set; } = true;

        /// <summary>
        /// Gets list of special instructions for the menu item.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Bun) instructions.Add("Hold bun");
                if (!Ketchup) instructions.Add("Hold ketchup");
                if (!Mustard) instructions.Add("Hold mustard");
                if (!Pickle) instructions.Add("Hold pickle");
                if (!Cheese) instructions.Add("Hold cheese");
                return instructions;
            }
        }

        /// <summary>
        /// returns name of menu menu item.
        /// </summary>
        /// <returns>A string naming the menu item</returns>
        public override string ToString()
        {
            return "Briarheart Burger";
        }
    }
}
