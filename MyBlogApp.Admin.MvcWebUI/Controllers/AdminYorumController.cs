using MyBlogApp.Entities.Concrete;
using MyBlogApp.Interfaces;
using System.Web.Mvc;

namespace MyBlogApp.Admin.MvcWebUI.Controllers
{
    public class AdminYorumController
        : BaseController
    {
        private readonly IYorumService _yorumService;
        private readonly IMakaleService _makaleService;
        private readonly IUyeService _uyeService;
        public AdminYorumController(IYorumService yorumService,
            IMakaleService makaleService,
            IUyeService uyeService)
        {
            _yorumService = yorumService;
            _makaleService = makaleService;
            _uyeService = uyeService;
        }

        public ActionResult Index()
        {
            var yorumlar = _yorumService.GetAll(true);
            return View(yorumlar);
        }

        public ActionResult Details(int id)
        {
            Yorum yorum = _yorumService.Get(id, true);
            return View(yorum);
        }

        public ActionResult Create()
        {
            ViewBag.MakaleId = new SelectList(_makaleService.GetMakaleSelectList(), "MakaleId", "Baslik");
            ViewBag.UyeId = new SelectList(_uyeService.GetUyeSelectList(), "UyeId", "KullaniciAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YorumId,Icerik,UyeId,MakaleId,Tarih")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _yorumService.Add(yorum);
                return RedirectToAction("Index");
            }

            ViewBag.MakaleId = new SelectList(_makaleService.GetMakaleSelectList(), "MakaleId", "Baslik", yorum.MakaleID);
            ViewBag.UyeId = new SelectList(_uyeService.GetUyeSelectList(), "UyeId", "KullaniciAdi", yorum.UyeID);
            return View(yorum);
        }

        public ActionResult Edit(int id)
        {
            Yorum yorum = _yorumService.Get(id, true);
            ViewBag.MakaleId = new SelectList(_makaleService.GetMakaleSelectList(), "MakaleId", "Baslik", yorum.MakaleID);
            ViewBag.UyeId = new SelectList(_uyeService.GetUyeSelectList(), "UyeId", "KullaniciAdi", yorum.UyeID);
            return View(yorum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YorumId,Icerik,UyeId,MakaleId,Tarih")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _yorumService.Update(yorum);
                return RedirectToAction("Index");
            }
            ViewBag.MakaleId = new SelectList(_makaleService.GetMakaleSelectList(), "MakaleId", "Baslik", yorum.MakaleID);
            ViewBag.UyeId = new SelectList(_uyeService.GetUyeSelectList(), "UyeId", "KullaniciAdi", yorum.UyeID);
            return View(yorum);
        }

        public ActionResult Delete(int id)
        {
            Yorum yorum = _yorumService.Get(id, true);
            return View(yorum);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yorum yorum = _yorumService.Get(id, true);
            _yorumService.Delete(yorum);
            return RedirectToAction("Index");
        }
    }
}