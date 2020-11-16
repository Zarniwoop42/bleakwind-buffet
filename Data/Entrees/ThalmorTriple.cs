///Author: Graham Mathews
///ThalmorTriple.cs
///Define TT
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace BleakwindBuffet.Data.Entrees
{
    public class ThalmorTriple : Entree, IOrderItem, INotifyPropertyChanged
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
        private bool tomato = true;
        private bool lettuce = true;
        private bool mayo = true;
        private bool bacon = true;
        private bool egg = true;


        /// <summary>
        /// Gets price of menu item
        /// </summary>
        public override double Price => 8.32;

        /// <summary>
        /// Gets calories of menu item
        /// </summary>
        public override uint Calories => 943;
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
        /// Gets/sets lettuce preference of menu item
        /// </summary>
        public bool Lettuce
        {
            get => lettuce;
            set
            {
                lettuce = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lettuce"));
            }
        }

        /// <summary>
        /// Gets/sets mayo preference of menu item
        /// </summary>
        public bool Mayo
        {
            get => mayo;
            set
            {
                mayo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mayo"));
            }
        }


        /// <summary>
        /// Gets/sets bacon preference of menu item
        /// </summary>
        public bool Bacon
        {
            get => bacon;
            set
            {
                bacon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bacon"));
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
                if (!Pickle)
                {
                    instructions.Add("Hold pickle");
        
                }
                if (!Cheese)
                {
                    instructions.Add("Hold cheese");
        
                }
                if (!Tomato)
                {
                    instructions.Add("Hold tomato");
        
                }
                if (!Lettuce)
                {
                    instructions.Add("Hold lettuce");
        
                }
                if (!Mayo)
                {
                    instructions.Add("Hold mayo");
        
                }
                if (!Bacon)
                {
                    instructions.Add("Hold bacon");
        
                }
                if (!Egg)
                {
                    instructions.Add("Hold egg");
        
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
                return "Think you are strong enough to take on the Thalmor? Inlcudes two 1/4lb patties with a 1/2lb patty inbetween with ketchup, mustard, pickle, cheese, tomato, lettuce, mayo, bacon, and an egg.";
            }
        }

        /// <summary>
        /// returns name of menu item.
        /// </summary>
        /// <returns>A string naming the menu item</returns>
        public override string ToString()
        {
            return "Thalmor Triple";
        }
    }
}
