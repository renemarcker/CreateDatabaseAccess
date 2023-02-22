using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook_SqlClient.Models
{
    public class CustomerGenre
    {
        private string _customerFirstName;
        private string _customerLastName;
        private List<string> _favoriteGenres = new List<string>();

        public string CustomerFirstName { get => _customerFirstName; set => _customerFirstName = value; }
        public string CustomerLastName { get => _customerLastName; set => _customerLastName = value; }
        public List<string> FavoriteGenres { get => _favoriteGenres; set => _favoriteGenres = value; }
    }
}
