using MyBlogApp.Interfaces;
using System.Web.Mvc;

namespace MyBlogApp.Admin.MvcWebUI.Controllers
{
    public class AdminController
        : BaseController
    {
        private readonly IMakaleService _makaleService;
        private readonly IUyeService _uyeService;
        private readonly IKategoriService _kategoriService;
        private readonly IYorumService _yorumService;

        public AdminController(IMakaleService makaleService,
            IUyeService uyeService,
            IKategoriService kategoriService,
            IYorumService yorumService)
        {
            _makaleService = makaleService;
            _uyeService = uyeService;
            _kategoriService = kategoriService;
            _yorumService = yorumService;
        }

        public ActionResult Index()
        {
            ViewBag.MakaleSayisi = _makaleService.MakaleSayisi();
            ViewBag.YorumSayisi = _yorumService.YorumSayisi();
            ViewBag.KategoriSayisi = _kategoriService.KategoriSayisi();
            ViewBag.UyeSayisi = _uyeService.UyeSayisi();
            return View();
        }
    }
}