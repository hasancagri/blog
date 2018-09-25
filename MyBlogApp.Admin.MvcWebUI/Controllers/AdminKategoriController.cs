using MyBlogApp.Entities.Concrete;
using MyBlogApp.Interfaces;
using System.Web.Mvc;

namespace MyBlogApp.Admin.MvcWebUI.Controllers
{
    public class AdminKategoriController
        : BaseController
    {
        private readonly IKategoriService _kategoriService;
        public AdminKategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        public ActionResult Index()
        {
            var kategoriList = _kategoriService.GetAllKategori(false);
            return View(kategoriList);
        }

        public ActionResult Details(int id)
        {
            Kategori kategori = _kategoriService.Get(id, true);
            return View(kategori);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KategoriAdi")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _kategoriService.Add(kategori);
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        public ActionResult Edit(int id)
        {
            Kategori kategori = _kategoriService.Get(id, true);
            return View(kategori);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KategoriAdi")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _kategoriService.Update(kategori);
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        public ActionResult Delete(int id)
        {
            Kategori kategori = _kategoriService.Get(id, false);
            return View(kategori);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategori kategori = _kategoriService.Get(id, true);
            _kategoriService.Delete(kategori);
            return RedirectToAction("Index");
        }
    }
}