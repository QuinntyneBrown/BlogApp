using System.Web.Mvc;

namespace MetricsDrivenDevelopment.Frontend.Controllers
{
    public class ArticleController : Controller
    {
        public ActionResult GetBySlug(string slug)
        {
            return View("Index");
        }
    }
}