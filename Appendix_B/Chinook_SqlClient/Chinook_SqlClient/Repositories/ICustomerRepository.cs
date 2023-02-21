using Chinook_SqlClient.Models;

namespace Chinook_SqlClient.Repositories
{
    //CRUD implementation
    public interface ICustomerRepository
    {
        public void AddCustomer(string firstName, string lastName, string country, string postalCode, string phone, string email); //C
        public Customer GetCustomer(string id);//R
        public Customer GetCustomer(string firstName, string lastName);//R

        public List<Customer> GetAllCustomers(); //R
        public List<CustomerCountry> GetCustomerCountPrCountry(); //R

        public List<Customer> GetOffsetLimitCustomers(string offset, string limit); //R

        public void UpdateCustomer(string idForUpdate, string firstName, string lastName, string country, string postalCode, string phone, string email); //U  

        public bool DeleteCustomer(string id); //D


    }
}
