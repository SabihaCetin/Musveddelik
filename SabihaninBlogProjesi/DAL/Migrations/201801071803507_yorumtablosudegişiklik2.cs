namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yorumtablosudegişiklik2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yorums", "AdSoyad", c => c.String());
            AddColumn("dbo.Yorums", "KullanicimID", c => c.String());
            DropColumn("dbo.Yorums", "KullaniciAdi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Yorums", "KullaniciAdi", c => c.String());
            DropColumn("dbo.Yorums", "KullanicimID");
            DropColumn("dbo.Yorums", "AdSoyad");
        }
    }
}
