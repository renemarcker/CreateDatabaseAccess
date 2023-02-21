using Chinook_SqlClient.Models;

namespace Chinook_SqlClient.Repositories
{
    //CRUD implementation
    public interface ICustomerRepository
    {
        public bool AddNewCustomer(Customer customer); //C

        public Customer GetCustomer(string id);
        public Customer GetCustomer(string firstName, string lastName);

        public List<Customer> GetAllCustomers(); //R
        public List<Customer> GetMinCustomers(string min, string max); //R

        public bool UpdateCustomer(Customer customer); //U  

        public bool DeleteCustomer(string id); //D
    }
}
