using MyBlogApp.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyBlogApp.MSSQL.DataAccess.EntityFramework.Concrete.Mapping
{
    public class MakaleMap
        : EntityTypeConfiguration<Makale>
    {
        public MakaleMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Baslik).HasMaxLength(500);
            Property(x => x.Foto).HasMaxLength(500);

            ToTable("Makale");

        }
    }
}
