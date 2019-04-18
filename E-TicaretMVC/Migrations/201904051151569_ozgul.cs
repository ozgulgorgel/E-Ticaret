namespace E_TicaretMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ozgul : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Uruns", "KategoriID", "dbo.Kategoris");
            DropIndex("dbo.Uruns", new[] { "KategoriID" });
            AlterColumn("dbo.Uruns", "KategoriID", c => c.Int());
            CreateIndex("dbo.Uruns", "KategoriID");
            AddForeignKey("dbo.Uruns", "KategoriID", "dbo.Kategoris", "KategoriID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uruns", "KategoriID", "dbo.Kategoris");
            DropIndex("dbo.Uruns", new[] { "KategoriID" });
            AlterColumn("dbo.Uruns", "KategoriID", c => c.Int(nullable: false));
            CreateIndex("dbo.Uruns", "KategoriID");
            AddForeignKey("dbo.Uruns", "KategoriID", "dbo.Kategoris", "KategoriID", cascadeDelete: true);
        }
    }
}
