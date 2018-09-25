using MyBlogApp.Entities.Concrete;
using MyBlogApp.Interfaces;
using PagedList;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MyBlogApp.Admin.MvcWebUI.Controllers
{
    public class AdminMakaleController
        : BaseController
    {
        private readonly IMakaleService _makaleService;
        private readonly IKategoriService _kategoriService;
        private readonly IEtiketService _etiketService;
        private readonly IYorumService _yorumService;
        public AdminMakaleController(IMakaleService makaleService,
            IKategoriService kategoriService,
            IEtiketService etiketService,
            IYorumService yorumService)
        {
            _makaleService = makaleService;
            _kategoriService = kategoriService;
            _etiketService = etiketService;
            _yorumService = yorumService;
        }

        public ActionResult Index(int Page = 1)
        {
            //Burayı daha sonra değiştir
            var result = _makaleService.GetAll(true).ToPagedList(Page, 3);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(_kategoriService.GetKategoriSelectList(), "KategoriId", "KategoriAdi");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Makale makale, string etiketler, HttpPostedFileBase Foto)
        {
            //Burada business tarafında validation olacak
            //if (ModelState.IsValid)
            //{
            if (Foto != null)
            {
                WebImage img = new WebImage(Foto.InputStream);
                FileInfo fotoinfo = new FileInfo(Foto.FileName);

                string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                img.Resize(800, 350);
                img.Save("~/Uploads/MakaleFoto/" + newfoto);
                makale.Foto = "/Uploads/MakaleFoto/" + newfoto;
            }
            if (etiketler != null)
            {
                string[] etiketdizi = etiketler.Split(',');
                foreach (var i in etiketdizi)
                {
                    var yeniEtiket = new Etiket { EtiketAdi = i };

                    _etiketService.Add(yeniEtiket);
                    makale.Etiketler.Add(yeniEtiket);
                }
            }

            makale.UyeID = Convert.ToInt32(Session["uyeid"]);
            makale.Okunma = 1;
            _makaleService.Update(makale);
            return RedirectToAction("Index");
            //}
            //return View(makale);
        }

        public ActionResult Edit(int id)
        {
            var makale = _makaleService.GetMakale(id, true);
            ViewBag.KategoriId = new SelectList(_kategoriService.GetKategoriSelectList(), "KategoriId", "KategoriAdi", makale.KategoriID);
            return View(makale);
        }

        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase Foto, Makale makale)
        {
            try
            {
                var updatedMakale = _makaleService.GetMakale(id);
                if (Foto != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(updatedMakale.Foto)))
                    {
                        System.IO.File.Delete(Server.MapPath(updatedMakale.Foto));
                    }
                    WebImage img = new WebImage(Foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(Foto.FileName);

                    string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 350);
                    img.Save("~/Uploads/MakaleFoto/" + newfoto);
                    updatedMakale.Foto = "/Uploads/MakaleFoto/" + newfoto;
                    updatedMakale.Baslik = makale.Baslik;
                    updatedMakale.Icerik = makale.Icerik;
                    updatedMakale.KategoriID = makale.KategoriID;

                    _makaleService.Update(updatedMakale);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                ViewBag.KategoriId = new SelectList(_kategoriService.GetKategoriSelectList(), "KategoriId", "KategoriAdi", makale.KategoriID);
                return View(makale);
            }
        }

        public ActionResult Delete(int id)
        {
            var makale = _makaleService.GetMakale(id, true);
            return View(makale);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var makale = _makaleService.GetMakale(id);
                if (makale == null)
                {
                    return HttpNotFound();
                }
                if (System.IO.File.Exists(Server.MapPath(makale.Foto)))
                {
                    System.IO.File.Delete(Server.MapPath(makale.Foto));
                }
                foreach (var i in makale.Yorumlar.ToList())
                {
                    _yorumService.Delete(i);
                }
                foreach (var i in makale.Etiketler.ToList())
                {
                    _etiketService.Delete(i);
                }

                _makaleService.Delete(makale);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}