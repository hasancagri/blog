using MyBlogApp.Core.Entities.Abstract;
using MyBlogApp.Core.Entities.Concrete;
using System.Collections.Generic;

namespace MyBlogApp.Entities.Concrete
{
    public class Kategori
        : BaseEntity<int>, IEntity
    {
        public Kategori()
        {
            Makaleler = new List<Makale>();
        }

        public string KategoriAdi { get; set; }
        public virtual ICollection<Makale> Makaleler { get; set; }
    }
}