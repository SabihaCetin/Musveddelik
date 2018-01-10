namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kucukdgsklk2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MakaleEtikets", "Makale_MakaleID", "dbo.Makales");
            DropForeignKey("dbo.MakaleEtikets", "Etiket_EtiketID", "dbo.Etikets");
            DropIndex("dbo.MakaleEtikets", new[] { "Makale_MakaleID" });
            DropIndex("dbo.MakaleEtikets", new[] { "Etiket_EtiketID" });
            AddColumn("dbo.Etikets", "Makale_MakaleID", c => c.Int());
            AddColumn("dbo.Etikets", "Makalem_MakaleID", c => c.Int());
            AddColumn("dbo.Makales", "Etiket_EtiketID", c => c.Int());
            CreateIndex("dbo.Etikets", "Makale_MakaleID");
            CreateIndex("dbo.Etikets", "Makalem_MakaleID");
            CreateIndex("dbo.Makales", "Etiket_EtiketID");
            AddForeignKey("dbo.Etikets", "Makale_MakaleID", "dbo.Makales", "MakaleID");
            AddForeignKey("dbo.Makales", "Etiket_EtiketID", "dbo.Etikets", "EtiketID");
            AddForeignKey("dbo.Etikets", "Makalem_MakaleID", "dbo.Makales", "MakaleID");
            DropColumn("dbo.Etikets", "MakaleID");
            DropTable("dbo.MakaleEtikets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MakaleEtikets",
                c => new
                    {
                        Makale_MakaleID = c.Int(nullable: false),
                        Etiket_EtiketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Makale_MakaleID, t.Etiket_EtiketID });
            
            AddColumn("dbo.Etikets", "MakaleID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Etikets", "Makalem_MakaleID", "dbo.Makales");
            DropForeignKey("dbo.Makales", "Etiket_EtiketID", "dbo.Etikets");
            DropForeignKey("dbo.Etikets", "Makale_MakaleID", "dbo.Makales");
            DropIndex("dbo.Makales", new[] { "Etiket_EtiketID" });
            DropIndex("dbo.Etikets", new[] { "Makalem_MakaleID" });
            DropIndex("dbo.Etikets", new[] { "Makale_MakaleID" });
            DropColumn("dbo.Makales", "Etiket_EtiketID");
            DropColumn("dbo.Etikets", "Makalem_MakaleID");
            DropColumn("dbo.Etikets", "Makale_MakaleID");
            CreateIndex("dbo.MakaleEtikets", "Etiket_EtiketID");
            CreateIndex("dbo.MakaleEtikets", "Makale_MakaleID");
            AddForeignKey("dbo.MakaleEtikets", "Etiket_EtiketID", "dbo.Etikets", "EtiketID", cascadeDelete: true);
            AddForeignKey("dbo.MakaleEtikets", "Makale_MakaleID", "dbo.Makales", "MakaleID", cascadeDelete: true);
        }
    }
}
