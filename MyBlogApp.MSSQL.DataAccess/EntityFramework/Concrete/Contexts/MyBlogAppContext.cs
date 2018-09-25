using MyBlogApp.Entities.Concrete;
using MyBlogApp.MSSQL.DataAccess.EntityFramework.Concrete.Mapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyBlogApp.MSSQL.DataAccess.EntityFramework.Concrete.Contexts
{
    public class MyBlogAppContext
        : DbContext
    {
        public DbSet<Etiket> Etiketler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Makale> Makaleler { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Yetki> Yetkiler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new EtiketMap());
            modelBuilder.Configurations.Add(new UyeMap());
            modelBuilder.Configurations.Add(new YetkiMap());
            modelBuilder.Configurations.Add(new MakaleMap());
            modelBuilder.Configurations.Add(new KategoriMap());
            modelBuilder.Configurations.Add(new YorumMap());

            modelBuilder.Entity<Etiket>()
               .HasMany(e => e.Makaleler)
               .WithMany(e => e.Etiketler)
               .Map(m => m.ToTable("MakaleEtiket").MapLeftKey("EtiketID").MapRightKey("MakaleID"));
        }
    }
}
