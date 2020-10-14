///Author: Graham Mathews
///BriarheartBurger.cs
///Define burger
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace BleakwindBuffet.Data.Entrees
{
    public class BriarheartBurger : Entree, IOrderItem, INotifyPropertyChanged
    {

        /// <summary>
        /// Event for tracking when property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// private backing variables
        /// </summary>
        private bool bun = true;
        private bool ketchup = true;
        private bool mustard = true;
        private bool pickle = true;
        private bool cheese = true;

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
        public bool Bun
        {
            get => bun;
            set
            {
                bun = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bun"));
            }
        }


        /// <summary>
        /// Gets/sets ketchup preference of menu item
        /// </summary>
        public bool Ketchup
        {
            get => ketchup;
            set
            {
                ketchup = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ketchup"));
            }
        }


        /// <summary>
        /// Gets/sets mustard preference of menu item
        /// </summary>
        public bool Mustard
        {
            get => mustard;
            set
            {
                mustard = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mustard"));
            }
        }


        /// <summary>
        /// Gets/sets pickle preference of menu item
        /// </summary>
        public bool Pickle
        {
            get => pickle;
            set
            {
                pickle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pickle"));
            }
        }


        /// <summary>
        /// Gets/sets cheese preference of menu item
        /// </summary>
        public bool Cheese
        {
            get => cheese;
            set
            {
                cheese = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cheese"));
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
                if (!Bun)
                {
                    instructions.Add("Hold bun");
        
                }
                if (!Ketchup)
                {
                    instructions.Add("Hold ketchup");
        
                }
                if (!Mustard)
                {
                    instructions.Add("Hold mustard");
        
                }
                if (!Pickle) {
                    instructions.Add("Hold pickle");
        
                } if (!Cheese)
                {
                    instructions.Add("Hold cheese");
        
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
            return "Briarheart Burger";
        }
    }
}
