using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for Drawer.xaml
    /// </summary>
    public partial class Drawer : UserControl
    {
        /// <summary>
        /// private backing variables 
        /// </summary>
        private double AmountGiven = 0;
        private double AmountOwed;

        public Drawer()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Click event for plus button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBill(object sender, RoutedEventArgs e)
        {
            int nameInd = 0;
            switch (((Button)sender).Name.ToString().Replace("_Plus", ""))
            {
                case ("One"): nameInd = 1; break;
                case ("Two"): nameInd = 2; break;
                case ("Three"): nameInd = 3; break;
                case ("Four"): nameInd = 4; break;
                case ("Five"): nameInd = 5; break;
                case ("Six"): nameInd = 6; break;
                case ("Seven"): nameInd = 7; break;
                case ("Eight"): nameInd = 8; break;
                case ("Nine"): nameInd = 9; break;
                case ("Ten"): nameInd = 10; break;
                case ("Eleven"): nameInd = 11; break;
                case ("Twelve"): nameInd = 12; break;
                case ("Thirteen"): nameInd = 13; break;
            }

            int num = Convert.ToInt32(((TextBlock)Primary.Children[44 + nameInd]).Text) + 1;
            if (num < 0) num = 0;
            ((TextBlock)Primary.Children[44 + nameInd]).Text = num.ToString();
            update();
        }
        /// <summary>
        /// Click event for Minus button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveBill(object sender, RoutedEventArgs e)
        {
            int nameInd = 0;
            switch (((Button)sender).Name.ToString().Replace("_Minus", ""))
            {
                case ("One"): nameInd = 1; break;
                case ("Two"): nameInd = 2; break;
                case ("Three"): nameInd = 3; break;
                case ("Four"): nameInd = 4; break;
                case ("Five"): nameInd = 5; break;
                case ("Six"): nameInd = 6; break;
                case ("Seven"): nameInd = 7; break;
                case ("Eight"): nameInd = 8; break;
                case ("Nine"): nameInd = 9; break;
                case ("Ten"): nameInd = 10; break;
                case ("Eleven"): nameInd = 11; break;
                case ("Twelve"): nameInd = 12; break;
                case ("Thirteen"): nameInd = 13; break;
            }

            int num = Convert.ToInt32(((TextBlock)Primary.Children[44 + nameInd]).Text) - 1;
            if (num < 0) num = 0;
            ((TextBlock)Primary.Children[44 + nameInd]).Text = num.ToString();
            update();
        }
        /// <summary>
        /// update buttons
        /// </summary>
        private void update()
        {

            for (int i = 44; i < 44 + 13; i++)
            {
                int nameInd = 0;
              int num = Convert.ToInt32(((TextBlock)Primary.Children[i]).Text);
                if (num > 0)
                {
                    switch (((TextBlock)Primary.Children[i]).Name.ToString().Replace("_From", ""))
                    {
                        case ("One"): nameInd = 1; break;
                        case ("Two"): nameInd = 2; break;
                        case ("Three"): nameInd = 3; break;
                        case ("Four"): nameInd = 4; break;
                        case ("Five"): nameInd = 5; break;
                        case ("Six"): nameInd = 6; break;
                        case ("Seven"): nameInd = 7; break;
                        case ("Eight"): nameInd = 8; break;
                        case ("Nine"): nameInd = 9; break;
                        case ("Ten"): nameInd = 10; break;
                        case ("Eleven"): nameInd = 11; break;
                        case ("Twelve"): nameInd = 12; break;
                        case ("Thirteen"): nameInd = 13; break;
                    }
                }
            }
        }

        /// <summary>
        /// Click event for Finalize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinalizeClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
