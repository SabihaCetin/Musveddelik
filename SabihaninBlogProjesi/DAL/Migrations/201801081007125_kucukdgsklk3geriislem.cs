namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kucukdgsklk3geriislem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Etikets", "Makale_MakaleID", "dbo.Makales");
            DropForeignKey("dbo.Makales", "Etiket_EtiketID", "dbo.Etikets");
            DropForeignKey("dbo.Etikets", "Makalem_MakaleID", "dbo.Makales");
            DropIndex("dbo.Etikets", new[] { "Makale_MakaleID" });
            DropIndex("dbo.Etikets", new[] { "Makalem_MakaleID" });
            DropIndex("dbo.Makales", new[] { "Etiket_EtiketID" });
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
            
            DropColumn("dbo.Etikets", "Makale_MakaleID");
            DropColumn("dbo.Etikets", "Makalem_MakaleID");
            DropColumn("dbo.Makales", "Etiket_EtiketID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Makales", "Etiket_EtiketID", c => c.Int());
            AddColumn("dbo.Etikets", "Makalem_MakaleID", c => c.Int());
            AddColumn("dbo.Etikets", "Makale_MakaleID", c => c.Int());
            DropForeignKey("dbo.MakaleEtikets", "Etiket_EtiketID", "dbo.Etikets");
            DropForeignKey("dbo.MakaleEtikets", "Makale_MakaleID", "dbo.Makales");
            DropIndex("dbo.MakaleEtikets", new[] { "Etiket_EtiketID" });
            DropIndex("dbo.MakaleEtikets", new[] { "Makale_MakaleID" });
            DropTable("dbo.MakaleEtikets");
            CreateIndex("dbo.Makales", "Etiket_EtiketID");
            CreateIndex("dbo.Etikets", "Makalem_MakaleID");
            CreateIndex("dbo.Etikets", "Makale_MakaleID");
            AddForeignKey("dbo.Etikets", "Makalem_MakaleID", "dbo.Makales", "MakaleID");
            AddForeignKey("dbo.Makales", "Etiket_EtiketID", "dbo.Etikets", "EtiketID");
            AddForeignKey("dbo.Etikets", "Makale_MakaleID", "dbo.Makales", "MakaleID");
        }
    }
}
