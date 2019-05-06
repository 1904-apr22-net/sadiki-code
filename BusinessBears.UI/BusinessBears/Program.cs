using BusinessBears.DataAccess.Entities;
using BusinessBears.Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Customer = BusinessBears.Library.Customer;
using Location = BusinessBears.Library.Location;
using CustomerDB = BusinessBears.DataAccess.Entities.Customer;
using LocationDB = BusinessBears.DataAccess.Entities.Location;
using System.Linq;
using Product = BusinessBears.DataAccess.Entities.Product;

namespace BusinessBears
{
    class Program
    {
        static void Main(string[] args)
        {

            BBearContext dbContext = CreateDbContext();
            bool running = true;
            Console.WriteLine("Business Bears: We Sell Bears & Train Bears");
            
            while (running)
            {
                Console.WriteLine();
                Console.Write("Choose a submenu, or \"q\" to quit: ");
                Console.WriteLine();
                Console.WriteLine("r:\tCreate & process new order.");
                Console.WriteLine("a:\tView order history.");
                Console.WriteLine("l:\tLoad data from server.");
                
                var input = Console.ReadLine();
                if (input == "r")
                {

                    Console.WriteLine("Please input the first or last name of the customer");
                    string cname = Console.ReadLine();
                    PrintCustomers(dbContext, cname);
                    Console.WriteLine();
                    Console.WriteLine("Please input the Customer ID from the provided list.");
                    int cID = Convert.ToInt32(Console.ReadLine());



                    Console.WriteLine("How many bears will be required for this order?");
                    int bearcountO = Convert.ToInt32(Console.ReadLine());
                    int counter = 0;
                    HashSet<Training> trainingArray = new HashSet<Training>();
                    List<Bear> bearList = new List<Bear>();
                    while (counter < bearcountO)
                    {
                        Console.WriteLine($"Select the training needed for Bear #{0}. Insert 'f' when finished", counter + 1);
                        Console.WriteLine($"r:\t Juggling - $19.99");
                        Console.WriteLine($"a:\t Fighting - $24.99");
                        Console.WriteLine($"s:\t Tax Evasion - $45.99");
                        Console.WriteLine($"l:\t Marriage Counselling - $69.99");
                        Console.WriteLine($"t:\t Divininty - $199.99");

                        string trainingSelect = Console.ReadLine();
                        if (trainingSelect == "r")
                        {
                            Training t = new Training("Juggling", 19.99);
                            trainingArray.Add(t);
                        }
                        if (trainingSelect == "a")
                        {
                            Training t = new Training("Fighting", 24.99);
                            trainingArray.Add(t);
                        }
                        if (trainingSelect == "s")
                        {
                            Training t = new Training("Tax Evasion", 45.99);
                            trainingArray.Add(t);
                        }
                        if (trainingSelect == "l")
                        {
                            Training t = new Training("Marriage Counselling", 69.99);
                            trainingArray.Add(t);
                        }
                        if (trainingSelect == "t")
                        {
                            Training t = new Training("Divinity", 199.99);
                            trainingArray.Add(t);
                        }
                        if (trainingSelect == "f")
                        {
                            Bear bear = new Bear(trainingArray);
                            bearList.Add(bear);
                            trainingArray.Clear();
                            counter++;
                        }
                        else
                        {
                            Console.WriteLine("Please use one of the listed inputs");
                        }
                    }
                    Order currentOrder = new Order(bearList);
                    currentOrder.CustomerID = cID;

                   


                    Console.WriteLine("Please input a location ID");
                    int lID = Convert.ToInt32(Console.ReadLine());



                    Location orderLocation = RetrieveLocation(dbContext, lID);
                    currentOrder = orderLocation.ProcessOrder(currentOrder);
                    AddOrder(dbContext, currentOrder);
                    UpdateLocation(dbContext, currentOrder);
                }
                if (input == "a")
                {
                    Console.WriteLine("r:\tView a location's order history.");
                    Console.WriteLine("a:\tView a customer's order history.");
                    var inputL = Console.ReadLine();
                    if (inputL == "a")
                    {
                        Console.WriteLine("Please input the first or last name of the customer");
                        string cname = Console.ReadLine();
                        PrintCustomers(dbContext, cname);
                        
                    }
                    Console.WriteLine("Input the target ID:");
                    int ordersearchid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                        Console.WriteLine("Sort by:");
                        Console.WriteLine("r:\tCheapest");
                        Console.WriteLine("a:\tMost Expensive");
                        Console.WriteLine("s:\tEarliest");
                        Console.WriteLine("t:\tLatest");
                        var inputL2 = Console.ReadLine();
                    if (input == "r")
                    {
                        if (inputL2 == "r")
                        {
                            PrintOrdersByLocation(dbContext, ordersearchid, "price");
                        }
                        if (inputL2 == "a")
                        {
                            PrintOrdersByLocation(dbContext, ordersearchid, "price-r");
                        }
                        if (inputL2 == "s")
                        {
                            PrintOrdersByLocation(dbContext, ordersearchid, "time");
                        }
                        if (inputL2 == "t")
                        {
                            PrintOrdersByLocation(dbContext, ordersearchid, "time-r");
                        }
                    }
                    if (inputL == "a")
                    {
                        if (inputL2 == "r")
                        {
                            PrintOrdersByCustomer(dbContext, ordersearchid, "price");
                        }
                        if (inputL2 == "a")
                        {
                            PrintOrdersByCustomer(dbContext, ordersearchid, "price-r");
                        }
                        if (inputL2 == "s")
                        {
                            PrintOrdersByCustomer(dbContext, ordersearchid, "time");
                        }
                        if (inputL2 == "t")
                        {
                            PrintOrdersByCustomer(dbContext, ordersearchid, "time-r");
                        }

                    }
                    
                }
               

                if (input == "q")
                {
                    Console.WriteLine("Exiting Business Bears...");
                    running = false;
                    
                }
                else
                {
                    Console.WriteLine("Please input a valid value\n");

                }
            }

            
        }

        private static void PrintCustomers(BBearContext dbContext, string name)
        {
            foreach (CustomerDB customer in dbContext.Customer.Where(x => x.FirstName == name).Include(x => x.Orders))
            {
                Console.WriteLine($"{customer.CustomerId}: {customer.FirstName} {customer.LastName}");
            }
            foreach (CustomerDB customer in dbContext.Customer.Where(x => x.LastName == name).Include(x => x.Orders))
            {
                Console.WriteLine($"{customer.CustomerId}: {customer.FirstName} {customer.LastName}");
            }
        }


        private static void PrintOrdersByLocation(BBearContext dbContext, int location_id, string type)
        {
            if (type == "time")
            {
                foreach (Orders order in dbContext.Orders.Where(x => x.LocationId == location_id).Include(x => x.Customer).OrderBy(x => x.CreatedAt))
                {
                    PrintOrders(order, dbContext);
                }
            }
            else if (type == "time-r")
            {
                foreach (Orders order in dbContext.Orders.Where(x => x.LocationId == location_id).Include(x => x.Customer).OrderBy(x => x.CreatedAt).Reverse())
                {
                    PrintOrders(order, dbContext);
                }
            }
            else if (type == "price")
            {
                foreach (Orders order in dbContext.Orders.Where(x => x.LocationId == location_id).Include(x => x.Customer).OrderBy(x => x.PriceTag))
                {
                    PrintOrders(order, dbContext);
                }
            }
            else if (type == "price-r")
            {
                foreach (Orders order in dbContext.Orders.Where(x => x.LocationId == location_id).Include(x => x.Customer).OrderBy(x => x.PriceTag).Reverse())
                {
                    PrintOrders(order, dbContext);
                }
            }
            else
            {
                Console.WriteLine("Invalid type. Please try again");
            }
            Console.WriteLine();
        }

        private static void PrintOrdersByCustomer(BBearContext dbContext, int customer_id, string type)
        {
            
            if (type == "time")
            {
                foreach (Orders order in dbContext.Orders.Where(x => x.CustomerId == customer_id).Include(x => x.Customer).OrderBy(x => x.CreatedAt))
                {
                    PrintOrders(order, dbContext);
                }
            }
            else if (type == "time-r")
            {
                foreach (Orders order in dbContext.Orders.Where(x => x.CustomerId == customer_id).Include(x => x.Customer).OrderBy(x => x.CreatedAt).Reverse())
                {
                    PrintOrders(order, dbContext);
                }
            }
            else if (type == "price")
            {
                foreach (Orders order in dbContext.Orders.Where(x => x.CustomerId == customer_id).Include(x => x.Customer).OrderBy(x => x.PriceTag))
                {
                    PrintOrders(order, dbContext);
                }
            }
            else if (type == "price-r")
            {
                foreach (Orders order in dbContext.Orders.Where(x => x.CustomerId == customer_id).Include(x => x.Customer).OrderBy(x => x.PriceTag).Reverse())
                {
                    PrintOrders(order, dbContext);
                }
            }
            else
            {
                Console.WriteLine("Invalid type. Please try again");
            }
            Console.WriteLine();
        }

        private static void PrintOrders(Orders order, BBearContext dbContext)
        {
            Console.WriteLine($"Customer {order.CustomerId}: {order.Customer.FirstName} {order.Customer.LastName}");
            Console.WriteLine($"Location: {order.LocationId}");
            foreach (SoldBears bear in order.SoldBears)
            {
                int bearcounter = 0;
                Console.WriteLine($"Bear #{bearcounter}:");
                foreach (SoldTraining training in dbContext.SoldTraining.Where(x => x.BearId == bear.BearId).Include(x => x.Product))
                {
                    Console.WriteLine(training.Product.ProductName);
                }


            }
            Console.WriteLine($"Price Paid: ${order.PriceTag})");

        }

        private static Location RetrieveLocation(BBearContext dbContext, int location_id)
        {
            LocationDB location = dbContext.Location.Find(location_id);
            Location newlocation = new Location();
            newlocation.ID = location_id;
            newlocation.Inventory["Bear"].Quantity = location.Inventory.Where(x => x.Product.ProductName == "Bear").First().Quantity;
            foreach (Inventory inv in location.Inventory.Where(x => x.Product.ProductName != "Bear"))
            {
                Training p = new Training(inv.Product.ProductName, Convert.ToDouble(inv.Product.DefPrice));
                newlocation.AddProduct(p, inv.Quantity);
            }

            return newlocation;
        }

        private static void UpdateLocation(BBearContext dbContext, Order order)
        { 
            dbContext.Location.Find(order.LocationID).Inventory.Where(x => x.Product.ProductName == "Bear").First().Quantity--;
            foreach (Bear bear in order.bears)
            {
                foreach (Training t in bear.upgrades)
                {
                    dbContext.Location.Find(order.LocationID).Inventory.Where(x => x.Product.ProductName == t.Name).First().Quantity--;
                }
            }

            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                dbContext.Location.Find(order.LocationID).Inventory.Where(x => x.Product.ProductName == "Bear").First().Quantity++;
                foreach (Bear bear in order.bears)
                {
                    foreach (Training t in bear.upgrades)
                    {
                        dbContext.Location.Find(order.LocationID).Inventory.Where(x => x.Product.ProductName == t.Name).First().Quantity++;
                    }
                }
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddOrder(BBearContext dbContext, Order order)
        { 

            var newOrders = new Orders();
            newOrders.PriceTag = Convert.ToDecimal(order.Price);
            newOrders.LocationId = order.LocationID;
            newOrders.CustomerId = order.CustomerID;
            newOrders.CreatedAt = new DateTime();
            foreach (Bear bear in order.bears)
            {
                SoldBears b = new SoldBears();
                HashSet<SoldTraining> hst = new HashSet<SoldTraining>();
                foreach (Training training in bear.upgrades)
                {

                    SoldTraining st = new SoldTraining();
                    Product p = dbContext.Product.Where(x => x.ProductName == training.Name).First();
                    st.ProductId = p.ProductId;
                    hst.Add(st);
                }
                b.SoldTraining = hst;
                newOrders.SoldBears.Add(b);
            }
            


            dbContext.Add(newOrders);

            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                dbContext.Orders.Remove(newOrders);
                Console.WriteLine(ex.Message);
            }
        }
        private static BBearContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BBearContext>();
            //optionsBuilder
                //.UseSqlServer(SecretConfiguration.ConnectionString)
                //.UseLoggerFactory(AppLoggerFactory);

            return new BBearContext(optionsBuilder.Options);
        }
    }
}
