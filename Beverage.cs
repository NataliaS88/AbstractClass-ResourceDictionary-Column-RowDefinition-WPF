using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WendingMashine
{
    public abstract class Beverage
    {
        public int waterTemp = 25;
        public List<Ingredient> ingredientForBeverage;
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _price;
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public Beverage(string name = "New drink", int price = 0)
        {
            this._name = name;
            this._price = price;
        }
        public abstract string Prepare();
        public abstract string BoilWater();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
    }
    class Coffee : Beverage
    {
        public Coffee(string name = "COFFEE", int price = 25) : base(name, price)
        {
            Ingredient disposableCup = new Ingredient("disposable cup", 2);
            Ingredient coffeeBeans = new Ingredient("coffee beans", 2);
            Ingredient water = new Ingredient("water", 2);
            Ingredient sugar = new Ingredient("sugar", 1);
            ingredientForBeverage = new List<Ingredient>() {
                disposableCup, coffeeBeans, water, sugar
            };
        }
        public override string Prepare()
        {
            string process = $"Adding ingredients: coffee beans, water and sugar (if it was added)";
            return process;
        }
        public override string BoilWater()
        {
            waterTemp = 80;
            return $"Boil water up to {waterTemp}C";
        }
        public override string ToString()
        {
            return $"drink { this.Name} with price { this.Price}NIS consists of: coffee beans, water and sugar (if you will add)";
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Coffee bev = (Coffee)obj;
                return base.Name.Equals(bev.Name);
            }
        }
    }
    class BlackTea : Beverage
    {
        public BlackTea(string name = "BLACK TEA", int price = 15) : base(name, price)
        {
            Ingredient disposableCup = new Ingredient("disposable cup", 2);
            Ingredient blackTea = new Ingredient("black tea", 2);
            Ingredient water = new Ingredient("water", 2);
            Ingredient sugar = new Ingredient("sugar", 2);
            ingredientForBeverage = new List<Ingredient>() {
                disposableCup, blackTea, water, sugar
            };
        }
        public override string Prepare()
        {
            string process = $"Adding ingredients: black tea, water and sugar (if it was added)";
            return process;
        }
        public override string BoilWater()
        {
            waterTemp = 90;
            return $"Boil water up to {waterTemp}C";
        }
        public override string ToString()
        {
            return $"drink { this.Name} with price { this.Price}NIS consists of: black tea, water and sugar (if you will add)";
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                BlackTea bev = (BlackTea)obj;
                return base.Name.Equals(bev.Name);
            }
        }
    }
    class Chocolate : Beverage
    {
        public Chocolate(string name = "CHOCOLATE", int price = 30) : base(name, price)
        {
            Ingredient disposableCup = new Ingredient("disposable cup", 2);
            Ingredient cacao = new Ingredient("cacao", 2);
            Ingredient water = new Ingredient("water", 2);
            Ingredient sugar = new Ingredient("sugar", 2);
            ingredientForBeverage = new List<Ingredient>() {
                disposableCup, cacao, water, sugar
            };
        }
        public override string Prepare()
        {
            string process = $"Adding ingredients: cacao, water and sugar (if it was added)";
            return process;
        }
        public override string BoilWater()
        {
            waterTemp = 75;
            return $"Boil water up to {waterTemp}C";
        }
        public override string ToString()
        {
            return $"drink { this.Name} with price { this.Price}NIS consists of: cacao, water and sugar (if you will add)";
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Chocolate bev = (Chocolate)obj;
                return base.Name.Equals(bev.Name);
            }
        }
    }
    class GreenTea : Beverage
    {
        public GreenTea(string name = "GREEN TEA", int price = 15) : base(name, price)
        {
            Ingredient disposableCup = new Ingredient("disposable cup", 2);
            Ingredient water = new Ingredient("water", 2);
            Ingredient greenTea = new Ingredient("green tea", 2);
            Ingredient sugar = new Ingredient("sugar", 2);
            ingredientForBeverage = new List<Ingredient>() {
                disposableCup, greenTea, water, sugar
            };
        }
        public override string Prepare()
        {
            string process = $"Adding ingredients: green tea, water and sugar (if it was added)";
            return process;
        }
        public override string BoilWater()
        {
            waterTemp = 70;
            return $"Boil water up to {waterTemp}C";
        }
        public override string ToString()
        {
            return $"drink { this.Name} with price { this.Price}NIS consists of: green tea, water and sugar (if you will add)";
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                GreenTea bev = (GreenTea)obj;
                return base.Name.Equals(bev.Name);
            }
        }
    }
    class Latte : Beverage
    {
        public Latte(string name = "LATTE", int price = 30) : base(name, price)
        {
            Ingredient sugar = new Ingredient("sugar", 2);
            Ingredient disposableCup = new Ingredient("disposable cup", 2);
            Ingredient water = new Ingredient("water", 2);
            Ingredient exclusiveCoffeeBeans = new Ingredient("exclusive coffee beans", 2);
            Ingredient milk = new Ingredient("milk", 2);
            ingredientForBeverage = new List<Ingredient>() {
                disposableCup, exclusiveCoffeeBeans, water, sugar, milk
            };
        }
        public override string Prepare()
        {
            string process = $"Adding ingredients: exclusive coffee beans, milk, water and sugar (if it was added)";
            return process;
        }

        public override string BoilWater()
        {
            waterTemp = 80;
            return $"Boil water up to {waterTemp}C";
        }
        public override string ToString()
        {
            return $"drink { this.Name} with price { this.Price}NIS consists of: exclusive coffee beans, milk, water and sugar (if you will add)";
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Latte bev = (Latte)obj;
                return base.Name.Equals(bev.Name);
            }
        }
    }
    class MintTea : Beverage
    {
        public MintTea(string name = "MINT TEA", int price = 15) : base(name, price)
        {
            Ingredient disposableCup = new Ingredient("disposable cup", 2);
            Ingredient mintTea = new Ingredient("mint tea", 2);
            Ingredient water = new Ingredient("water", 2);
            Ingredient sugar = new Ingredient("sugar", 2);
            ingredientForBeverage = new List<Ingredient>() {
                disposableCup, mintTea, water, sugar
            };
        }
        public override string Prepare()
        {
            string process = $"Adding ingredients: mint tea, water and sugar (if it was added)";
            return process;
        }
        public override string BoilWater()
        {
            waterTemp = 90;
            return $"Boil water up to {waterTemp}C";
        }
        public override string ToString()
        {
            return $"drink { this.Name} with price { this.Price}NIS consists of: mint tea, water and sugar (if you will add)";
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                MintTea bev = (MintTea)obj;
                return base.Name.Equals(bev.Name);
            }
        }
    }
}