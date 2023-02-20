using Chinook_SqlClient.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    using (SqlCommand cmd = new SqlCommand(sql,conn)) 
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

        public Customer GetCustomer(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
