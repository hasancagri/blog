using MyBlogApp.Core.Entities.Abstract;
using MyBlogApp.Core.Entities.Concrete;
using System;

namespace MyBlogApp.Entities.Concrete
{
    public class Yorum
          : BaseEntity<int>, IEntity
    {
        public Yorum()
        {
            Tarih = DateTime.Now;
        }

        public string Icerik { get; set; }
        public int? UyeID { get; set; }
        public int? MakaleID { get; set; }
        public DateTime? Tarih { get; set; }
        public Makale Makale { get; set; }
        public Uye Uye { get; set; }
    }
}
