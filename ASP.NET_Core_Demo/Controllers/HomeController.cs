using ASP.NET_Core_Demo.Entities;
using ASP.NET_Core_Demo.Services;
using ASP.NET_Core_Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Demo.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();

            //var model = _restaurantData.GetAll();

            //var model = new Restaurant { Id = 1, Name = "House of Food" };

            //return Content("This is from the IAction method/action");

            //serializes response into json and returns back to view
            //return new ObjectResult(model);

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
            var newRestaurant = new Restaurant();
            newRestaurant.Name = model.Name;
            newRestaurant.Cuisine = model.Cuisine;

            _restaurantData.Add(newRestaurant);


            //return View("Details", newRestaurant);
            return RedirectToAction("Details", new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }

        }


        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        //public string Index()
        //{
        //    return "Hello!\nYou're in the HomeController\nWELCOME!!!";
        //}
    }
}
 