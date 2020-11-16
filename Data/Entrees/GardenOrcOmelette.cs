///Author: Graham Mathews
///GardenOrcOmelette.cs
///Define GOO
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    public class GardenOrcOmelette : Entree, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Event for tracking when property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// private backing variables
        /// </summary>
        private bool broccoli = true;
        private bool mushrooms = true;
        private bool tomato = true;
        private bool cheddar = true;

        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public override double Price => 4.57;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public override uint Calories => 404;

        /// <summary>
        /// Gets/sets broccoli preference of menu item
        /// </summary>
        public bool Broccoli
        {
            get => broccoli;
            set
            {
                broccoli = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Broccoli"));
            }
        }


        /// <summary>
        /// Gets/sets mushrooms preference of menu item
        /// </summary>
        public bool Mushrooms
        {
            get => mushrooms;
            set
            {
                mushrooms = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mushrooms"));
            }
        }

        /// <summary>
        /// Gets/sets tomato preference of menu item
        /// </summary>
        public bool Tomato
        {
            get => tomato;
            set
            {
                tomato = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tomato"));
            }
        }

        /// <summary>
        /// Gets/sets cheddar preference of menu item
        /// </summary>
        public bool Cheddar
        {
            get => cheddar;
            set
            {
                cheddar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cheddar"));
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
                if (!Broccoli)
                {
                    instructions.Add("Hold broccoli");
        
                }
                if (!Mushrooms)
                {
                    instructions.Add("Hold mushrooms");
        
                }
                if (!Tomato)
                {
                    instructions.Add("Hold tomato");
        
                }
                if (!Cheddar)
                {
                    instructions.Add("Hold cheddar");
        
                }
                return instructions;
            }
        }
        /// <summary>
        /// Gets description for the menu item.
        /// </summary>
        public string Description
        {
            get
            {
                return "Vegetarian. Two egg omelette packed with a mix of broccoli, mushrooms, and tomatoes. Topped with cheddar cheese.";
            }
        }

        /// <summary>
        /// returns name of menu menu item.
        /// </summary>
        /// <returns>A string naming the menu item</returns>
        public override string ToString()
        {
            return "Garden Orc Omelette";
        }
    }
}
