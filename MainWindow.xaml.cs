using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WendingMashine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Manager _manager;
        public MainWindow()
        {
            InitializeComponent();
            _manager = new Manager(MyGrid);
            _manager.CreateDrinkMashine();
            _manager.AddDrinkToMashine("COFFEE");
            _manager.AddDrinkToMashine("LATTE");
            _manager.AddDrinkToMashine("BLACK TEA");
            ContactWindow.Text = "Hello! Which drink do you want to order?";
        }
        private void OrderDrink(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            _manager.PrepareDrink(btn.Content.ToString());
        }
        private void Refill(object sender, RoutedEventArgs e)
        {
            _manager.RefillAllIngredients(5);
        }
        private void GetAllIngredients(object sender, RoutedEventArgs e)
        {
            string listOfIngredientAmount = _manager.GetAllIngredients();
            ContactWindow.Text = listOfIngredientAmount;
        }

        private void ShowIncomeForNow(object sender, RoutedEventArgs e)
        {
            _manager.ShowIncome();
        }
        private void RemoveDrink(object sender, RoutedEventArgs e)
        {
            ContactWindow.Text = $"Please choose the name of a drink which you want to delete.{Environment.NewLine}Chose drink which was added before";
            _manager.StartRemoveDrink();
        }
        private void AddDrink(object sender, RoutedEventArgs e)
        {
            ContactWindow.Text = $"Please choose the name of a drink which you want to Add.{Environment.NewLine}Chose drink which was not added before";
            _manager.StartAddDrink();
        }
    }
}

