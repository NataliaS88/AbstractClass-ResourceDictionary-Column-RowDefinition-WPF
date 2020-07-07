using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WendingMashine
{
    public class Manager
    {
        private MainWindow mainwindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
        string dr1 = "COFFEE";
        string dr2 = "BLACK TEA";
        string dr3 = "GREEN TEA";
        string dr4 = "LATTE";
        string dr5 = "CHOCOLATE";
        string dr6 = "MINT TEA";
        DrinkMashine mashine;
        ComboBox drinks;
        Button addDrink;
        Button removeDrink;
        public Grid _myGrid;

        public Manager(Grid MyGrid)
        {
            _myGrid = MyGrid;
        }
        public void CreateDrinkMashine()
        {
            mashine = new DrinkMashine(_myGrid);
        }
        private Beverage CreateBeverage(string bev)
        {
            if (bev.Equals(dr1))
            {
                Beverage freshCoffee = new Coffee();
                return freshCoffee;
            }
            else if (bev.Equals(dr2))
            {
                Beverage blackTea = new BlackTea();
                return blackTea;
            }
            else if (bev.Equals(dr3))
            {
                Beverage greenTea = new GreenTea();
                return greenTea;
            }
            else if (bev.Equals(dr4))
            {
                Beverage latte = new Latte();
                return latte;
            }
            else if (bev.Equals(dr5))
            {
                Beverage chocolate = new Chocolate();
                return chocolate;
            }
            else if (bev.Equals(dr6))
            {
                Beverage mintTea = new MintTea();
                return mintTea;
            }
            else return null;
        }
        public void AddDrinkToMashine(string bev)
        {
            Beverage newBev = CreateBeverage(bev);
            if (newBev == null)
            {
                mashine.DisplayMessage("This drink is not created, create it before adding to mashine");
            }
            else
            {
                mashine.AddBeverage(newBev);
            }
        }
        public void PrepareDrink(string nameBev)
        {
            mashine.PrepareDrink(nameBev);
        }
        public string GetAllIngredients()
        {
            return mashine.GetAllIngredients();
        }
        public void RefillAllIngredients(int amount = 10)
        {
            mashine.RefillIngredients(amount);
        }
        public void ShowIncome()
        {
            mashine.Income();
        }
        public void StartAddDrink()
        {
            addDrink = new Button()
            {
                Content = "Add drink"
            };
            Grid.SetColumn(addDrink, 3);
            Grid.SetRow(addDrink, 7);
            _myGrid.Children.Add(addDrink);
            addDrink.Click += new RoutedEventHandler(addNewDrink_Click);
            mashine.EnableButtons(false);
            CreateComboBoxDrinks();
        }
        private void CreateComboBoxDrinks()
        {
            drinks = new ComboBox();
            drinks.Items.Add(dr1);
            drinks.Items.Add(dr2);
            drinks.Items.Add(dr3);
            drinks.Items.Add(dr4);
            drinks.Items.Add(dr5);
            drinks.Items.Add(dr6);
            drinks.SelectedItem = dr1;
            Grid.SetColumn(drinks, 2);
            Grid.SetRow(drinks, 5);
            _myGrid.Children.Add(drinks);
        }
        private void addNewDrink_Click(object sender, RoutedEventArgs e)
        {
            AddDrinkToMashine(drinks.Text);
            _myGrid.Children.Remove(addDrink);
            _myGrid.Children.Remove(drinks);
            mashine.EnableButtons(true);
        }
        public void StartRemoveDrink()
        {
            removeDrink = new Button()
            {
                Content = "Remove drink"
            };
            Grid.SetColumn(removeDrink, 3);
            Grid.SetRow(removeDrink, 7);
            _myGrid.Children.Add(removeDrink);
            removeDrink.Click += new RoutedEventHandler(removeDrink_Click);
            mashine.EnableButtons(false);
            CreateComboBoxDrinks();
        }
        private void removeDrink_Click(object sender, RoutedEventArgs e)
        {
            mashine.Remove(drinks.Text);
            _myGrid.Children.Remove(removeDrink);
            _myGrid.Children.Remove(drinks);
        }
    }
}

