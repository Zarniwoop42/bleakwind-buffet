using System;
using System.Collections.Generic;
using System.Text;
using RoundRegister;
using System.ComponentModel;
using System.Windows.Automation;

namespace PointOfSale
{
    public class CashDrawerUpdate : INotifyPropertyChanged
    {
        /// <summary>
        /// Event for tracking when property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public int Pennies { get { return CashDrawer.Pennies; } }
        public int Nickels { get { return CashDrawer.Nickels; } }
        public int Dimes { get { return CashDrawer.Dimes; } }
        public int Quarters { get { return CashDrawer.Quarters; } }
        public int Dollars { get { return CashDrawer.Dollars; } }
        public int HalfDollars { get { return CashDrawer.HalfDollars; } }
        public int Ones { get { return CashDrawer.Ones; } }
        public int Twos { get { return CashDrawer.Twos; } }
        public int Fives { get { return CashDrawer.Fives; } }
        public int Tens { get { return CashDrawer.Tens; } }
        public int Twenties { get { return CashDrawer.Twenties; } }
        public int Fifties { get { return CashDrawer.Fifties; } }
        public int Hundreds { get { return CashDrawer.Hundreds; } }
        public double Total { get { return CashDrawer.Total; } }

        /// <summary>
        /// private backing customer given coins
        /// </summary>
        private int cPennies = 0;
        private int cNickels = 0;
        private int cDimes = 0;
        private int cQuarters = 0;
        private int cDollars = 0;
        private int cHalfDollars = 0;
        private int cOnes = 0;
        private int cTwos = 0;
        private int cFives = 0;
        private int cTens = 0;
        private int cTwenties = 0;
        private int cFifties = 0;
        private int cHundreds = 0;

        //Given by customer
        public int CPennies
        {
            get => cPennies;
            set
            {
                cPennies = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CPennies"));
            }
        }
        public int CNickels
        {
            get => cNickels;
            set
            {
                cNickels = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CNickels"));
            }
        }
        public int CDimes
        {
            get => cDimes;
            set
            {
                cDimes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CDimes"));
            }
        }
        public int CQuarters
        {
            get => cQuarters;
            set
            {
                cQuarters = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CQuarters"));
            }
        }
        public int CDollars
        {
            get => cDollars;
            set
            {
                cDollars = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CDollars"));
            }
        }
        public int CHalfDollars
        {
            get => cHalfDollars;
            set
            {
                cHalfDollars = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CHalfDollars"));
            }
        }
        public int COnes
        {
            get => cOnes;
            set
            {
                cOnes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("COnes"));
            }
        }
        public int CTwos
        {
            get => cTwos;
            set
            {
                cTwos = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CTwos"));
            }
        }
        public int CFives
        {
            get => cFives;
            set
            {
                cFives = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CFives"));
            }
        }
        public int CTens
        {
            get => cTens;
            set
            {
                cTens = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CTens"));
            }
        }
        public int CTwenties
        {
            get => cTwenties;
            set
            {
                cTwenties = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CTwenties"));
            }
        }
        public int CFifties
        {
            get => cFifties;
            set
            {
                cFifties = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CFifties"));
            }
        }
        public int CHundreds
        {
            get => cHundreds;
            set
            {
                cHundreds = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CHundreds"));
            }
        }

        /// <summary>
        /// private backing ghange to give
        /// </summary>
        private int gPennies;
        private int gNickels = 0;
        private int gDimes = 0;
        private int gQuarters = 0;
        private int gDollars = 0;
        private int gHalfDollars = 0;
        private int gOnes = 0;
        private int gTwos = 0;
        private int gFives = 0;
        private int gTens = 0;
        private int gTwenties = 0;
        private int gFifties = 0;
        private int gHundreds = 0;

        //Change to give
        public int GPennies
        {
            get => gPennies;
            set
            {
                gPennies = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GPennies"));
            }
        }
        public int GNickels
        {
            get => gNickels;
            set
            {
                gNickels = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GNickels"));
            }
        }
        public int GDimes
        {
            get => gDimes;
            set
            {
                gDimes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GDimes"));
            }
        }
        public int GQuarters
        {
            get => gQuarters;
            set
            {
                gQuarters = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GQuarters"));
            }
        }
        public int GDollars
        {
            get => gDollars;
            set
            {
                gDollars = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GDollars"));
            }
        }
        public int GHalfDollars
        {
            get => gHalfDollars;
            set
            {
                gHalfDollars = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GHalfDollars"));
            }
        }
        public int GOnes
        {
            get => gOnes;
            set
            {
                gOnes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GOnes"));
            }
        }
        public int GTwos
        {
            get => gTwos;
            set
            {
                gTwos = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GTwos"));
            }
        }
        public int GFives
        {
            get => gFives;
            set
            {
                gFives = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GFives"));
            }
        }
        public int GTens
        {
            get => gTens;
            set
            {
                gTens = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GTens"));
            }
        }
        public int GTwenties
        {
            get => gTwenties;
            set
            {
                gTwenties = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GTwenties"));
            }
        }
        public int GFifties
        {
            get => gFifties;
            set
            {
                gFifties = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GFifties"));
            }
        }
        public int GHundreds
        {
            get => gHundreds;
            set
            {
                gHundreds = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GHundreds"));
            }
        }
    }
}
