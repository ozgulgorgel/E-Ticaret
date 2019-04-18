namespace E_TicaretMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdasd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OzellikTips", "KategoriID", "dbo.Kategoris");
            DropForeignKey("dbo.OzellikDegers", "OzellikTipID", "dbo.OzellikTips");
            DropForeignKey("dbo.UrunOzelliks", "OzellikDegerID", "dbo.OzellikDegers");
            DropForeignKey("dbo.UrunOzelliks", "OzellikTipID", "dbo.OzellikTips");
            DropIndex("dbo.OzellikTips", new[] { "KategoriID" });
            DropIndex("dbo.OzellikDegers", new[] { "OzellikTipID" });
            DropIndex("dbo.UrunOzelliks", new[] { "OzellikDegerID" });
            DropIndex("dbo.UrunOzelliks", new[] { "OzellikTipID" });
            DropTable("dbo.OzellikTips");
            DropTable("dbo.OzellikDegers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OzellikDegers",
                c => new
                    {
                        OzellikDegerID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Aciklama = c.String(),
                        OzellikTipID = c.Int(),
                    })
                .PrimaryKey(t => t.OzellikDegerID);
            
            CreateTable(
                "dbo.OzellikTips",
                c => new
                    {
                        OzellikTipID = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Aciklama = c.String(),
                        KategoriID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OzellikTipID);
            
            CreateIndex("dbo.UrunOzelliks", "OzellikTipID");
            CreateIndex("dbo.UrunOzelliks", "OzellikDegerID");
            CreateIndex("dbo.OzellikDegers", "OzellikTipID");
            CreateIndex("dbo.OzellikTips", "KategoriID");
            AddForeignKey("dbo.UrunOzelliks", "OzellikTipID", "dbo.OzellikTips", "OzellikTipID", cascadeDelete: true);
            AddForeignKey("dbo.UrunOzelliks", "OzellikDegerID", "dbo.OzellikDegers", "OzellikDegerID", cascadeDelete: true);
            AddForeignKey("dbo.OzellikDegers", "OzellikTipID", "dbo.OzellikTips", "OzellikTipID");
            AddForeignKey("dbo.OzellikTips", "KategoriID", "dbo.Kategoris", "KategoriID", cascadeDelete: true);
        }
    }
}
