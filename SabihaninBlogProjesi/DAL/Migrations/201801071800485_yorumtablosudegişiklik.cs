namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yorumtablosudegişiklik : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yorums", "KullaniciAdi", c => c.String());
            AddColumn("dbo.Yorums", "Kullanici_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Yorums", "Kullanici_Id");
            AddForeignKey("dbo.Yorums", "Kullanici_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Yorums", "AdSoyad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Yorums", "AdSoyad", c => c.String());
            DropForeignKey("dbo.Yorums", "Kullanici_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Yorums", new[] { "Kullanici_Id" });
            DropColumn("dbo.Yorums", "Kullanici_Id");
            DropColumn("dbo.Yorums", "KullaniciAdi");
        }
    }
}
