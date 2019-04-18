namespace E_TicaretMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdasdddsfg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kategoris", "Resim_ResimID", "dbo.Resims");
            DropIndex("dbo.Kategoris", new[] { "Resim_ResimID" });
            DropColumn("dbo.Kategoris", "Resim_ResimID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoris", "Resim_ResimID", c => c.Int());
            CreateIndex("dbo.Kategoris", "Resim_ResimID");
            AddForeignKey("dbo.Kategoris", "Resim_ResimID", "dbo.Resims", "ResimID");
        }
    }
}
