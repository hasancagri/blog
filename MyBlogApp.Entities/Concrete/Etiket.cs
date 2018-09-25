using MyBlogApp.Core.Entities.Abstract;
using MyBlogApp.Core.Entities.Concrete;
using System.Collections.Generic;

namespace MyBlogApp.Entities.Concrete
{
    public class Etiket
        : BaseEntity<int>, IEntity
    {
        public Etiket()
        {
            Makaleler = new HashSet<Makale>();
        }

        public string EtiketAdi { get; set; }
        public virtual ICollection<Makale> Makaleler { get; set; }
    }
}