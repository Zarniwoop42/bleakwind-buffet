using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections;

namespace BleakwindBuffet.Data
{
    public class Order : IOrderItem, INotifyPropertyChanged, ICollection<IOrderItem>, INotifyCollectionChanged
    {
        public List<IOrderItem> orderList = new List<IOrderItem>();

        /// <summary>
        /// Events for tracking when property or collection changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private static int nextOrderNumber = 1;

        public Order()
        {
            Number = nextOrderNumber;
            nextOrderNumber++;
        }


        /// <summary>
        /// The number of the order
        /// </summary>
        public int Number { get; }


        /// <summary>
        /// adds item to order list
        /// </summary>
        /// <param name="item">item to add to order</param>
        public void Add(IOrderItem item)
        {
            orderList.Add(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
        }

        /// <summary>
        /// removes item from order list
        /// </summary>
        /// <param name="item">item to remove from order</param>
        bool ICollection<IOrderItem>.Remove(IOrderItem item)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            return ((ICollection<IOrderItem>)orderList).Remove(item);
        }

        /// <summary>
        /// removes item from order list
        /// </summary>
        /// <param name="item">item to remove from order</param>
        public void Remove(IOrderItem item)
        {
            orderList.Remove(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
        }

        public void Clear()
        {
            ((ICollection<IOrderItem>)orderList).Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
        }

        public bool Contains(IOrderItem item)
        {
            return ((ICollection<IOrderItem>)orderList).Contains(item);
        }

        public void CopyTo(IOrderItem[] array, int arrayIndex)
        {
            ((ICollection<IOrderItem>)orderList).CopyTo(array, arrayIndex);
        }


        public IEnumerator<IOrderItem> GetEnumerator()
        {
            return ((IEnumerable<IOrderItem>)orderList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)orderList).GetEnumerator();
        }

        /// <summary>
        /// private backing value for sales tax
        /// </summary>
        private double salesTaxRate = 0.12;

        /// <summary>
        /// sales tax of order
        /// </summary>
        public double SalesTaxRate
        {
            get => salesTaxRate;
            set
            {
                salesTaxRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SalesTaxRate"));
            }
        }

        /// <summary>
        /// private backing price value
        /// </summary>
        private double subtotal = 0;

        /// <summary>
        /// The price of the order
        /// </summary>
        /// <value>In US dollars</value>
        public double Subtotal
        {
            get
            {
                if (orderList == null) return 0;
                subtotal = 0;
                foreach (IOrderItem i in orderList)
                {
                    subtotal += i.Price;
                }
                return Math.Round(subtotal, 2);
            }
        }
        
        /// <summary>
        /// private backing tax value
        /// </summary>
        private double tax = 0;

        /// <summary>
        /// The tax of the order
        /// </summary>
        /// <value>In US dollars</value>
        public double Tax
        {
            get
            {
                if (orderList == null) return 0;
                tax = 0;
                return Math.Round(Subtotal * SalesTaxRate, 2);
            }
        }
        
        /// <summary>
        /// private backing total price value
        /// </summary>
        private double total = 0;

        /// <summary>
        /// The total price of the order
        /// </summary>
        /// <value>In US dollars</value>
        public double Total
        {
            get
            {
                total = 0;
               
                return Math.Round(Subtotal + Tax, 2);
            }
        }

        public double Price { get; set; }


        /// <summary>
        /// private backing calories value
        /// </summary>
        private uint calories = 0;

        /// <summary>
        /// The calories of the drink
        /// </summary>
        public uint Calories
        {
            get
            {
                foreach (IOrderItem i in orderList)
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
        public List<string> SpecialInstructions
        {
            get
            {
                foreach (IOrderItem i in orderList)
                {
                    foreach (string s in i.SpecialInstructions)
                    {
                        specialInstructions.Add(s);
                    }
                }
                return specialInstructions;
            }

        }

        public int Count => ((ICollection<IOrderItem>)orderList).Count;

        public bool IsReadOnly => ((ICollection<IOrderItem>)orderList).IsReadOnly;
    }
}
