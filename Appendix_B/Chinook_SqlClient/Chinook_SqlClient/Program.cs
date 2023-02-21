using Chinook_SqlClient.Models;
using Chinook_SqlClient.Repositories;

namespace Chinook_SqlClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository();
            TestSelectAll(repository);
            //TestSelect(repository);
        }

        static void TestSelectAll(ICustomerRepository repository) 
        { 
            //PrintCustomers(repository.GetAllCustomers());
            PrintCustomers(repository.GetMinCustomers("-1","100"));
        }

        static void TestSelect(ICustomerRepository repository) 
        {
            PrintCustomer(repository.GetCustomer("2"));
            PrintCustomer(repository.GetCustomer("Luís", "Gonçalves"));
        }

        static void TestInsert(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                FirstName = "Thomas",
                LastName = "",
                Country = "",
                PostalCode = "12345",
                Phone = "122152345124",
                Email= "12345@gmail.com",
            };
            if (repository.AddNewCustomer(test)) 
            {
                Console.WriteLine("Yay, insert worked");
            } else
            {
                Console.WriteLine("BOOO!!");
            }
        }

        static void TestUpdate(ICustomerRepository repository) 
        { 

        }

        static void PrintCustomers(IEnumerable<Customer> customers) 
        {
            int count = 0;

            
            foreach (Customer customer in customers) 
            {
                PrintCustomer(customer);
                count++;
         
            }
            Console.WriteLine("Count: " +count);
        }

        static void PrintCustomer(Customer customer) 
        { 
            Console.WriteLine($"--- " +
                $"{customer.CustomerId} - " +
                $"{customer.FirstName}, {customer.LastName} - " +
                $"{customer.Country}, {customer.PostalCode} - " +
                $"{customer.Phone}, {customer.Email}");
        }

    }
}