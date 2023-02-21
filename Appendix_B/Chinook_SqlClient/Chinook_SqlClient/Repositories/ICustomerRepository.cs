using Chinook_SqlClient.Models;

namespace Chinook_SqlClient.Repositories
{
    //CRUD implementation
    public interface ICustomerRepository
    {
        public bool AddNewCustomer(Customer customer); //C
        public void AddCustomer(string firstName, string lastName, string country, string postalCode, string phone, string email);
        public Customer GetCustomer(string id);
        public Customer GetCustomer(string firstName, string lastName);

        public List<Customer> GetAllCustomers(); //R
        public List<Customer> GetOffsetLimitCustomers(string offset, string limit); //R

        public bool UpdateCustomer(Customer customer); //U  

        public bool DeleteCustomer(string id); //D
    }
}
