using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDemo.Entities

{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        [Display(Name="Restaurant Name")]
        public string Name { get; set; }

        [Required]
        public CuisineType Cuisine { get; set; }
    }

    public enum CuisineType
    {
        None,
        Steak,
        Pizza,
        Garbage,
        Thai
    }
}
