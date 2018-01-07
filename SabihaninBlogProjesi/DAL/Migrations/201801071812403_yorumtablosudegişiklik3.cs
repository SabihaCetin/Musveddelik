namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yorumtablosudegişiklik3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Yorums", "MakalaID");
            DropColumn("dbo.Yorums", "KullanicimID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Yorums", "KullanicimID", c => c.String());
            AddColumn("dbo.Yorums", "MakalaID", c => c.Int(nullable: false));
        }
    }
}
