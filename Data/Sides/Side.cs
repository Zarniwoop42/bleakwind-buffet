///Author: Graham Mathews
///Side.cs
///Define properties for sides to inherit
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// A base class representing common properties of sides.
    /// </summary>
    public abstract class Side : INotifyPropertyChanged
    {
        /// <summary>
        /// Event for tracking when property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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
        /// The price of the side
        /// </summary>
        /// <value>In US dollars</value>
        public abstract double Price { get; }

        /// <summary>
        /// The calories of the side
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The special instructions to prepare the side
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }
    }
}
