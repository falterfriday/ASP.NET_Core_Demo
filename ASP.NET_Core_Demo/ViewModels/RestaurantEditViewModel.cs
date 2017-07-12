using AspNetCoreDemo.Entities;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDemo.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }

        [Required]
        public CuisineType Cuisine { get; set; }
    }
}
