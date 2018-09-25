using MyBlogApp.Entities.Concrete;
using MyBlogApp.Interfaces;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MyBlogApp.MvcWebUI.Controllers
{
    public class YorumController
        : BaseController
    {
        private readonly IYorumService _yorumService;
        private readonly IMakaleService _makaleService;
        private readonly IUyeService _uyeService;
        public YorumController(IYorumService yorumService,
            IMakaleService makaleService,
            IUyeService uyeService)
        {
            _yorumService = yorumService;
            _makaleService = makaleService;
            _uyeService = uyeService;
        }

        public ActionResult Index()
        {
            //Burada daha sonra değişiklik yap
            var yorumList = _yorumService.GetAll(isInclude: true);
            return View(yorumList);
        }

        public ActionResult Details(int id)
        {
            var yorum = _yorumService.Get(id, true);
            //Burada daha sonra değişiklik yap
            return View(yorum);
        }

        public ActionResult Create()
        {
            ViewBag.MakaleId = new SelectList(_makaleService.GetMakaleSelectList(), "MakaleId", "Baslik");
            ViewBag.UyeId = new SelectList(_uyeService.GetUyeSelectList(), "UyeId", "KullaniciAdi");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Icerik,UyeId,MakaleId,Tarih")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _yorumService.Add(yorum);
                return RedirectToAction("Index");
            }
            ViewBag.MakaleId = new SelectList(_makaleService.GetMakaleSelectList(), "MakaleId", "Baslik");
            ViewBag.UyeId = new SelectList(_uyeService.GetUyeSelectList(), "UyeId", "KullaniciAdi");
            return View(yorum);
        }


        public ActionResult Edit(int id)
        {
            var yorum = _yorumService.Get(id, true);
            ViewBag.MakaleId = new SelectList(_makaleService.GetMakaleSelectList(), "MakaleId", "Baslik");
            ViewBag.UyeId = new SelectList(_uyeService.GetUyeSelectList(), "UyeId", "KullaniciAdi");
            return View(yorum);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Icerik,UyeId,MakaleId,Tarih")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _yorumService.Update(yorum);
                return RedirectToAction("Index");
            }
            ViewBag.MakaleId = new SelectList(_makaleService.GetMakaleSelectList(), "MakaleId", "Baslik");
            ViewBag.UyeId = new SelectList(_uyeService.GetUyeSelectList(), "UyeId", "KullaniciAdi");
            return View(yorum);
        }


        public ActionResult Delete(int id)
        {
            var yorum = _yorumService.Get(id, true);
            return View(yorum);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _yorumService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult SonYorumlar()
        {
            var result = _yorumService.SonYorumlar();
            return View(result);
        }

        public ActionResult YorumSil(int id)
        {
            var uyeid = Session["uyeid"];
            var yorum = _yorumService.Get(id, true);
            //Burada sıkıntı olabilir
            var makale = _makaleService.KategorininMakalesi(yorum.MakaleID.Value).SingleOrDefault();
            if (yorum.UyeID == Convert.ToInt32(uyeid))
            {
                _yorumService.Delete(yorum);
                return RedirectToAction("MakaleDetay", "Makale", new { id = makale.Id });
            }
            else
            {
                return HttpNotFound();
            }
        }

        public JsonResult YorumYap(string yorum, int Makaleid)
        {
            var uyeid = Session["uyeid"];
            if (yorum == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            _yorumService.Add(new Yorum
            {
                Id = Convert.ToInt32(uyeid),
                MakaleID = Makaleid,
                Icerik = yorum,
                Tarih = DateTime.Now
            });

            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}