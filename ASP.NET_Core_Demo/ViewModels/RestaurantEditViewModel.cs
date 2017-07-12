using ASP.NET_Core_Demo.Entities;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Demo.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }

        [Required]
        public CuisineType Cuisine { get; set; }
    }
}
