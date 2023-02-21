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
        public bool AddNewCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(string id)
        {
            throw new NotImplementedException();
        }

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
        public List<Customer> GetOffsetLimitCustomers(string offset, string limit)
        {
            //CustomerId,
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, ISNULL(PostalCode,''), ISNULL(Phone,''), Email FROM Customer WHERE CustomerId BETWEEN @min AND @max ";
            try
            {

                //connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@min", offset);
                        cmd.Parameters.AddWithValue("@max", limit);
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
        public Customer GetCustomer(string firstName, string lastName)
        {

            Customer temp = new Customer();
            //string sql = "SELECT CustomerId, FirstName, LastName, Country, ISNULL(PostalCode,'') AS PostalCode, ISNULL(Phone,'') AS Phone, Email FROM Customer " +
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
    }
}
