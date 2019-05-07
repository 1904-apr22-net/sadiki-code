using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessBears.Library
{
    /// <summary>
    /// A Customer object that records name, order history, last order time and default location
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        private string _firstname;
        private string _lastname;

        public string Firstname { get => _firstname; set => _firstname = value; }
        public string Lastname { get => _lastname; set => _lastname = value; }

        int defLocation;
        DateTime LastOrder;

        public bool OrderLimit(DateTime d)
        {
            
            if (d.Subtract(LastOrder) < new TimeSpan(2,0,0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CustomerDetails() {
            Console.WriteLine($"{this.Id}: {this.Firstname} {this.Lastname}");
        }


        public Customer (int i, string fn, string ln, DateTime? dt)
        {
            this.Id = i;
            this.Firstname = fn;
            this.Lastname = ln;
            this.LastOrder = dt ?? new DateTime();

        }

        public Customer()
        {
        }
    }
}
