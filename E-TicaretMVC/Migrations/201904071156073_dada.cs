namespace E_TicaretMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dada : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Uruns", "EklenmeTarihi");
            DropColumn("dbo.Uruns", "SonKullanmaTarihi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Uruns", "SonKullanmaTarihi", c => c.DateTime());
            AddColumn("dbo.Uruns", "EklenmeTarihi", c => c.DateTime());
        }
    }
}
