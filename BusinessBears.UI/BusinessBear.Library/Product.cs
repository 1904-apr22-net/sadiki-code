using System;
using System.Collections.Generic;

namespace BusinessBears.Library
{

/// <summary>
/// Abstract class used as a model for any object representing an inventory item. Contains functionality for
/// getting/setting names, getting/setting quantity and provides an abstract method for price getting
/// </summary>
    public abstract class Product
    {
        protected string _name;
        public string Name { get => _name; set => _name = value; }
        public abstract double getPrice();

    }
    /// <summary>
    /// 
    /// </summary>
    public class Bear : Product
    {
        public Bear()
        {
            this._name = "Bear";
        }

        public Bear(HashSet<Training> t)
        {
            this._name = "Bear";
            this.upgrades = t;
        }

        protected readonly double _price = 199.99;
        public HashSet<Training> upgrades;
        
        public void AddTraining(Training training)
        {
            upgrades.Add(training);
        }
        /// <summary>
        /// Bear.getPrice() accounts for any training the bear will receive as part of the purchase
        /// </summary>
        /// <returns></returns>
        public override double getPrice()
        {
            double d = this._price;
            foreach (Training item in upgrades)
            {
                d += item.getPrice();
            }
            return d;
        }

    }

    //public class Cub : Bear
    //{
    //    private readonly new double _price = 250.0;
    //    public override double getPrice()
    //    {
    //        double d = this._price;
    //        foreach (Training item in upgrades)
    //        {
    //            d += item.getPrice() * 1.7;
    //        }
    //        return d;
    //    }
    //}

    public class Training : Product
    {
        double _price;

        public Training(string n, double p)
        {
            this._name = n;
            this._price = p;
        }      
        

        
        public override double getPrice()
        {
            return this._price;
        }

    }

    public class InventoryItem
    {
        private Product product;
        private int _quantity;
        public int Quantity { get => _quantity; set => _quantity = value; }
        public Product Product { get => product; }

        public InventoryItem(Product p, int i)
        {
            this.product = p;
            this._quantity = i;
        }
    }
}
