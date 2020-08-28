using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entrees
{
    class SmokehouseSkeleton
    {
        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public double Price => 5.62;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public uint Calories => 602;

        /// <summary>
        /// Gets/sets SausageLink preference of menu item
        /// </summary>
        private bool SausageLink { get; set; } = true;

        /// <summary>
        /// Gets/sets Egg preference of menu item
        /// </summary>
        private bool Egg { get; set; } = true;

        /// <summary>
        /// Gets/sets HashBrowns preference of menu item
        /// </summary>
        private bool HashBrowns { get; set; } = true;

        /// <summary>
        /// Gets/sets Pancake preference of menu item
        /// </summary>
        private bool Pancake { get; set; } = true;

        /// <summary>
        /// Gets list of special instructions for the menu item.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!SausageLink) instructions.Add("Hold sausage");
                if (!Egg) instructions.Add("Hold eggs");
                if (!HashBrowns) instructions.Add("Hold hash browns");
                if (!Pancake) instructions.Add("Hold pancakes");
                return instructions;
            }
        }

        /// <summary>
        /// returns name of menu menu item.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Smokehouse Skeleton";
        }
    }
}
