///Author: Graham Mathews
///MenuScreen.xaml.cs
///Defines a menu screen where items are displayed to be selected and customized
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Menu = BleakwindBuffet.Data.Menu;
using RoundRegister;


namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuScreen.xaml
    /// </summary>
    public partial class MenuScreen : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// private variables
        /// </summary>
        private Menu menu = new Menu();
        private IEnumerable<IOrderItem> entrees = Menu.Entrees();
        private IEnumerable<IOrderItem> sides = Menu.Sides();
        private IEnumerable<IOrderItem> drinks = Menu.Drinks();
        private List<IOrderItem> ordered = new List<IOrderItem>();
        private int menuNum = 1;
        private IOrderItem menuitem;
        private int itemNum = 1;
        private Order CurrentOrder;

        private List<IOrderItem> comboList = new List<IOrderItem>();
        private bool WIPcombo = false;
        private Combo combo;
        private int numCombos = 0;
/*
        /// <summary>
        /// Identifies the current order total
        /// </summary>
        public static DependencyProperty TotalProperty = DependencyProperty.Register("Total", typeof(double), typeof(TextBlock), new PropertyMetadata(0));
        /// <summary>
        /// current total based on TotalProperty
        /// </summary>
        public double Total
        {
            get { return (double)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }*/

        /// <summary>
        /// Identifies the Total XAML attached property
        /// </summary>
        public static DependencyProperty TotalValueProperty = DependencyProperty.Register("Total", typeof(double), typeof(TextBlock), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// The Total value
        /// </summary>
        public double Total
        {
            get { return CurrentOrder.Total; }
            set { SetValue(TotalValueProperty, value); }
        }

        /// <summary>
        /// Event for tracking when property changes
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        private string size = "Small";
        private string flavor = "Blackberry";

        public MenuScreen()
        {
            InitializeComponent();
            AddMenuItemToColumn();
            DataContext = new Order();
            CurrentOrder = (Order)DataContext;
        }

        /// <summary>
        /// Creates item selection menus for each Menu.cs method
        /// </summary>
        private void AddMenuItemToColumn()
        {
            foreach(IOrderItem entree in entrees)
            {
                CreateButton(menuNum + ") " + entree.ToString(), "entree");
                menuNum++;
            }
            foreach (IOrderItem side in sides)
            {
                string name = side.ToString();
                if (name.Contains("Small")){
                    name = name.Remove(0,5);
                    CreateButton(menuNum + ") " + name, "side");
                    menuNum++;
                }
            }
            foreach(IOrderItem drink in drinks)
            {
                string name = drink.ToString();
                Button item = new Button();

                if (!name.Contains("Small")) continue;

                name = name.Remove(0, 5);

                if (name.Contains("Sailor Soda")) { 
                    if (name.Contains("Blackberry"))
                    {
                        name = name.Replace("Blackberry", "");

                        CreateButton(menuNum + ") " + name, "drink");
                        menuNum++;
                    }
                }
                else
                {
                    CreateButton(menuNum + ") " + name, "drink");
                    menuNum++;
                }
            }
        }

        /// <summary>
        /// Creates a button with provided name for provided column
        /// </summary>
        /// <param name="name">Menu item name for button</param>
        /// <param name="column">Entree, Side, or Drink</param>
        private void CreateButton(string name, string column)
        {
            Button item = new Button();
            item.Content = name; item.Click += Selection;


            if (column == "entree") {
                item.Name = "ENTREE_" + name.Replace(" ", "").Replace("-", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("0", "").Replace(")", "");
                EntreesColumn.Children.Add(item); 
            }
            if (column == "side")
            {
                item.Name = "SIDE_" + name.Replace(" ", "").Replace("-", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("0", "").Replace(")", "");
                SidesColumn.Children.Add(item);
            }
            if (column == "drink")
            {
                item.Name = "DRINK_" + name.Replace(" ", "").Replace("-", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("0", "").Replace(")", "");
                DrinksColumn.Children.Add(item);
            }
        }

        /// <summary>
        /// Button click event for any menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void Selection(object sender, RoutedEventArgs e)
        {
            string name = (sender as Button).Name; string numText = (sender as Button).Content.ToString();
            string text = numText.Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("0", "").Replace(")", "").Trim();
            numText = numText.Split(')')[0];
            switch (Convert.ToInt32(numText))
            {
                case 1: menuitem = new BriarheartBurger(); break;
                case 2: menuitem = new DoubleDraugr(); break;
                case 3: menuitem = new GardenOrcOmelette(); break;
                case 4: menuitem = new PhillyPoacher(); break;
                case 5: menuitem = new SmokehouseSkeleton(); break;
                case 6: menuitem = new ThalmorTriple(); break;
                case 7: menuitem = new ThugsTBone(); break;
                case 8: menuitem = new DragonbornWaffleFries(); break;
                case 9: menuitem = new FriedMiraak(); break;
                case 10: menuitem = new MadOtarGrits(); break;
                case 11: menuitem = new VokunSalad(); break;
                case 12: menuitem = new AretinoAppleJuice(); break;
                case 13: menuitem = new CandlehearthCoffee(); break;
                case 14: menuitem = new MarkarthMilk(); break;
                case 15: menuitem = new SailorSoda(); break;
                case 16: menuitem = new WarriorWater(); break;
            }

            bool pass = false;

            if (WIPcombo)
            {
                if (name.Contains("SIDE"))
                {
                    for(int i = 0; i < comboList.Count; i++)
                    {
                        if(comboList[i].GetType().ToString().Contains("Side"))
                        {
                            pass = true;
                        }
                    }
                }
                if (name.Contains("DRINK"))
                {
                    for (int i = 0; i < comboList.Count; i++)
                    {
                        if (comboList[i].GetType().ToString().Contains("Drink"))
                        {
                            pass = true;
                        }
                    }
                }
                if (name.Contains("ENTREE"))
                {
                    for (int i = 0; i < comboList.Count; i++)
                    {
                        if (comboList[i].GetType().ToString().Contains("Entree"))
                        {
                            pass = true;
                        }
                    }
                }
            }
            if (!pass)
            {
                StackPanel selectOption = new StackPanel();
                TextBlock n = new TextBlock(); n.Text = text; n.FontSize = 40; n.FontWeight = FontWeights.Bold; selectOption.Children.Add(n);

                MenuGrid.Visibility = Visibility.Collapsed;

                DataContext = menuitem;

                if (name.Contains("SIDE") || name.Contains("DRINK"))
                {
                    TextBlock sizeBox = new TextBlock(); sizeBox.Text = "Select Size"; sizeBox.FontSize = 30; sizeBox.FontWeight = FontWeights.Bold;
                    selectOption.Children.Add(sizeBox);
                    RadioButton small = new RadioButton(); small.Content = "Small"; small.IsChecked = true; small.GroupName = "SIZE"; small.Click += RadioChecked;
                    RadioButton med = new RadioButton(); med.Content = "Medium"; med.GroupName = "SIZE"; med.Click += RadioChecked;
                    RadioButton large = new RadioButton(); large.Content = "Large"; large.GroupName = "SIZE"; large.Click += RadioChecked;
                    selectOption.Children.Add(small);
                    selectOption.Children.Add(med);
                    selectOption.Children.Add(large);

                    if ((sender as Button).Content.ToString().Contains("Sailor Soda"))
                    {
                        TextBlock flavBox = new TextBlock(); flavBox.Text = "Select Flavor"; flavBox.FontSize = 30; flavBox.FontWeight = FontWeights.Bold;
                        selectOption.Children.Add(flavBox);

                        foreach (SodaFlavor flavor in Enum.GetValues(typeof(SodaFlavor)))
                        {
                            RadioButton f = new RadioButton();
                            if (flavor == SodaFlavor.Blackberry) f.IsChecked = true;
                            f.Content = flavor.ToString(); f.GroupName = "FLAVOR"; f.Click += RadioChecked;
                            selectOption.Children.Add(f);
                        }
                    }
                }

                if (!name.Contains("SIDE") && !text.Contains("Thugs"))
                {
                    TextBlock otherBox = new TextBlock(); otherBox.Text = "Other Customization"; otherBox.FontSize = 30; otherBox.FontWeight = FontWeights.Bold;
                    selectOption.Children.Add(otherBox);
                }

                if (name.Contains("DRINK"))
                {
                    if (text.Contains("Aretino Apple Juice") || text.Contains("Markarth Milk") || text.Contains("Sailor Soda"))
                    {
                        CheckBox ice = new CheckBox(); ice.Content = "Ice"; ice.SetBinding(CheckBox.IsCheckedProperty, "Ice");
                        selectOption.Children.Add(ice);
                    }
                    else if (text.Contains("Candlehearth Coffee"))
                    {
                        CheckBox ice = new CheckBox(); ice.Content = "Ice"; ice.SetBinding(CheckBox.IsCheckedProperty, "Ice");
                        CheckBox cream = new CheckBox(); cream.Content = "Cream"; cream.SetBinding(CheckBox.IsCheckedProperty, "RoomForCream");
                        CheckBox decaf = new CheckBox(); decaf.Content = "Decaf"; decaf.SetBinding(CheckBox.IsCheckedProperty, "Decaf");
                        selectOption.Children.Add(ice);
                        selectOption.Children.Add(cream);
                        selectOption.Children.Add(decaf);
                    }
                    else if (text.Contains("Warrior Water"))
                    {
                        CheckBox ice = new CheckBox(); ice.Content = "Ice"; ice.IsChecked = true; ice.SetBinding(CheckBox.IsCheckedProperty, "Ice");
                        CheckBox lemon = new CheckBox(); lemon.Content = "Lemon"; lemon.SetBinding(CheckBox.IsCheckedProperty, "Lemon");
                        selectOption.Children.Add(ice);
                        selectOption.Children.Add(lemon);
                    }
                }

                if (name.Contains("ENTREE"))
                {
                    if (text.Contains("Briarheart Burger") || text.Contains("Double Draugr") || text.Contains("Thalmor Triple"))
                    {
                        CheckBox bun = new CheckBox(); bun.Content = "Bun"; bun.IsChecked = true; bun.SetBinding(CheckBox.IsCheckedProperty, "Bun");
                        CheckBox ketchup = new CheckBox(); ketchup.Content = "Ketchup"; ketchup.IsChecked = true; ketchup.SetBinding(CheckBox.IsCheckedProperty, "Ketchup");
                        CheckBox mustard = new CheckBox(); mustard.Content = "Mustard"; mustard.IsChecked = true; mustard.SetBinding(CheckBox.IsCheckedProperty, "Mustard");
                        CheckBox pickle = new CheckBox(); pickle.Content = "Pickle"; pickle.IsChecked = true; pickle.SetBinding(CheckBox.IsCheckedProperty, "Pickle");
                        CheckBox cheese = new CheckBox(); cheese.Content = "Cheese"; cheese.IsChecked = true; cheese.SetBinding(CheckBox.IsCheckedProperty, "Cheese");
                        selectOption.Children.Add(bun);
                        selectOption.Children.Add(ketchup);
                        selectOption.Children.Add(mustard);
                        selectOption.Children.Add(pickle);
                        selectOption.Children.Add(cheese);
                    }
                    if (text.Contains("Double Draugr") || text.Contains("Thalmor Triple"))
                    {
                        CheckBox tomato = new CheckBox(); tomato.Content = "Tomato"; tomato.IsChecked = true; tomato.SetBinding(CheckBox.IsCheckedProperty, "Tomato");
                        CheckBox lettuce = new CheckBox(); lettuce.Content = "Lettuce"; lettuce.IsChecked = true; lettuce.SetBinding(CheckBox.IsCheckedProperty, "Lettuce");
                        CheckBox mayo = new CheckBox(); mayo.Content = "Mayo"; mayo.IsChecked = true; mayo.SetBinding(CheckBox.IsCheckedProperty, "Mayo");
                        selectOption.Children.Add(tomato);
                        selectOption.Children.Add(lettuce);
                        selectOption.Children.Add(mayo);
                    }
                    if (text.Contains("Thalmor Triple"))
                    {
                        CheckBox bacon = new CheckBox(); bacon.Content = "Bacon"; bacon.IsChecked = true; bacon.SetBinding(CheckBox.IsCheckedProperty, "Bacon");
                        CheckBox egg = new CheckBox(); egg.Content = "Egg"; egg.IsChecked = true; egg.SetBinding(CheckBox.IsCheckedProperty, "Egg");
                        selectOption.Children.Add(bacon);
                        selectOption.Children.Add(egg);
                    }
                    else if (text.Contains("Garden Orc Omelette"))
                    {
                        CheckBox broccoli = new CheckBox(); broccoli.Content = "Broccoli"; broccoli.IsChecked = true; broccoli.SetBinding(CheckBox.IsCheckedProperty, "Broccoli");
                        CheckBox mushrooms = new CheckBox(); mushrooms.Content = "Mushrooms"; mushrooms.IsChecked = true; mushrooms.SetBinding(CheckBox.IsCheckedProperty, "Mushrooms");
                        CheckBox tomato = new CheckBox(); tomato.Content = "Tomato"; tomato.IsChecked = true; tomato.SetBinding(CheckBox.IsCheckedProperty, "Tomato");
                        CheckBox cheddar = new CheckBox(); cheddar.Content = "Cheddar"; cheddar.IsChecked = true; cheddar.SetBinding(CheckBox.IsCheckedProperty, "Cheddar");
                        selectOption.Children.Add(broccoli);
                        selectOption.Children.Add(mushrooms);
                        selectOption.Children.Add(tomato);
                        selectOption.Children.Add(cheddar);
                    }
                    else if (text.Contains("Philly Poacher"))
                    {
                        CheckBox sirloin = new CheckBox(); sirloin.Content = "Sirloin"; sirloin.IsChecked = true; sirloin.SetBinding(CheckBox.IsCheckedProperty, "Sirloin");
                        CheckBox onion = new CheckBox(); onion.Content = "Onion"; onion.IsChecked = true; onion.SetBinding(CheckBox.IsCheckedProperty, "Onion");
                        CheckBox roll = new CheckBox(); roll.Content = "Roll"; roll.IsChecked = true; roll.SetBinding(CheckBox.IsCheckedProperty, "Roll");
                        selectOption.Children.Add(sirloin);
                        selectOption.Children.Add(onion);
                        selectOption.Children.Add(roll);
                    }
                    else if (text.Contains("Smokehouse Skeleton"))
                    {
                        CheckBox sausage = new CheckBox(); sausage.Content = "Sausage"; sausage.IsChecked = true; sausage.SetBinding(CheckBox.IsCheckedProperty, "SausageLink");
                        CheckBox egg = new CheckBox(); egg.Content = "Egg"; egg.IsChecked = true; egg.SetBinding(CheckBox.IsCheckedProperty, "Egg");
                        CheckBox hashbrowns = new CheckBox(); hashbrowns.Content = "Hashbrowns"; hashbrowns.IsChecked = true; hashbrowns.SetBinding(CheckBox.IsCheckedProperty, "HashBrowns");
                        CheckBox pancake = new CheckBox(); pancake.Content = "Pancake"; pancake.IsChecked = true; pancake.SetBinding(CheckBox.IsCheckedProperty, "Pancake");
                        selectOption.Children.Add(sausage);
                        selectOption.Children.Add(egg);
                        selectOption.Children.Add(hashbrowns);
                        selectOption.Children.Add(pancake);
                    }
                }


                StackPanel selectGrid = new StackPanel();
                ToggleGrid.Children.Add(selectGrid);

                selectGrid.Children.Add(selectOption);
                Button OK = new Button(); OK.Content = "Add to Order"; OK.Height = 40; OK.Click += OKSelection; OK.VerticalAlignment = VerticalAlignment.Bottom;
                selectGrid.Children.Add(OK);
            }
        }

        /// <summary>
        /// Click event for Size/Flavor radiobuttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioChecked(object sender, RoutedEventArgs e)
        {
            string group = (sender as RadioButton).GroupName.ToString();
            if (group == "SIZE") size = (sender as RadioButton).Content.ToString();
            if (group == "FLAVOR") flavor = (sender as RadioButton).Content.ToString();


            int s = 0;
            switch (size)
            {
                case "Small": s=0; break;
                case "Medium": s=1; break;
                case "Large": s=2; break;
            }
            if(menuitem is Drink)
                ((Drink)menuitem).Size = (BleakwindBuffet.Data.Enums.Size)s;
            else if(menuitem is Side)
                ((Side)menuitem).Size = (BleakwindBuffet.Data.Enums.Size)s;

            if (menuitem is SailorSoda)
            {
                int f = 0;
                switch (flavor)
                {
                    case "Blackberry": f = 0; break;
                    case "Cherry": f = 1; break;
                    case "Grapefruit": f = 2; break;
                    case "Lemon": f = 3; break;
                    case "Peach": f = 4; break;
                    case "Watermelon": f = 5; break;
                }

                ((SailorSoda)menuitem).Flavor = (SodaFlavor)f;
            }
        }

        /// <summary>
        /// Click event for confirming customization button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKSelection(object sender, RoutedEventArgs e)
        {
            ordered.Add(menuitem);
            CurrentOrder.Add(menuitem);
            if (WIPcombo)
            {
                comboList.Add(menuitem);
            }
            ListView orderI = new ListView();
            
            TextBlock item = new TextBlock();
            item.Text = menuitem.ToString(); item.FontWeight = FontWeights.Bold; item.FontSize = 20;
            orderI.Items.Add(item);

            item = new TextBlock();
            item.Text = "$"+menuitem.Price.ToString(); item.FontSize = 14;
            orderI.Items.Add(item);

            ListView orderISI = new ListView();

            if (menuitem.SpecialInstructions.Count > 0)
            {
                foreach (string si in menuitem.SpecialInstructions)
                {
                    if(si.Length > 0)
                    {
                        item = new TextBlock();
                        item.Text = si; item.FontWeight = FontWeights.Thin; item.FontSize = 12;
                        orderISI.Items.Add(item);
                    }
                }
            }

            orderI.Items.Add(orderISI);

             Button removeItem = new Button(); removeItem.Content = "Remove Item " + itemNum; removeItem.Click += removeClick;


            if (WIPcombo) { removeItem.Content = "(Combo Item)"; removeItem.IsEnabled = false; }
            orderI.Items.Add(removeItem); 

            Pricing.Children.Clear();
            TextBlock sub = new TextBlock(); sub.Text = "$" + CurrentOrder.Subtotal.ToString(); sub.FontWeight = FontWeights.Bold;
            Pricing.Children.Add(sub);
            sub = new TextBlock(); sub.Text = "$" + CurrentOrder.Tax.ToString(); sub.FontWeight = FontWeights.Bold;
            Pricing.Children.Add(sub);
            sub = new TextBlock(); sub.Text = "$" + CurrentOrder.Total.ToString(); sub.FontWeight = FontWeights.Bold;
            Pricing.Children.Add(sub);

            Selected.Children.Add(orderI);

            size = "Blackberry";
            flavor = "Small";

            PropertyChanged?.Invoke(menuitem, new PropertyChangedEventArgs("SpecialInstructions"));

            ToggleGrid.Children.Remove(this.ToggleGrid.Children[1]);
            ToggleGrid.Children[0].Visibility = Visibility.Visible;
            itemNum++;
            if (comboList.Count > 2)
                AddCombo();
        }
        /// <summary>
        /// adds complete combo to order screen
        /// </summary>
        private void AddCombo()
        {
            combo = new Combo(comboList[0], comboList[1], comboList[2]);
            WIPcombo = false;
            ((Button)MenuGrid.Children[6]).IsEnabled = true;
            ((Button)MenuGrid.Children[6]).Content = "Create Combo";
            comboList.Clear();
            TextBlock comboBlock = new TextBlock(); comboBlock.Text = "COMBO (Previous 3 Items) ($1 Discount)";

            Selected.Children.Add(comboBlock);

            itemNum++;
            numCombos++;
        }

        /// <summary>
        /// Click event for cancel order button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelOrder(object sender, RoutedEventArgs e)
        {
            reset();
        }
        
        /// <summary>
        /// Click event for combo button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCombo(object sender, RoutedEventArgs e)
        {
            WIPcombo = true;
            ((Button)MenuGrid.Children[6]).IsEnabled = false;
            ((Button)MenuGrid.Children[6]).Content = "Creating Combo";
        }
        
        /// <summary>
        /// Click event for return to order button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnToOrder(object sender, RoutedEventArgs e)
        {
            ToggleGrid.Children[1].Visibility = Visibility.Collapsed;
            ToggleGrid.Children.Remove(ToggleGrid.Children[1]);
            ToggleGrid.Children[0].Visibility = Visibility.Visible;

            for (int b = 0; b < OrderGrid.Children.Count; b++)
            {
                if (OrderGrid.Children[b] is Button)
                {
                    if (((Button)OrderGrid.Children[b]).Name == "Complete")
                    {
                        ((Button)OrderGrid.Children[b]).Content = "Complete Order";
                        ((Button)OrderGrid.Children[b]).Click -= ReturnToOrder;
                        ((Button)OrderGrid.Children[b]).Click += CompleteOrder;
                    }
                }
            }

        }

        /// <summary>
        /// Click event for cancel order button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteOrder(object sender, RoutedEventArgs e)
        {

            MenuGrid.Visibility = Visibility.Collapsed;

            Grid selectOption = new Grid(); selectOption.ColumnDefinitions.Add(new ColumnDefinition()); selectOption.ColumnDefinitions.Add(new ColumnDefinition()); selectOption.ColumnDefinitions.Add(new ColumnDefinition());
            Button n = new Button(); n.Click += Cash; n.HorizontalAlignment = HorizontalAlignment.Stretch; n.VerticalAlignment = VerticalAlignment.Stretch; n.Content = "CASH"; n.FontSize = 40; n.FontWeight = FontWeights.Bold; selectOption.Children.Add(n); 
            n = new Button(); n.Click += CreditDebit; n.HorizontalAlignment = HorizontalAlignment.Stretch; n.VerticalAlignment = VerticalAlignment.Stretch; n.Content = "CREDIT/DEBIT"; n.FontSize = 40; n.FontWeight = FontWeights.Bold; selectOption.Children.Add(n); Grid.SetColumn(n, 1); Grid.SetColumnSpan(n, 2);

            ToggleGrid.Children.Add(selectOption);

            for (int b = 0; b < OrderGrid.Children.Count; b++)
            {
                if (OrderGrid.Children[b] is Button)
                {
                    if(((Button)OrderGrid.Children[b]).Name == "Complete")
                    {
                        ((Button)OrderGrid.Children[b]).Content = "Return to Order";
                        ((Button)OrderGrid.Children[b]).Click -= CompleteOrder;
                        ((Button)OrderGrid.Children[b]).Click += ReturnToOrder;
                    }
                }
            }
        }

        /// <summary>
        /// Click event for cash button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cash(object sender, RoutedEventArgs e)
        {
            DataContext = new CashDrawerUpdate();

            MenuGrid.Visibility = Visibility.Collapsed;
            ToggleGrid.Children[1].Visibility = Visibility.Collapsed;
            ToggleGrid.Children.Remove(ToggleGrid.Children[1]);
            Drawer drawer = new Drawer();
            ToggleGrid.Children.Add(drawer);

            PrintReciept("Cash");
            reset();
        }

        /// <summary>
        /// Click event for credit/debit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreditDebit(object sender, RoutedEventArgs e)
        {
            if(CardReader.RunCard(CurrentOrder.Total) == CardTransactionResult.Approved)
            {
                PrintReciept("Card");
            }
        }
        
        private void PrintReciept(string paymenttype)
        {
            RecieptPrinter.PrintLine("Order Number: " + orderNumber);
            RecieptPrinter.PrintLine(DateTime.Now.ToString());
            RecieptPrinter.PrintLine("Items Ordered:");
            foreach (IOrderItem item in CurrentOrder.orderList)
            {
                RecieptPrinter.PrintLine(item.ToString());
                foreach(string SI in item.SpecialInstructions)
                {
                    string SIcut = SI;
                    if (SI.Length > 40) SIcut = SI.Substring(0, 40);
                    RecieptPrinter.PrintLine("> " + SIcut);
                }
            }
            RecieptPrinter.PrintLine("Subtotal: " + CurrentOrder.Subtotal);
            RecieptPrinter.PrintLine("Tax: " + CurrentOrder.Tax);
            RecieptPrinter.PrintLine("Total: " + (CurrentOrder.Total - numCombos));
            RecieptPrinter.PrintLine("Payment Method: " + paymenttype);
            if(paymenttype == "Cash")
            {
                RecieptPrinter.PrintLine("Change Owed: " );
            }

            RecieptPrinter.CutTape();
        }

        private void reset()
        {
            ordered = new List<IOrderItem>();
            Selected.Children.Clear();
            Pricing.Children.Clear();
            DataContext = new Order();
            CurrentOrder = (Order)DataContext;
            orderNumber.Text = "Order #" + CurrentOrder.Number;
            itemNum = 1;
            numCombos = 0;
            comboList.Clear();
            WIPcombo = false;
            ((Button)MenuGrid.Children[6]).IsEnabled = true;
            ((Button)MenuGrid.Children[6]).Content = "Create Combo";
        }

        /// <summary>
        /// Click event for remove item button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeClick(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Content.ToString();

            int itemToRemove = Convert.ToInt32(Regex.Match(name, @"\d+$").Value);

            int indexToRemove = 0;

            for (int LV = 0; LV < Selected.Children.Count; LV++) //Find order item that must be removed based on number in button name. Yeah I overcomplicated this.
            {
                if (Selected.Children[LV] is ListView)
                {
                    for (int element = 0; element < ((ListView)Selected.Children[LV]).Items.Count; element++)
                    {
                        if (((ListView)Selected.Children[LV]).Items[element] is Button)
                        {
                            string b = ((Button)((ListView)Selected.Children[LV]).Items[element]).Content.ToString();
                            if (itemToRemove == Convert.ToInt32(Regex.Match(b, @"\d+$").Value))
                            {
                                Selected.Children.Remove(Selected.Children[indexToRemove]);
                                break;
                            }
                        }
                    }
                    indexToRemove++;
                }
            }
            itemNum--; menuitem = CurrentOrder.orderList[indexToRemove - 1];

            CurrentOrder.Remove(CurrentOrder.orderList[indexToRemove - 1]);
            Pricing.Children.Clear();
            TextBlock sub = new TextBlock(); sub.Text = "$" + CurrentOrder.Subtotal.ToString(); sub.FontWeight = FontWeights.Bold;
            Pricing.Children.Add(sub);
            sub = new TextBlock(); sub.Text = "$" + CurrentOrder.Tax.ToString(); sub.FontWeight = FontWeights.Bold;
            Pricing.Children.Add(sub);
            sub = new TextBlock(); sub.Name = "TOTAL"; sub.Text = "$" + (CurrentOrder.Total - numCombos).ToString(); sub.FontWeight = FontWeights.Bold;
            Pricing.Children.Add(sub);
        }

        /// <summary>
        /// Click event for New Order button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewOrder(object sender, RoutedEventArgs e)
        {
            reset();
        }
    }
}
