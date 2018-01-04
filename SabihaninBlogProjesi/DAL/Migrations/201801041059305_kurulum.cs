namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kurulum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etikets",
                c => new
                    {
                        EtiketID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                    })
                .PrimaryKey(t => t.EtiketID);
            
            CreateTable(
                "dbo.Makales",
                c => new
                    {
                        MakaleID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Icerik = c.String(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        KategoriID = c.Int(),
                        GoruntulenmeSayisi = c.Int(),
                        Begeni = c.Int(),
                        KullaniciID = c.Int(),
                        Kullanici_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MakaleID)
                .ForeignKey("dbo.Kategoris", t => t.KategoriID)
                .ForeignKey("dbo.AspNetUsers", t => t.Kullanici_Id)
                .Index(t => t.KategoriID)
                .Index(t => t.Kullanici_Id);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KAtegoriID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.KAtegoriID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AdSoyad = c.String(),
                        Meslek = c.String(),
                        Cinsiyet = c.Boolean(nullable: false),
                        DogumTarihi = c.DateTime(),
                        KayitTarihi = c.DateTime(nullable: false),
                        Resim = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Resims",
                c => new
                    {
                        ResimID = c.Int(nullable: false, identity: true),
                        KucukBoyut = c.String(),
                        OrtaBoyut = c.String(),
                        BuyukBoyut = c.String(),
                        Video = c.String(),
                        MakaleID = c.Int(),
                    })
                .PrimaryKey(t => t.ResimID)
                .ForeignKey("dbo.Makales", t => t.MakaleID)
                .Index(t => t.MakaleID);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        YorumID = c.Int(nullable: false, identity: true),
                        Yorum1 = c.String(),
                        MakalaID = c.Int(nullable: false),
                        EklenmeTarihi = c.DateTime(),
                        AdSoyad = c.String(),
                        Begeni = c.Int(nullable: false),
                        Makale_MakaleID = c.Int(),
                    })
                .PrimaryKey(t => t.YorumID)
                .ForeignKey("dbo.Makales", t => t.Makale_MakaleID)
                .Index(t => t.Makale_MakaleID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.MakaleEtikets",
                c => new
                    {
                        Makale_MakaleID = c.Int(nullable: false),
                        Etiket_EtiketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Makale_MakaleID, t.Etiket_EtiketID })
                .ForeignKey("dbo.Makales", t => t.Makale_MakaleID, cascadeDelete: true)
                .ForeignKey("dbo.Etikets", t => t.Etiket_EtiketID, cascadeDelete: true)
                .Index(t => t.Makale_MakaleID)
                .Index(t => t.Etiket_EtiketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Yorums", "Makale_MakaleID", "dbo.Makales");
            DropForeignKey("dbo.Resims", "MakaleID", "dbo.Makales");
            DropForeignKey("dbo.Makales", "Kullanici_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Makales", "KategoriID", "dbo.Kategoris");
            DropForeignKey("dbo.MakaleEtikets", "Etiket_EtiketID", "dbo.Etikets");
            DropForeignKey("dbo.MakaleEtikets", "Makale_MakaleID", "dbo.Makales");
            DropIndex("dbo.MakaleEtikets", new[] { "Etiket_EtiketID" });
            DropIndex("dbo.MakaleEtikets", new[] { "Makale_MakaleID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Yorums", new[] { "Makale_MakaleID" });
            DropIndex("dbo.Resims", new[] { "MakaleID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Makales", new[] { "Kullanici_Id" });
            DropIndex("dbo.Makales", new[] { "KategoriID" });
            DropTable("dbo.MakaleEtikets");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Yorums");
            DropTable("dbo.Resims");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Makales");
            DropTable("dbo.Etikets");
        }
    }
}
