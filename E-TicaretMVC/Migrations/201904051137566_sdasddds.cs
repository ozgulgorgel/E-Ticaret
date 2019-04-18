namespace E_TicaretMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdasddds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategoris", "Resim_ResimID", c => c.Int());
            CreateIndex("dbo.Kategoris", "Resim_ResimID");
            AddForeignKey("dbo.Kategoris", "Resim_ResimID", "dbo.Resims", "ResimID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kategoris", "Resim_ResimID", "dbo.Resims");
            DropIndex("dbo.Kategoris", new[] { "Resim_ResimID" });
            DropColumn("dbo.Kategoris", "Resim_ResimID");
        }
    }
}
