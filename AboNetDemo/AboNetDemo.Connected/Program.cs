using System;

namespace AboNetDemo.Connected
{
    class Program
    {
        static void Main(string[] args)
        {


            var connectionString = SecretConfiguration.ConnectionString;

            using (var connection = new SqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {

                }
            }
        }
    }
}
