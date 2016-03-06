namespace SPDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingt1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pools", "PoolName", c => c.String());
            AddColumn("dbo.Pools", "Depth", c => c.Int(nullable: false));
            AddColumn("dbo.Pools", "Length", c => c.Int(nullable: false));
            AddColumn("dbo.Pools", "Width", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pools", "Width");
            DropColumn("dbo.Pools", "Length");
            DropColumn("dbo.Pools", "Depth");
            DropColumn("dbo.Pools", "PoolName");
        }
    }
}
