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
            comboItems.Add(d); comboItems.Add(e); comboItems.Add(s);

            for (int i = 0; i < comboItems.Count; i++)
            {
                if(comboItems[i].GetType().ToString() == "Drink")
                {
                    drink = (Drink)comboItems[i];
                }
                if(comboItems[i].GetType().ToString() == "Side")
                {
                    side = (Side)comboItems[i];
                }
                if(comboItems[i].GetType().ToString() == "Entree")
                {
                    entree = (Entree)comboItems[i];
                }
            }
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
                price = 0;
                foreach (IOrderItem i in comboItems)
                {
                    price += i.Price;
                }
                price -= 1;
                return Math.Round(price, 2);
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
                calories = 0;
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
        private List<string> specialInstructions = new List<string>();

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
                        if(s != null)
                            specialInstructions.Add(s);
                    }
                }
                return specialInstructions;
            }

        }

        public string Description => throw new NotImplementedException();
    }
}
