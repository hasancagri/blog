using MyBlogApp.Entities.Concrete;
using MyBlogApp.Interfaces;
using System.Web.Mvc;

namespace MyBlogApp.MvcWebUI.Controllers
{
    public class UyeController
        : BaseController
    {
        private readonly IUyeService _uyeService;
        private readonly IYetkiService _yetkiService;
        public UyeController(IUyeService uyeService,
            IYetkiService yetkiService)
        {
            _uyeService = uyeService;
            _yetkiService = yetkiService;
        }

        public ActionResult Index()
        {
            var uyeler = _uyeService.GetAll(true);
            return View(uyeler);
        }

        public ActionResult Details(int id)
        {
            var uye = _uyeService.Get(id, false);
            return View(uye);
        }

        public ActionResult Create()
        {
            ViewBag.YetkiId = new SelectList(_yetkiService.GetYetkiSelectList(), "YetkiId", "YetkiAdi");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KullaniciAdi,Email,Sifre,AdSoyad,YetkiId")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                _uyeService.Add(uye);
                return RedirectToAction("Index");
            }

            ViewBag.YetkiId = new SelectList(_yetkiService.GetYetkiSelectList(), "YetkiId", "YetkiAdi");
            return View(uye);
        }

        public ActionResult Edit(int id)
        {
            Uye uye = _uyeService.Get(id, true);
            ViewBag.YetkiId = new SelectList(_yetkiService.GetYetkiSelectList(), "YetkiId", "YetkiAdi");
            return View(uye);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KullaniciAdi,Email,Sifre,AdSoyad,YetkiId")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                _uyeService.Update(uye);
                return RedirectToAction("Index");
            }
            ViewBag.YetkiId = new SelectList(_yetkiService.GetYetkiSelectList(), "YetkiId", "YetkiAdi");
            return View(uye);
        }

        public ActionResult Delete(int id)
        {
            Uye uye = _uyeService.Get(id, true);
            return View(uye);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uye uye = _uyeService.Get(id, true);
            _uyeService.Delete(uye);
            return RedirectToAction("Index");
        }
    }
}