using BlogApp.Frontend.Configuration;
using System.Web.Mvc;

namespace BlogApp.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IAppConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public ActionResult Index()
        {
            ViewBag.Title = _appConfiguration.Title;
            ViewBag.Description = _appConfiguration.Title;
            ViewBag.ImageUrl = "https://quinntynebrown.blob.core.windows.net/4204672e-f64a-4edb-8e5c-01c79b7bcb70/headshot_square.png";
            ViewBag.FileUder = "";
            ViewBag.Author = "Quinntyne Brown";
            return View();
        }

        protected readonly IAppConfiguration _appConfiguration;
    }
}