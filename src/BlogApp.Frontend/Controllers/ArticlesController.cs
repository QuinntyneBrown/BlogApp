using BlogApp.Frontend.ApiModels;
using BlogApp.Frontend.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogApp.Frontend.Controllers
{
    public class ArticlesController : Controller
    {
        protected readonly HttpClient _client;
        protected readonly IAppConfiguration _appConfiguration;

        public ArticlesController(IAppConfiguration appConfiguration, HttpClient client)
        {
            _appConfiguration = appConfiguration;
            _client = client;            
        }

        public async Task<ActionResult> GetBySlug(string slug)
        {
            var httpResponse = await _client.GetAsync($"{_appConfiguration.BlogBaseUrl}api/article/getbyslug?slug={slug}");
            var response = await httpResponse.Content.ReadAsAsync<GetBySlugQueryResponse>();
            ViewBag.Title = $"{_appConfiguration.Title}: {response.Article.Title}";
            ViewBag.Description = response.Article.Description;
            ViewBag.ImageUrl = response.Article.FeaturedImageUrl;            
            ViewBag.FileUder = response.Article.Tags.Count() > 0 ? response.Article.Tags.Select(x=>x.Name).Aggregate((i,j) => i + "," + j): "";
            ViewBag.Author = $"{response.Article.Author.Firstname} {response.Article.Author.Lastname}";
            return View("Index");
        }

        public async Task<ActionResult> GetPreviewBySlug(string slug)
        {
            var httpResponse = await _client.GetAsync($"{_appConfiguration.BlogBaseUrl}api/article/getpreviewbyslug?slug={slug}");
            var response = await httpResponse.Content.ReadAsAsync<GetBySlugQueryResponse>();
            ViewBag.Title = $"{_appConfiguration.Title}: {response.Article.Title}";
            ViewBag.Description = response.Article.Description;
            ViewBag.ImageUrl = response.Article.FeaturedImageUrl;
            ViewBag.FileUder = response.Article.Tags.Count() > 0 ? response.Article.Tags.Select(x => x.Name).Aggregate((i, j) => i + "," + j) : "";
            ViewBag.Author = $"{response.Article.Author.Firstname} {response.Article.Author.Lastname}";
            return View("Index");
        }

        public ActionResult Index() {
            ViewBag.Title = _appConfiguration.Title;
            ViewBag.Description = _appConfiguration.Title;
            ViewBag.ImageUrl = "https://quinntynebrown.blob.core.windows.net/4204672e-f64a-4edb-8e5c-01c79b7bcb70/headshot_square.png";
            ViewBag.FileUder = "";
            ViewBag.Author = "Quinntyne Brown";
            return View("Index"); }
    }
}