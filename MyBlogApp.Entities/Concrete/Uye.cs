using MyBlogApp.Core.Entities.Abstract;
using MyBlogApp.Core.Entities.Concrete;
using System.Collections.Generic;

namespace MyBlogApp.Entities.Concrete
{
    public class Uye
        : BaseEntity<int>, IEntity
    {
        public Uye()
        {
            Makaleler = new HashSet<Makale>();
            Yorumlar = new List<Yorum>();
        }

        public string KullaniciAdi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string AdSoyad { get; set; }
        public string Foto { get; set; }
        public int? YetkiId { get; set; }
        public ICollection<Makale> Makaleler { get; set; }
        public Yetki Yetki { get; set; }
        public ICollection<Yorum> Yorumlar { get; set; }
    }
}