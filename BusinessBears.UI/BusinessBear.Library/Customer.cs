using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessBear.Library
{
    /// <summary>
    /// A Customer object that records name, order history and default location
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        private string _firstname;
        private string _lastname;

        public string Firstname { get => _firstname; set => _firstname = value; }
        public string Lastname { get => _lastname; set => _lastname = value; }

        //Best to keep  
        int defLocation;

    }
}
