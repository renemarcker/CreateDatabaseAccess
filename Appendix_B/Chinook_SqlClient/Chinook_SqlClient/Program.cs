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
            //TestUpdate(repository);
            TestGetCustomerCountPrCountry(repository);
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
            repository.AddCustomer("Michael", "PieGras", "Somalia", "667", "1337", "Michael@Piratemail.com");
        }

        static void TestUpdate(ICustomerRepository repository)
        {
            repository.UpdateCustomer("1", "Rene", "Marcker", "Antarctic", "1337", "112", "reneIsCold@PenguinMail.AC");
        }
        static void TestGetCustomerCountPrCountry(ICustomerRepository repository)
        {
            List<CustomerCountry> testCustomerByCountryList = new List<CustomerCountry>();
            testCustomerByCountryList = repository.GetCustomerCountPrCountry();
            foreach (CustomerCountry c in testCustomerByCountryList)
            {
                Console.WriteLine($"{c.country}: {c.count}");
            }
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