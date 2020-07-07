using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WendingMashine
{
    public class DrinkMashine
    {
        private MainWindow mainwindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
        Grid _myGrid;
        TextBlock sugarblock;
        RadioButton choiseNo;
        RadioButton choiseYes;
        Button receiveDrink;
        Button pay;
        Button cancel;
        int income = 0;
        public TextBox inputName;
        Beverage bevInWork = null;
        private int controlMaxBeverages = 0;
        bool withSugar;
        private List<Beverage> _myBeverages = new List<Beverage>();
        private List<Ingredient> _myIngredients = new List<Ingredient>();
        public DrinkMashine(Grid MyGrid)
        {
            _myGrid = MyGrid;
        }
        public void AddBeverage(Beverage newBev)
        {
            bool exist = false;
            foreach (var beverage in _myBeverages)
            {
                if (beverage.Name.Equals(newBev.Name)) exist = true;
            }
            if (exist)
            {
                DisplayMessage($"You already have {newBev.Name} drink in mashine");
            }
            else if (controlMaxBeverages == 5)
            {
                DisplayMessage($"Drink in mashine is full of drinks");
            }
            else
            {
                string nameOfBev = newBev.Name;
                controlMaxBeverages++;
                AddIngredients(newBev);
                _myBeverages.Add(newBev);
                DisplayMessage($"New drink {newBev.Name} was added to mashine. {Environment.NewLine}Which drink do you want to order?");
                CreateDrinksView(newBev, nameOfBev);
            }
        }
        private void CreateDrinksView(Beverage newBev = null, string nameOfBev = "empty")
        {
            switch (controlMaxBeverages)
            {
                case 1:
                    if (newBev == null)
                    {
                        mainwindow.Btn1.Content = "EMPTY";
                        mainwindow.img1.Source = null;
                        mainwindow.txtBtn1.Text = "";
                        break;
                    }
                    else
                    {
                        mainwindow.Btn1.Content = newBev.Name;
                        mainwindow.img1.Source = (ImageSource)mainwindow.FindResource(nameOfBev);
                        mainwindow.txtBtn1.Text = "Price: " + newBev.Price + "NIS";
                        break;
                    }
                case 2:
                    if (newBev == null)
                    {
                        mainwindow.Btn2.Content = "EMPTY";
                        mainwindow.img2.Source = (ImageSource)mainwindow.FindResource("EMPTY");
                        mainwindow.txtBtn2.Text = "";
                        break;
                    }
                    else
                    {
                        mainwindow.Btn2.Content = newBev.Name;
                        mainwindow.img2.Source = (ImageSource)mainwindow.FindResource(nameOfBev);
                        mainwindow.txtBtn2.Text = "Price: " + newBev.Price + "NIS";
                        break;
                    }
                case 3:
                    if (newBev == null)
                    {
                        mainwindow.Btn3.Content = "EMPTY";
                        mainwindow.img3.Source = (ImageSource)mainwindow.FindResource("EMPTY");
                        mainwindow.txtBtn3.Text = "";
                        break;
                    }
                    else
                    {
                        mainwindow.Btn3.Content = newBev.Name;
                        mainwindow.img3.Source = (ImageSource)mainwindow.FindResource(nameOfBev);
                        mainwindow.txtBtn3.Text = "Price: " + newBev.Price + "NIS";
                        break;
                    }
                case 4:
                    if (newBev == null)
                    {
                        mainwindow.Btn4.Content = "EMPTY";
                        mainwindow.img4.Source = (ImageSource)mainwindow.FindResource("EMPTY");
                        mainwindow.txtBtn4.Text = "";
                        break;
                    }
                    else
                    {
                        mainwindow.Btn4.Content = newBev.Name;
                        mainwindow.img4.Source = (ImageSource)mainwindow.FindResource(nameOfBev);
                        mainwindow.txtBtn4.Text = "Price: " + newBev.Price + "NIS";
                        break;
                    }
                case 5:
                    if (newBev == null)
                    {
                        mainwindow.Btn5.Content = "EMPTY";
                        mainwindow.img5.Source = (ImageSource)mainwindow.FindResource("EMPTY");
                        mainwindow.txtBtn5.Text = "";
                        break;
                    }
                    else
                    {
                        mainwindow.Btn5.Content = newBev.Name;
                        mainwindow.img5.Source = (ImageSource)mainwindow.FindResource(nameOfBev);
                        mainwindow.txtBtn5.Text = "Price: " + newBev.Price + "NIS";
                        break;
                    }
            }
        }
        public async void Remove(string name)
        {
            bevInWork = FindBeverage(name);
            if (bevInWork == null)
            {
                DisplayMessage("There is no such drink in mashine");
                EnableButtons(true);
            }
            else
            {
                _myGrid.Children.Remove(cancel);
                DleteUniqueIngr(bevInWork);
                _myBeverages.Remove(bevInWork);
                DisplayMessage($"The {name} drink was deleted");
                await Task.Delay(1000);
                DisplayMessage("Which drink do you want to order ?");
                controlMaxBeverages--;
                int temp = controlMaxBeverages;
                controlMaxBeverages = 0;
                for (int i = _myBeverages.Count - 1; i > -1; i--)
                {
                    controlMaxBeverages++;
                    string drName = _myBeverages[i].Name;
                    CreateDrinksView(_myBeverages[i], drName);
                }
                controlMaxBeverages = _myBeverages.Count + 1;
                CreateDrinksView();
                controlMaxBeverages = temp;
                EnableButtons(true);
            }

        }
        private void DleteUniqueIngr(Beverage bevInWork)
        {
            if (_myBeverages.Count == 1) _myIngredients.Clear();
            else
            {
                for (int i = 0; i < bevInWork.ingredientForBeverage.Count; i++)
                {
                    Ingredient uniqueIngr;
                    int countUnique = 0;
                    for (int j = 0; j < _myBeverages.Count; j++)
                    {
                        for (int k = 0; k < _myBeverages[j].ingredientForBeverage.Count; k++)
                        {
                            if (_myBeverages[j].ingredientForBeverage[k].Name.Equals(bevInWork.ingredientForBeverage[i].Name))
                            {
                                countUnique++;
                            }
                        }
                        if (countUnique > 1) break;
                    }
                    if (countUnique == 1)
                    {
                        uniqueIngr = bevInWork.ingredientForBeverage[i];
                        for (int z = 0; z < _myIngredients.Count; z++)
                        {
                            if (_myIngredients[z].Name.Equals(bevInWork.ingredientForBeverage[i].Name))
                            {
                                _myIngredients.Remove(uniqueIngr);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void AddIngredients(Beverage newBev)
        {
            for (int i = 0; i < newBev.ingredientForBeverage.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < this._myIngredients.Count; j++)
                {
                    if (this._myIngredients[j].Name == newBev.ingredientForBeverage[i].Name)
                    {
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                if (count == this._myIngredients.Count)
                {
                    this._myIngredients.Add(newBev.ingredientForBeverage[i]);
                }
            }
        }
        public void DisplayMessage(string text)
        {
            mainwindow.ContactWindow.Text = text;
        }
        public string GetAllIngredients()
        {
            if (_myIngredients.Count == 0) return "Empty";
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Ingredients in stock:");
                for (int i = 0; i < _myIngredients.Count; i++)
                {
                    sb.AppendLine(_myIngredients[i].Name + " " + _myIngredients[i].Amount);
                }
                return sb.ToString();
            }
        }
        public void RefillIngredients(int amount = 10)
        {
            for (int i = 0; i < _myIngredients.Count; i++)
            {
                if (_myIngredients[i].Amount > 10) return;
                _myIngredients[i].Amount = amount;
            }
            string ing = GetAllIngredients();
            DisplayMessage($"All stocks are refilled! {Environment.NewLine}{ing}");
        }
        public void PrepareDrink(string nameOfBev)
        {
            FindBeverage(nameOfBev);
            if (bevInWork != null)
            {
                DisplayMessage($"Your order is {bevInWork.ToString()}");
                EnableButtons(false);
                CreateBtnCancel();
                AskAddSugar(bevInWork);
            }
            else
                DisplayMessage("Your drink is not exist in this mashine");
        }
        private void CreateBtnCancel()
        {
            cancel = new Button()
            {
                Content = "Cancel"
            };
            Grid.SetColumn(cancel, 2);
            Grid.SetRow(cancel, 7);
            _myGrid.Children.Add(cancel);
            cancel.Click += new RoutedEventHandler(cancel_Click);
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            _myGrid.Children.Remove(cancel);
            EnableButtons(true);
            RemoveSugarAsk();
            _myGrid.Children.Remove(pay);
            _myGrid.Children.Remove(inputName);
            DisplayMessage($" Your request was cancelled suquesfully! {Environment.NewLine}Which drink do you want to order?");
        }
        private Beverage FindBeverage(string nameBev)
        {
            for (int i = 0; i < _myBeverages.Count; i++)
            {
                if (_myBeverages[i].Name.Equals(nameBev))
                {
                    bevInWork = _myBeverages[i];
                    return bevInWork;
                }
            }
            return bevInWork = null;
        }
        private bool CheckIfEnoughtIngredients(Beverage bev)
        {
            bool enoughIngr = true;
            for (int i = 0; i < bev.ingredientForBeverage.Count; i++)
            {
                for (int j = 0; j < _myIngredients.Count; j++)
                {
                    if (_myIngredients[j].Name.Equals(bev.ingredientForBeverage[i].Name))
                    {
                        if (_myIngredients[j].Amount < 1)
                        {
                            enoughIngr = false;
                            break;
                        }
                    }
                }
            }
            return enoughIngr;
        }
        private bool CheckIfEnoughtIngrWithoutSugar(Beverage bev)
        {
            bool enoughIngr = true;
            for (int i = 0; i < bev.ingredientForBeverage.Count; i++)
            {
                for (int j = 0; j < _myIngredients.Count; j++)
                {
                    if (_myIngredients[j].Name.Equals(bev.ingredientForBeverage[i].Name) && _myIngredients[j].Name != "sugar")
                    {
                        if (_myIngredients[j].Amount < 1)
                        {
                            enoughIngr = false;
                            break;
                        }
                    }
                }
            }
            return enoughIngr;
        }
        public void Income()
        {
            DisplayMessage($"The income is {income}");
        }
        private void AskAddSugar(Beverage bev)
        {
            sugarblock = new TextBlock()
            {
                Text = "Do you want to add sugar?",
                Name = "radiobtn",
            };
            Grid.SetColumn(sugarblock, 2);
            Grid.SetRow(sugarblock, 5);
            Grid.SetColumnSpan(sugarblock, 2);
            _myGrid.Children.Add(sugarblock);

            choiseNo = new RadioButton()
            {
                Name = "no",
                GroupName = "sugar",
                Content = "NO",

            };
            Grid.SetColumn(choiseNo, 2);
            Grid.SetRow(choiseNo, 6);
            _myGrid.Children.Add(choiseNo);
            choiseNo.Checked += new RoutedEventHandler(choiseNo_Checked);

            choiseYes = new RadioButton()
            {
                Name = "yes",
                GroupName = "sugar",
                Content = "YES",
            };
            Grid.SetColumn(choiseYes, 3);
            Grid.SetRow(choiseYes, 6);
            _myGrid.Children.Add(choiseYes);
            choiseYes.Checked += new RoutedEventHandler(ChoiseYes_Checked);
        }
        private void ChoiseYes_Checked(object sender, RoutedEventArgs e)
        {
            bool checkStockIngr = CheckIfEnoughtIngredients(bevInWork);

            if (checkStockIngr)
            {
                DisplayMessage($"Please pay {bevInWork.Price}NIS  for your {bevInWork.Name} drink");
                bevInWork.Prepare();
                withSugar = true;
                pay = new Button()
                {
                    Content = "Pay"
                };
                Grid.SetColumn(pay, 3);
                Grid.SetRow(pay, 7);
                _myGrid.Children.Add(pay);
                pay.Click += new RoutedEventHandler(pay_Click);
            }
            else
            {
                DisplayMessage($"Not enought ingredients for this drink in stock. {Environment.NewLine}Ask the manager to refill ingredients or choose please another drink");
                EnableButtons(true);
            }
            RemoveSugarAsk();
        }
        private void UseIngrWithSugar()
        {
            for (int i = 0; i < bevInWork.ingredientForBeverage.Count; i++)
            {
                for (int j = 0; j < _myIngredients.Count; j++)
                {
                    if (_myIngredients[j].Name.Equals(bevInWork.ingredientForBeverage[i].Name))
                    {
                        _myIngredients[j].Amount--;
                    }
                }
            }
        }
        private void choiseNo_Checked(object sender, RoutedEventArgs e)
        {
            bool checkStockIngr = CheckIfEnoughtIngrWithoutSugar(bevInWork);

            if (checkStockIngr)
            {
                string s = bevInWork.Prepare();
                withSugar = false;
                DisplayMessage($"Please pay {bevInWork.Price}NIS  for your {bevInWork.Name} drink");
                pay = new Button()
                {
                    Content = "Pay"
                };
                Grid.SetColumn(pay, 3);
                Grid.SetRow(pay, 7);
                _myGrid.Children.Add(pay);
                pay.Click += new RoutedEventHandler(pay_Click);
            }
            else
            {
                DisplayMessage($"Not enought ingredients for this drink in stock.{Environment.NewLine}Ask the manager to refill ingredients or choose please another drink");
                EnableButtons(true);
            }
            RemoveSugarAsk();
        }
        private void UseIngrWithoutSugar()
        {
            for (int i = 0; i < bevInWork.ingredientForBeverage.Count; i++)
            {
                for (int j = 0; j < _myIngredients.Count; j++)
                {
                    if (_myIngredients[j].Name.Equals(bevInWork.ingredientForBeverage[i].Name) && _myIngredients[j].Name != "sugar")
                    {
                        _myIngredients[j].Amount--;
                    }
                }
            }
        }
        private async void pay_Click(object sender, RoutedEventArgs e)
        {
            _myGrid.Children.Remove(pay);
            _myGrid.Children.Remove(cancel);
            income += bevInWork.Price;
            if (withSugar)
            {
                UseIngrWithSugar();
            }
            else
            {
                UseIngrWithoutSugar();
            }
            DisplayMessage($"Your {bevInWork.Name} preparing!");
            await Task.Delay(1000);
            DisplayMessage(bevInWork.BoilWater());
            await Task.Delay(1000);
            DisplayMessage(bevInWork.Prepare());
            await Task.Delay(1000);
            DisplayMessage("Stirring");
            await Task.Delay(1000);
            DisplayMessage("Your drink is ready! Please, take it!");
            receiveDrink = new Button()
            {
                Content = "Receive Drink"
            };
            Grid.SetColumn(receiveDrink, 3);
            Grid.SetRow(receiveDrink, 7);
            _myGrid.Children.Add(receiveDrink);
            receiveDrink.Click += new RoutedEventHandler(receiveDrink_Click);
        }
        private async void receiveDrink_Click(object sender, RoutedEventArgs e)
        {
            _myGrid.Children.Remove(receiveDrink);
            DisplayMessage($"Be carefull, your drink is hot!{Environment.NewLine}Enjoy your day!");
            EnableButtons(true);
            await Task.Delay(1000);
            DisplayMessage("Hi! Which drink do you want to order ?");
        }
        private void RemoveSugarAsk()
        {
            _myGrid.Children.Remove(choiseNo);
            _myGrid.Children.Remove(choiseYes);
            _myGrid.Children.Remove(sugarblock);
        }
        public void EnableButtons(Boolean b)
        {
            mainwindow.RefillIngr.IsEnabled = b;
            mainwindow.ShowIngredients.IsEnabled = b;
            mainwindow.ShowIncome.IsEnabled = b;
            mainwindow.RemoveDrin.IsEnabled = b;
            mainwindow.AddDrin.IsEnabled = b;
            if (mainwindow.Btn1.Content.Equals("EMPTY")) { mainwindow.Btn1.IsEnabled = false; }
            else
                mainwindow.Btn1.IsEnabled = b;
            if (mainwindow.Btn2.Content.Equals("EMPTY")) { mainwindow.Btn2.IsEnabled = false; }
            else
                mainwindow.Btn2.IsEnabled = b;
            if (mainwindow.Btn3.Content.Equals("EMPTY")) { mainwindow.Btn3.IsEnabled = false; }
            else
                mainwindow.Btn3.IsEnabled = b;
            if (mainwindow.Btn4.Content.Equals("EMPTY")) { mainwindow.Btn4.IsEnabled = false; }
            else
                mainwindow.Btn4.IsEnabled = b;
            if (mainwindow.Btn5.Content.Equals("EMPTY")) { mainwindow.Btn5.IsEnabled = false; }
            else
                mainwindow.Btn5.IsEnabled = b;

        }
    }
}