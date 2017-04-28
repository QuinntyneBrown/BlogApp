using System.Web.Mvc;

namespace MetricsDrivenDevelopment.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Metrics-Driven Development";
            ViewBag.Description = "Metrics-Driven Development";
            ViewBag.ImageUrl = "https://quinntynebrown.blob.core.windows.net/4204672e-f64a-4edb-8e5c-01c79b7bcb70/headshot_square.png";
            ViewBag.FileUder = "";
            ViewBag.Author = "Quinntyne Brown";
            return View();
        }
    }
}