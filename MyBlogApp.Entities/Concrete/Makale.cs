using MyBlogApp.Core.Entities.Abstract;
using MyBlogApp.Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace MyBlogApp.Entities.Concrete
{
    public class Makale
        : BaseEntity<int>, IEntity
    {
        public Makale()
        {
            Yorumlar = new List<Yorum>();
            Etiketler = new HashSet<Etiket>();
        }

        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Foto { get; set; }
        public DateTime? Tarih { get; set; }
        public int? KategoriID { get; set; }
        public int? UyeID { get; set; }
        public int? Okunma { get; set; }
        public Kategori Kategori { get; set; }
        public Uye Uye { get; set; }
        public ICollection<Yorum> Yorumlar { get; set; }
        public ICollection<Etiket> Etiketler { get; set; }
    }
}