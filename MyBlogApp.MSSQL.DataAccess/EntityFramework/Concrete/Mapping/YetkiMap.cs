using MyBlogApp.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyBlogApp.MSSQL.DataAccess.EntityFramework.Concrete.Mapping
{
    public class YetkiMap
        : EntityTypeConfiguration<Yetki>
    {
        public YetkiMap()
        {
            ToTable("Yetki");
            HasKey(x => x.Id);
            Property(x => x.YetkiAdi).HasMaxLength(50);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
