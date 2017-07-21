using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.ViewComponents
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
