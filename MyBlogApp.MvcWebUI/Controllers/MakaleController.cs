using MyBlogApp.Interfaces;
using System.Web.Mvc;
using PagedList;

namespace MyBlogApp.MvcWebUI.Controllers
{
    public class MakaleController
        : BaseController
    {

        private readonly IMakaleService _makaleService;
        public MakaleController(IMakaleService makaleService)
        {
            _makaleService = makaleService;
        }

        public ActionResult Index(int Page = 1)
        {
            //Burayı daha sonra değiştir
            var result = _makaleService.GetAll(true).ToPagedList(Page, 3);
            return View(result);
        }

        public ActionResult BlogAra(string ara = null)
        {
            var result = _makaleService.BlogAra(ara);
            return View(result);
        }

        public ActionResult PopulerMakaleler()
        {
            var result = _makaleService.PopulerMakaleler();
            return View(result);
        }

        public ActionResult KategorininMakalesi(int kategoriId)
        {
            var result = _makaleService.KategorininMakalesi(kategoriId);
            return View(result);
        }

        public ActionResult MakaleDetay(int id)
        {
            var result = _makaleService.GetMakale(id, true);
            return View(result);
        }

        public ActionResult OkunmaArttir(int makaleId)
        {
            _makaleService.OkunmaArttir(makaleId);
            return View();
        }
    }
}