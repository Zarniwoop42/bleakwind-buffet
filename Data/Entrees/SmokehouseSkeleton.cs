///Author: Graham Mathews
///SmokehouseSkeleton.cs
///Define SHS
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    public class SmokehouseSkeleton : Entree, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Event for tracking when property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// private backing variables
        /// </summary>
        private bool sausageLink = true;
        private bool egg = true;
        private bool hashBrowns = true;
        private bool pancake = true;

        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public override double Price => 5.62;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public override uint Calories => 602;


        /// <summary>
        /// Gets/sets sausageLink preference of menu item
        /// </summary>
        public bool SausageLink
        {
            get => sausageLink;
            set
            {
                sausageLink = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SausageLink"));
            }
        }


        /// <summary>
        /// Gets/sets egg preference of menu item
        /// </summary>
        public bool Egg
        {
            get => egg;
            set
            {
                egg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Egg"));
            }
        }

        /// <summary>
        /// Gets/sets hashBrowns preference of menu item
        /// </summary>
        public bool HashBrowns
        {
            get => hashBrowns;
            set
            {
                hashBrowns = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HashBrowns"));
            }
        }

        /// <summary>
        /// Gets/sets pancake preference of menu item
        /// </summary>
        public bool Pancake
        {
            get => pancake;
            set
            {
                pancake = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pancake"));
            }
        }


        /// <summary>
        /// Gets list of special instructions for the menu item.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!SausageLink)
                {
                    instructions.Add("Hold sausage");
        
                }
                if (!Egg)
                {
                    instructions.Add("Hold eggs");
        
                }
                if (!HashBrowns)
                {
                    instructions.Add("Hold hash browns");
        
                }
                if (!Pancake)
                {
                    instructions.Add("Hold pancakes");
        
                }
                return instructions;
            }
        }

        /// <summary>
        /// returns name of menu menu item.
        /// </summary>
        /// <returns>A string naming the menu item</returns>
        public override string ToString()
        {
            return "Smokehouse Skeleton";
        }
    }
}
