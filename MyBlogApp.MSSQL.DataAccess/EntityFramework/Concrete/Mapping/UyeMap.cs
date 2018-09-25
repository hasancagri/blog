using MyBlogApp.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyBlogApp.MSSQL.DataAccess.EntityFramework.Concrete.Mapping
{
    public class UyeMap
        : EntityTypeConfiguration<Uye>
    {
        public UyeMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.KullaniciAdi).HasMaxLength(50);
            Property(x => x.Email).HasMaxLength(50);
            Property(x => x.Sifre).HasMaxLength(50);
            Property(x => x.AdSoyad).HasMaxLength(50);
            Property(x => x.Foto).HasMaxLength(50);
            ToTable("Uye");
        }
    }
}
