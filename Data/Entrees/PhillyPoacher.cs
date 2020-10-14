///Author: Graham Mathews
///PhillyPoacher.cs
///Define PP
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace BleakwindBuffet.Data.Entrees
{
    public class PhillyPoacher : Entree, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Event for tracking when property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// private backing variables
        /// </summary>
        private bool sirloin = true;
        private bool onion = true;
        private bool roll = true;

        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public override double Price => 7.23;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public override uint Calories => 784;

        /// <summary>
        /// Gets/sets Sirloin preference of menu item
        /// </summary>
        public bool Sirloin
        {
            get => sirloin;
            set
            {
                sirloin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sirloin"));
            }
        }


        /// <summary>
        /// Gets/sets onion preference of menu item
        /// </summary>
        public bool Onion
        {
            get => onion;
            set
            {
                onion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Onion"));
            }
        }

        /// <summary>
        /// Gets/sets roll preference of menu item
        /// </summary>
        public bool Roll
        {
            get => roll;
            set
            {
                roll = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Roll"));
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
                if (!Sirloin)
                {
                    instructions.Add("Hold sirloin");
        
                }
                if (!Onion)
                {
                    instructions.Add("Hold onions");
        
                }
                if (!Roll)
                {
                    instructions.Add("Hold roll");
        
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
            return "Philly Poacher";
        }
    }
}
