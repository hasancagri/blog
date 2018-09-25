using MyBlogApp.Interfaces;
using System.Web.Mvc;

namespace MyBlogApp.MvcWebUI.Controllers
{
    public class YetkiController
        : BaseController
    {
        private readonly IYetkiService _yetkiService;
        public YetkiController(IYetkiService yetkiService)
        {
            _yetkiService = yetkiService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}