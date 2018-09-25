using MyBlogApp.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyBlogApp.MSSQL.DataAccess.EntityFramework.Concrete.Mapping
{
    public class EtiketMap
        : EntityTypeConfiguration<Etiket>
    {
        public EtiketMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.EtiketAdi).HasMaxLength(50);
            ToTable("Etiket");
        }
    }
}
