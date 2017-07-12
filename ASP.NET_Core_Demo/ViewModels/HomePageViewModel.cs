using ASP.NET_Core_Demo.Entities;
using System.Collections.Generic;

namespace ASP.NET_Core_Demo.ViewModels
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
