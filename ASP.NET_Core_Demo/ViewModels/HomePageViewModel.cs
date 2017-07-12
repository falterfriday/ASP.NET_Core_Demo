using AspNetCoreDemo.Entities;
using System.Collections.Generic;

namespace AspNetCoreDemo.ViewModels
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
