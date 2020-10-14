///Author: Graham Mathews
///Drink.cs
///Define Drink Interface
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// A base class representing common properties of drinks.
    /// </summary>
    public abstract class Drink : INotifyPropertyChanged
    {
        /// <summary>
        /// Event for tracking when property changes
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// private size backing variable
        /// </summary>
        private Size size = Size.Small;

        /// <summary>
        /// The size of the drink
        /// </summary>
        public virtual Size Size
        {
            get => size;
            set
            {
                size = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Size"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            }
        }

        /// <summary>
        /// The price of the drink
        /// </summary>
        /// <value>In US dollars</value>
        public abstract double Price { get; }

        /// <summary>
        /// The calories of the drink
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The special instructions to prepare the drink
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }
    }
}
