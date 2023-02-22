using Chinook_SqlClient.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_SqlClient.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Adds a new customer to Chinook database based on the provided customer details.
        /// </summary>
        /// <param name="firstName">The first name of the customer to be added.</param>
        /// <param name="lastName">The last name of the customer to be added.</param>
        /// <param name="country">The country of the customer to be added.</param>
        /// <param name="postalCode">The postal code of the customer to be added. Can be null.</param>
        /// <param name="phone">The phone number of the customer to be added. Can be null.</param>
        /// <param name="email">The email address of the customer to be added.</param>
        public void AddCustomer(string firstName, string lastName, string country, string postalCode, string phone, string email)
        {
            //CustomerId,
            List<Customer> customerList = new List<Customer>();
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) VALUES (@FirstName, @LastName, @Country, ISNULL(@PostalCode, ''), ISNULL(@Phone, ''), @Email)";

            try
            {

                //connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Country", country);
                        cmd.Parameters.AddWithValue("@PostalCode", postalCode);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                //log error
            }
        }
        /// <summary>
        /// Method that returns all Customers from Chinook Customer table 
        /// </summary>
        /// <returns>returns a list with all existing Customer Model objects</returns>
        public List<Customer> GetAllCustomers()
        {
            //CustomerId,
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT  CustomerId, FirstName, LastName, Country, ISNULL(PostalCode,''), ISNULL(Phone,''), Email FROM Customer";
            try
            {

                //connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {


                            while (reader.Read())
                            {

                                //handle result
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0).ToString();
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4);
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                customerList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                //log error
            }
            return customerList;
        }

        /// <summary>
        /// Retrieves a list of customers from a SQL Server database based on the provided offset and limit parameters.
        /// </summary>
        /// <param name="offset">The starting position of Customers to be returned.</param>
        /// <param name="limit">The maximum number of Customers to be returned.</param>
        /// <returns>A List of 'Customer' objects.</returns>
        public List<Customer> GetOffsetLimitCustomers(string offset, string limit)
        {
            //CustomerId,
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, ISNULL(PostalCode,''), ISNULL(Phone,''), Email FROM Customer WHERE CustomerId BETWEEN @offset AND @limit ";

            try
            {

                //connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        limit = (Int32.Parse(limit) + Int32.Parse(offset)).ToString();

                        cmd.Parameters.AddWithValue("@offset", offset);
                        cmd.Parameters.AddWithValue("@limit", (limit));
                        //reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {


                            while (reader.Read())
                            {

                                //handle result
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0).ToString();
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4);
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                customerList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                //log error
            }
            return customerList;
        }

        /// <summary>
        /// Method for getting Input Id customer 
        /// </summary>
        /// <param name="id">the id for the customer you want returned</param>
        /// <returns>returns a customer model object</returns>
        public Customer GetCustomer(string id)
        {

            Customer temp = new Customer();
            string sql = "SELECT  CustomerId, FirstName, LastName, Country, ISNULL(PostalCode,''), ISNULL(Phone,''), Email FROM Customer WHERE CustomerId = @CustomerId";
            try
            {

                //connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        //reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //handle result
                                temp.CustomerId = reader.GetInt32(0).ToString();
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4);
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                //log error
            }
            return temp;

        }

        /// <summary>
        /// Method for getting the Customer By first name and last name
        /// </summary>
        /// <param name="firstName">the FirstName to compare by</param>
        /// <param name="lastName">the LastName to compare by</param>
        /// <returns></returns>
        public Customer GetCustomer(string firstName, string lastName)
        {

            Customer temp = new Customer();

            string sql = "SELECT CustomerId, FirstName, LastName, Country, ISNULL(PostalCode,'') AS PostalCode, ISNULL(Phone,'') AS Phone, Email FROM Customer " +
                         "WHERE FirstName LIKE @FirstName AND LastName LIKE @LastName";

            try
            {

                //connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //reader
                        cmd.Parameters.AddWithValue("@FirstName", "%" + firstName + "%");
                        cmd.Parameters.AddWithValue("@LastName", "%" + lastName + "%");


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                //handle result
                                temp.CustomerId = reader.GetInt32(0).ToString();
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4);
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                //log error
            }
            return temp;

        }

        /// <summary>
        /// Method that updates the (input id)Customer from Customer table from Chinook database with input variables.
        /// </summary>
        /// <param name="idForUpdate">the customer id for the customer you want updated</param>
        /// <param name="firstName">the update for firstName</param>
        /// <param name="lastName">the update for lastName</param>
        /// <param name="country">the update for country</param>
        /// <param name="postalCode">the update for postalCode</param>
        /// <param name="phone">the update for phone</param>
        /// <param name="email">the update for email</param>
        public void UpdateCustomer(string idForUpdate, string firstName, string lastName, string country, string postalCode, string phone, string email)
        {

            //CustomerId,
            List<Customer> customerList = new List<Customer>();

            string sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = ISNULL(@PostalCode, ''), Phone = ISNULL(@Phone, ''), Email = @Email Where CustomerId = @idForUpdate";

            try
            {

                //connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idForUpdate", idForUpdate);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Country", country);
                        cmd.Parameters.AddWithValue("@PostalCode", postalCode);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                //log error
            }

        }

        /// <summary>
        /// Method for getting a counter of customers pr country in descending order 
        /// </summary>
        /// <returns>returns a list of customerCountry model object with customer count and country name </returns>
        public List<CustomerCountry> GetCustomerCountPrCountry()
        {
            //CustomerId,
            List<CustomerCountry> customerPrCountryList = new List<CustomerCountry>();

            string sql = "SELECT COUNT(CustomerId), Country FROM CUSTOMER GROUP BY Country ORDER BY COUNT(CustomerId) DESC";
            try
            {

                //connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //handle result
                                CustomerCountry temp = new CustomerCountry();
                                temp.count = reader.GetInt32(0).ToString();
                                temp.country = reader.GetString(1).ToString();

                                customerPrCountryList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                //log error
            }
            return customerPrCountryList;
        }

        /// <summary>
        /// Method that returns the customers sorted by highest spender 
        /// </summary>
        /// <returns>a list of all customers sorted by highest spender first</returns>
        public List<CustomerSpender> GetHighestSpenderCustomer()
        {

            //CustomerId,
            List<CustomerSpender> customerPrCountryList = new List<CustomerSpender>();

            string sql = "SELECT Customer.CustomerId, Customer.FirstName, SUM(Invoice.Total) FROM Customer, Invoice WHERE Customer.CustomerId = Invoice.CustomerId GROUP BY CUSTOMER.CustomerId, Customer.FirstName ORDER BY SUM(Invoice.Total) DESC";
            try
            {

                //connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //handle result
                                CustomerSpender temp = new CustomerSpender();
                                temp.customerId = reader.GetInt32(0).ToString();
                                temp.customerName = reader.GetString(1);
                                temp.spendTotal = reader.GetDecimal(2).ToString();

                                customerPrCountryList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                //log error
            }
            return customerPrCountryList;
        }

        /// <summary>
        /// Method for getting input ID customers favorite genre or Genres if there are more with equal occurance.
        /// </summary>
        /// <param name="customerId">the ID of the customer you want favorite genre from</param>
        /// <returns>Returns a CustomerGenre Model Object with firstname lastname and a list of favourite genres </returns>
        public CustomerGenre GetCustomerMostPopularGenre(string customerId)
        {
            //CustomerId,
            CustomerGenre customerGenre = new CustomerGenre();

            string sql = "WITH GenreCounts AS (" +
                "SELECT c.FirstName, c.LastName, t.GenreId, COUNT(*) as Count " +
                "FROM Invoice i, InvoiceLine il, Track t, Customer c " +
                "WHERE i.InvoiceId = il.InvoiceId " +
                "AND il.TrackId = t.TrackId " +
                "AND i.CustomerId = c.CustomerId " +
                "AND i.CustomerId = @customerId " +
                "GROUP BY c.FirstName, c.LastName, t.GenreId" +
                ") " +
                "SELECT FirstName, LastName, (SELECT Name FROM Genre WHERE GenreId = GenreCounts.GenreId) AS GenreName " +
                "FROM GenreCounts " +
                "WHERE Count = (SELECT MAX(Count) FROM GenreCounts);";
            try
            {
                //connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //handle result

                                customerGenre.CustomerFirstName = reader.GetString(0);
                                customerGenre.CustomerLastName = reader.GetString(1);
                                customerGenre.FavoriteGenres.Add(reader.GetString(2));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                //log error
            }
            return customerGenre;
        }
    }
}
