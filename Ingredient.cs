using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WendingMashine
{
    public class Ingredient
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public Ingredient(string name, int amount)
        {
            _name = name;
            _amount = amount;
        }
        public Ingredient()
        {
            this._name = Name;
        }
    }
}