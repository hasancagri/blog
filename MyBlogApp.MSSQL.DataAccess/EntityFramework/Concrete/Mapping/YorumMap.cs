using MyBlogApp.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyBlogApp.MSSQL.DataAccess.EntityFramework.Concrete.Mapping
{
    public class YorumMap
        : EntityTypeConfiguration<Yorum>
    {
        public YorumMap()
        {
            ToTable("Yorum");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Icerik).HasMaxLength(500);
        }
    }
}
