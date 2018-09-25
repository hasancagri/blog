using MyBlogApp.Entities.Concrete;
using MyBlogApp.Interfaces;
using System.Web.Mvc;

namespace MyBlogApp.Admin.MvcWebUI.Controllers
{
    public class AdminUyeController
        : BaseController
    {
        private readonly IUyeService _uyeService;
        private readonly IYetkiService _yetkiService;
        public AdminUyeController(IUyeService uyeService, IYetkiService yetkiService)
        {
            _uyeService = uyeService;
            _yetkiService = yetkiService;
        }

        public ActionResult Index()
        {
            var uyeList = _uyeService.GetAll(true);
            return View(uyeList);
        }

        public ActionResult Details(int id)
        {
            Uye uye = _uyeService.Get(id, true);
            return View(uye);
        }

        public ActionResult Create()
        {
            ViewBag.YetkiId = new SelectList(_uyeService.GetUyeSelectList(), "YetkiId", "YetkiAdi");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KullaniciAdi,Email,Sifre,AdSoyad,YetkiID")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                _uyeService.Add(uye);
                return RedirectToAction("Index");
            }

            ViewBag.YetkiId = new SelectList(_yetkiService.GetYetkiSelectList(), "YetkiId", "YetkiAdi", uye.YetkiId);
            return View(uye);
        }

        public ActionResult Edit(int id)
        {
            Uye uye = _uyeService.Get(id, true);
            ViewBag.YetkiId = new SelectList(_yetkiService.GetYetkiSelectList(), "YetkiId", "YetkiAdi", uye.YetkiId);
            return View(uye);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UyeId,KullaniciAdi,Email,Sifre,AdSoyad,YetkiId")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                _uyeService.Update(uye);
                return RedirectToAction("Index");
            }
            ViewBag.YetkiId = new SelectList(_yetkiService.GetYetkiSelectList(), "YetkiId", "YetkiAdi", uye.YetkiId);
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
            Uye uye = _uyeService.Get(id, false);
            _uyeService.Delete(uye);
            return RedirectToAction("Index");
        }
    }
}