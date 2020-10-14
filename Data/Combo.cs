using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using System.ComponentModel;

namespace BleakwindBuffet.Data
{
    public class Combo: IOrderItem, INotifyPropertyChanged
    {
        List<IOrderItem> comboItems = new List<IOrderItem>();

        public Combo(IOrderItem d, IOrderItem e, IOrderItem s)
        {
            drink = (Drink)d; entree = (Entree)e; side = (Side)s;

            comboItems.Add(d); comboItems.Add(e); comboItems.Add(s);
        }

        /// <summary>
        /// Event for tracking when property changes
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// private backing variables
        /// </summary>
        private Drink drink;
        private Entree entree;
        private Side side;

        /// <summary>
        /// private backing price value
        /// </summary>
        private double price = 0;

        /// <summary>
        /// The price of the combo
        /// </summary>
        /// <value>In US dollars</value>
        public double Price
        {
            get {
                foreach (IOrderItem i in comboItems)
                {
                    price += i.Price;
                }
                price -= 1;
                return price;
            }        
        }

        /// <summary>
        /// private backing calories value
        /// </summary>
        private uint calories = 0;

        /// <summary>
        /// The calories of the drink
        /// </summary>
        public uint Calories {
            get
            {
                foreach (IOrderItem i in comboItems)
                {
                    calories += i.Calories;
                }
                return calories;
            }
        }

        /// <summary>
        /// private backing special instructions value
        /// </summary>
        private List<string> specialInstructions;

        /// <summary>
        /// The special instructions to prepare the drink
        /// </summary>
        public List<string> SpecialInstructions {
            get
            {
                foreach (IOrderItem i in comboItems)
                {
                    foreach (string s in i.SpecialInstructions)
                    {
                        specialInstructions.Add(s);
                    }
                }
                return specialInstructions;
            }

        }
    }
}
