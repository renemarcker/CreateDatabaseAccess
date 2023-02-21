using Chinook_SqlClient.Models;
using Chinook_SqlClient.Repositories;

namespace Chinook_SqlClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository();
            //TestSelectAll(repository);
            //TestSelectAllByOffsetLimit(repository);
            //TestSelectByID(repository);
            //TestSelectByID(repository);
            //TestSelectByName(repository);
            //TestInsert(repository);
            //TestSelect(repository);
        }

        static void TestSelectAll(ICustomerRepository repository) 
        { 
            PrintCustomers(repository.GetAllCustomers());
            
        }
        static void TestSelectAllByOffsetLimit(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetOffsetLimitCustomers("10", "20"));
        }
        static void TestSelectByID(ICustomerRepository repository) 
        {
            PrintCustomer(repository.GetCustomer("2"));
        }
        static void TestSelectByName(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer("Luís", "Gonçalves"));
        }
        static void TestInsert(ICustomerRepository repository)
        {
            repository.AddCustomer("Thomas", "Osterhammel", "Denmark", "1337", "112", "thomasIsCool@HotThomas.dk");
            //Customer test = new Customer()
            //{
            //    FirstName = "Thomas",
            //    LastName = "",
            //    Country = "",
            //    PostalCode = "12345",
            //    Phone = "122152345124",
            //    Email= "12345@gmail.com",
            //};
            //if (repository.AddNewCustomer(test)) 
            //{
            //    Console.WriteLine("Yay, insert worked");
            //} else
            //{
            //    Console.WriteLine("BOOO!!");
            //}
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