using MyBlogApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogApp.MvcWebUI.Controllers
{
    public class KategoriController
        : BaseController
    {
        private readonly IKategoriService _kategoriService;
        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        public ActionResult KategoriPartial()
        {
            var result = _kategoriService.GetAllKategori(true);
            return View(result);
        }
    }
}