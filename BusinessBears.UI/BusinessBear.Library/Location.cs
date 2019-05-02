using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessBear.Library
{
    /// <summary>
    /// A location object that has an inventory and an order history. Also contains processing for orders
    /// </summary>
    public class Location
    {
        int _location_id;
        private Dictionary<string, int> inventory;
        public Dictionary<string, int> Inventory { get => inventory; }
        List<Order> orderHistory;

        /// <summary>
        /// AddProduct is used to stock the store with inventory
        /// </summary>
        /// <param name="item"></param>
        public void AddProduct(Product item)
        {
            inventory.Add(item.Name, item.Quantity);
            Console.WriteLine("Item added to inventory");
        }
        /// <summary>
        /// ProcessOrder handles functionality for placing orders
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Order ProcessOrder(Order order)
        {
            bool upgradesQ = true;

            foreach (Bear bear in order.bears)
                foreach (var item2 in bear.upgrades)
                {
                    if (inventory.ContainsKey(item2.Name))
                    {
                        if (inventory[item2.Name] == 0)
                        {
                            upgradesQ = false;
                        }
                    }
                }
            if (inventory["Bear"] - order.bears.Count < 0 || upgradesQ == false)
            {
                Console.WriteLine("This location's inventory cannot satisfy this order");
            }
            else
            {
                double finalprice = 0;
                foreach (Bear bear in order.bears)
                {
                    inventory["Bear"]--;
                    foreach (var item in bear.upgrades)
                    {
                        inventory[item.Name]--;
                    }
                    finalprice += bear.getPrice();
                }
                Console.WriteLine("Order placed! The bear(s) will cost ${0}", finalprice);
            }

            order.LocationID = this._location_id;
            order.Ordertime = new DateTime();
            this.orderHistory.Add(order);
            return order;
        }
        public Location()
        {
            this.inventory = new Dictionary<string, int>();
            inventory.Add("Bear", 0);
            this.orderHistory = new List<Order> ();
        }
    }
}
