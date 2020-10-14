///Author: Graham Mathews
///CandlehearthCoffee.cs
///Define CHH
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;
using System.ComponentModel;


namespace BleakwindBuffet.Data.Drinks
{
    public class CandlehearthCoffee : Drink, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Private variables
        /// </summary>
        private bool ice = false;
        private Size size = Size.Small;
        private bool roomForCream = false;
        private bool decaf = false;

        /// <summary>
        /// Event for tracking when property changes
        /// </summary>
        public override event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Gets price of menu item
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// Thrown if the price or calories for the size of menu item is not known 
        /// </exception>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 0.75;
                    case Size.Medium:
                        return 1.25;
                    case Size.Large:
                        return 1.75;
                    default:
                        throw new NotImplementedException($"Unknown size {Size}"); //Size price not specified
                }
            }
        }

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// Thrown if the price or calories for the size of menu item is not known 
        /// </exception>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 7;
                    case Size.Medium:
                        return 10;
                    case Size.Large:
                        return 20;
                    default:
                        throw new NotImplementedException($"Unknown size {Size}"); //Size calories not specified
                }
            }
        }

        /// <summary>
        /// Gets/sets Ice preference of menu item
        /// </summary>
        public bool Ice
        {
            get => ice;
            set
            {
                ice = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ice"));
            }
        }

        /// <summary>
        /// Gets/sets cream preference of menu item
        /// </summary>
        public bool RoomForCream
        {
            get => roomForCream;
            set
            {
                roomForCream = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RoomForCream"));
            }
        }


        /// <summary>
        /// Gets/sets Decaf preference of menu item
        /// </summary>
        public bool Decaf
        {
            get => decaf;
            set
            {
                decaf = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Decaf"));
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
                if (Ice)
                {
                    instructions.Add("Add ice");
        
                }
                if (RoomForCream)
                {
                    instructions.Add("Add cream");
        
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
            if(Decaf)
                return $"{Size} Decaf Candlehearth Coffee";
            else
                return $"{Size} Candlehearth Coffee";
        }
    }
}
