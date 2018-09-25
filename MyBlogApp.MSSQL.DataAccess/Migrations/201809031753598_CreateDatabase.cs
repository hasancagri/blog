namespace MyBlogApp.MSSQL.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etiket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EtiketAdi = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Makale",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 500),
                        Icerik = c.String(),
                        Foto = c.String(maxLength: 500),
                        Tarih = c.DateTime(),
                        KategoriID = c.Int(),
                        UyeID = c.Int(),
                        Okunma = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategori", t => t.KategoriID)
                .ForeignKey("dbo.Uye", t => t.UyeID)
                .Index(t => t.KategoriID)
                .Index(t => t.UyeID);
            
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Uye",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Sifre = c.String(maxLength: 50),
                        AdSoyad = c.String(maxLength: 50),
                        Foto = c.String(maxLength: 50),
                        YetkiId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Yetki", t => t.YetkiId)
                .Index(t => t.YetkiId);
            
            CreateTable(
                "dbo.Yetki",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YetkiAdi = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Yorum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icerik = c.String(maxLength: 500),
                        UyeID = c.Int(),
                        MakaleID = c.Int(),
                        Tarih = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Makale", t => t.MakaleID)
                .ForeignKey("dbo.Uye", t => t.UyeID)
                .Index(t => t.UyeID)
                .Index(t => t.MakaleID);
            
            CreateTable(
                "dbo.MakaleEtiket",
                c => new
                    {
                        Makale_Id = c.Int(nullable: false),
                        Etiket_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Makale_Id, t.Etiket_Id })
                .ForeignKey("dbo.Makale", t => t.Makale_Id, cascadeDelete: true)
                .ForeignKey("dbo.Etiket", t => t.Etiket_Id, cascadeDelete: true)
                .Index(t => t.Makale_Id)
                .Index(t => t.Etiket_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorum", "UyeID", "dbo.Uye");
            DropForeignKey("dbo.Yorum", "MakaleID", "dbo.Makale");
            DropForeignKey("dbo.Uye", "YetkiId", "dbo.Yetki");
            DropForeignKey("dbo.Makale", "UyeID", "dbo.Uye");
            DropForeignKey("dbo.Makale", "KategoriID", "dbo.Kategori");
            DropForeignKey("dbo.MakaleEtiket", "Etiket_Id", "dbo.Etiket");
            DropForeignKey("dbo.MakaleEtiket", "Makale_Id", "dbo.Makale");
            DropIndex("dbo.MakaleEtiket", new[] { "Etiket_Id" });
            DropIndex("dbo.MakaleEtiket", new[] { "Makale_Id" });
            DropIndex("dbo.Yorum", new[] { "MakaleID" });
            DropIndex("dbo.Yorum", new[] { "UyeID" });
            DropIndex("dbo.Uye", new[] { "YetkiId" });
            DropIndex("dbo.Makale", new[] { "UyeID" });
            DropIndex("dbo.Makale", new[] { "KategoriID" });
            DropTable("dbo.MakaleEtiket");
            DropTable("dbo.Yorum");
            DropTable("dbo.Yetki");
            DropTable("dbo.Uye");
            DropTable("dbo.Kategori");
            DropTable("dbo.Makale");
            DropTable("dbo.Etiket");
        }
    }
}
