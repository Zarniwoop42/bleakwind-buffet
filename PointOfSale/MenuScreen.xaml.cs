using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Menu = BleakwindBuffet.Data.Menu;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuScreen.xaml
    /// </summary>
    public partial class MenuScreen : UserControl
    {
        /// <summary>
        /// private variables
        /// </summary>
        private Menu menu = new Menu();
        private IEnumerable<IOrderItem> entrees = Menu.Entrees();
        private IEnumerable<IOrderItem> sides = Menu.Sides();
        private IEnumerable<IOrderItem> drinks = Menu.Drinks();

        private string size = "Small";
        private string flavor = "Blackberry";

        public MenuScreen()
        {
            InitializeComponent();
            AddMenuItemToColumn();
        }

        /// <summary>
        /// Creates item selection menus for each Menu.cs method
        /// </summary>
        private void AddMenuItemToColumn()
        {
            foreach(IOrderItem entree in entrees)
            {
                CreateButton(entree.ToString(), "entree");
            }
            foreach (IOrderItem side in sides)
            {
                string name = side.ToString();
                if (name.Contains("Small")){
                    name = name.Remove(0,5);
                    CreateButton(name, "side");
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

                        CreateButton(name, "drink");
                    }
                }
                else
                {
                    CreateButton(name, "drink");
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
                item.Name = "ENTREE_" + name.Replace(" ", "").Replace("-", "");
                EntreesColumn.Children.Add(item); 
            }
            if (column == "side")
            {
                item.Name = "SIDE_" + name.Replace(" ", "").Replace("-", "");
                SidesColumn.Children.Add(item);
            }
            if (column == "drink")
            {
                item.Name = "DRINK_" + name.Replace(" ", "").Replace("-", "");
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
            string name = (sender as Button).Name;
            string text = (sender as Button).Content.ToString().Trim();


            StackPanel selectOption = new StackPanel();
            TextBlock n = new TextBlock(); n.Text = text; n.FontSize = 20; selectOption.Children.Add(n);

            MenuGrid.Visibility = Visibility.Collapsed;

            if (name.Contains("SIDE") || name.Contains("DRINK"))
            {
                text = "SELECTING SIZE --" + text;

                TextBlock sizeBox = new TextBlock(); sizeBox.Text = "Select Size"; sizeBox.FontSize = 20;
                selectOption.Children.Add(sizeBox);
                RadioButton small = new RadioButton(); small.Content = "Small"; small.GroupName = "SIZE"; small.IsChecked = true; small.Click += RadioChecked;
                RadioButton med = new RadioButton(); med.Content = "Medium"; med.GroupName = "SIZE"; med.Click += RadioChecked;
                RadioButton large = new RadioButton(); large.Content = "Large"; large.GroupName = "SIZE"; large.Click += RadioChecked;
                selectOption.Children.Add(small);
                selectOption.Children.Add(med);
                selectOption.Children.Add(large);

                if ((sender as Button).Content.ToString().Contains("Sailor Soda"))
                {
                    text = text.Replace("SELECTING SIZE --", "SELECTING SIZE -- SELECTING FLAVOR --");

                    TextBlock flavBox = new TextBlock(); flavBox.Text = "Select Flavor"; flavBox.FontSize = 20;
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
                TextBlock otherBox = new TextBlock(); otherBox.Text = "Other Customization"; otherBox.FontSize = 20;
                selectOption.Children.Add(otherBox);
            }

            if (name.Contains("DRINK"))
            {
                if(text.Contains("Aretino Apple Juice") || text.Contains("Markarth Milk") || text.Contains("Sailor Soda"))
                {
                    CheckBox ice = new CheckBox(); ice.Content = "Ice";
                    selectOption.Children.Add(ice);
                }
                else if(text.Contains("Candlehearth Coffee"))
                {
                    CheckBox ice = new CheckBox(); ice.Content = "Ice";
                    CheckBox cream = new CheckBox(); cream.Content = "Cream";
                    CheckBox decaf = new CheckBox(); decaf.Content = "Decaf"; 
                    selectOption.Children.Add(ice);
                    selectOption.Children.Add(cream);
                    selectOption.Children.Add(decaf);
                }
                else if(text.Contains("Warrior Water"))
                {
                    CheckBox ice = new CheckBox(); ice.Content = "Ice"; ice.IsChecked = true;
                    CheckBox lemon = new CheckBox(); lemon.Content = "Lemon";
                    selectOption.Children.Add(ice);
                    selectOption.Children.Add(lemon);
                }
            }
            
            if (name.Contains("ENTREE"))
            {
                if(text.Contains("Briarheart Burger") || text.Contains("Double Draugr") || text.Contains("Thalmor Triple"))
                {
                    CheckBox bun = new CheckBox(); bun.Content = "Bun"; bun.IsChecked = true;
                    CheckBox ketchup = new CheckBox(); ketchup.Content = "Ketchup"; ketchup.IsChecked = true;
                    CheckBox mustard = new CheckBox(); mustard.Content = "Mustard"; mustard.IsChecked = true;
                    CheckBox pickle = new CheckBox(); pickle.Content = "Pickle"; pickle.IsChecked = true;
                    CheckBox cheese = new CheckBox(); cheese.Content = "Cheese"; cheese.IsChecked = true;
                    selectOption.Children.Add(bun);
                    selectOption.Children.Add(ketchup);
                    selectOption.Children.Add(mustard);
                    selectOption.Children.Add(pickle);
                    selectOption.Children.Add(cheese);
                }
                if(text.Contains("Double Draugr") || text.Contains("Thalmor Triple"))
                {
                    CheckBox tomato = new CheckBox(); tomato.Content = "Tomato"; tomato.IsChecked = true;
                    CheckBox lettuce = new CheckBox(); lettuce.Content = "Lettuce"; lettuce.IsChecked = true;
                    CheckBox mayo = new CheckBox(); mayo.Content = "Mayo"; mayo.IsChecked = true;
                    selectOption.Children.Add(tomato);
                    selectOption.Children.Add(lettuce);
                    selectOption.Children.Add(mayo);
                }
                if(text.Contains("Thalmor Triple"))
                {
                    CheckBox bacon = new CheckBox(); bacon.Content = "Bacon"; bacon.IsChecked = true;
                    CheckBox egg = new CheckBox(); egg.Content = "Egg"; egg.IsChecked = true;
                    selectOption.Children.Add(bacon);
                    selectOption.Children.Add(egg);
                }
                else if(text.Contains("Garden Orc Omelette"))
                {
                    CheckBox broccoli = new CheckBox(); broccoli.Content = "Broccoli"; broccoli.IsChecked = true;
                    CheckBox mushrooms = new CheckBox(); mushrooms.Content = "Mushrooms"; mushrooms.IsChecked = true;
                    CheckBox tomato = new CheckBox(); tomato.Content = "Tomato"; tomato.IsChecked = true;
                    CheckBox cheddar = new CheckBox(); cheddar.Content = "Cheddar"; cheddar.IsChecked = true;
                    selectOption.Children.Add(broccoli);
                    selectOption.Children.Add(mushrooms);
                    selectOption.Children.Add(tomato);
                    selectOption.Children.Add(cheddar);
                }
                else if (text.Contains("Philly Poacher"))
                {
                    CheckBox sirloin = new CheckBox(); sirloin.Content = "Sirloin"; sirloin.IsChecked = true;
                    CheckBox onion = new CheckBox(); onion.Content = "Onion"; onion.IsChecked = true;
                    CheckBox roll = new CheckBox(); roll.Content = "Roll"; roll.IsChecked = true;
                    selectOption.Children.Add(sirloin);
                    selectOption.Children.Add(onion);
                    selectOption.Children.Add(roll);
                }
                else if (text.Contains("Smokehouse Skeleton"))
                {
                    CheckBox sausage = new CheckBox(); sausage.Content = "Sausage"; sausage.IsChecked = true;
                    CheckBox egg = new CheckBox(); egg.Content = "Egg"; egg.IsChecked = true;
                    CheckBox hashbrowns = new CheckBox(); hashbrowns.Content = "Hashbrowns"; hashbrowns.IsChecked = true;
                    CheckBox pancake = new CheckBox(); pancake.Content = "Pancake"; pancake.IsChecked = true;
                    selectOption.Children.Add(sausage);
                    selectOption.Children.Add(egg);
                    selectOption.Children.Add(hashbrowns);
                    selectOption.Children.Add(pancake);
                }
            }


            StackPanel selectGrid = new StackPanel();
            ToggleGrid.Children.Add(selectGrid);

            selectGrid.Children.Add(selectOption);
            Button OK = new Button(); OK.Content = "Enter Selected"; OK.Height = 30; OK.Click += OKSelection; OK.VerticalAlignment = VerticalAlignment.Bottom;
            selectGrid.Children.Add(OK);

            TextBlock item = new TextBlock();
            item.Text = text;
            Selected.Children.Add(item);
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
        }

        /// <summary>
        /// Click event for confirming customization button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKSelection(object sender, RoutedEventArgs e)
        {
            var txt = (TextBlock)Selected.Children[Selected.Children.Count - 1];

            txt.Text = txt.Text.Replace("SELECTING SIZE --", size + " ");
            txt.Text = txt.Text.Replace(" SELECTING FLAVOR --", flavor + " ");

            size = "Blackberry";
            flavor = "Small";
            ToggleGrid.Children.Remove(this.ToggleGrid.Children[1]);
            ToggleGrid.Children[0].Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Click event for cancel order button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelOrder(object sender, RoutedEventArgs e)
        {
            Selected.Children.Clear();
        }
    }
}
