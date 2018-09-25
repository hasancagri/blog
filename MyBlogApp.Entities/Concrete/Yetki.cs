using MyBlogApp.Core.Entities.Abstract;
using MyBlogApp.Core.Entities.Concrete;
using System.Collections.Generic;

namespace MyBlogApp.Entities.Concrete
{
    public class Yetki
        : BaseEntity<int>, IEntity
    {
        public Yetki()
        {
            Uyeler = new List<Uye>();
        }

        public string YetkiAdi { get; set; }
        public ICollection<Uye> Uyeler { get; set; }
    }
}