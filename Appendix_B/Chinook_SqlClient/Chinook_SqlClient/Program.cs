using Chinook_SqlClient.Models;
using Chinook_SqlClient.Repositories;

namespace Chinook_SqlClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository();
         //Simply uncomment following methods if you want to test.
            //TestSelectAll(repository);
            //TestSelectAllByOffsetLimit(repository);
            //TestSelectByID(repository);
            //TestSelectByID(repository);
            //TestSelectByName(repository);
            //TestInsert(repository);
            //TestSelect(repository);
            //TestUpdate(repository);
            //TestGetCustomerCountPrCountry(repository);
            //TestGetHighestSpenderCustomer(repository);
            //TestGetCustomerMostPopularGenre(repository);
        }

        // The following methods are for testing the Customer repository and its database features
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
        
        static void TestGetHighestSpenderCustomer(ICustomerRepository repository)
        {
            List<CustomerSpender> testCustomerByTotalSpent = new List<CustomerSpender>();
            testCustomerByTotalSpent = repository.GetHighestSpenderCustomer();
            
            // lets write out the list to see the customers ordered by their total spending amount
            foreach (CustomerSpender c in testCustomerByTotalSpent)
            {
                Console.WriteLine($"{c.customerId}: {c.customerName} total: {c.spendTotal}");
            }
        }
        
        static void TestGetCustomerMostPopularGenre(ICustomerRepository repository)
        {
            CustomerGenre testCustomerGenre = new CustomerGenre();
            testCustomerGenre = repository.GetCustomerMostPopularGenre("12");

            // lets write out the list to see the customers ordered by their total spending amount
            Console.WriteLine($"{testCustomerGenre.CustomerFirstName} {testCustomerGenre.CustomerLastName}");
            Console.Write("Favorite Genre/Genres: ");
            foreach (string genreName in testCustomerGenre.FavoriteGenres)
            {
                Console.Write($"{genreName}, ");
            }
        }
        static void PrintCustomers(IEnumerable<Customer> customers) 
        {
            foreach (Customer customer in customers) 
            {
                PrintCustomer(customer);
            }
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