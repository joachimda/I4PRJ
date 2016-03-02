namespace SPDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonitorUnits",
                c => new
                    {
                        MonitorUnitId = c.Int(nullable: false, identity: true),
                        SerialNo = c.String(),
                        Pool_PoolId = c.Int(),
                    })
                .PrimaryKey(t => t.MonitorUnitId)
                .ForeignKey("dbo.Pools", t => t.Pool_PoolId)
                .Index(t => t.Pool_PoolId);
            
            AddColumn("dbo.Pools", "AverageTemperature", c => c.Double(nullable: false));
            DropColumn("dbo.Pools", "Depth");
            DropColumn("dbo.Pools", "Length");
            DropColumn("dbo.Pools", "Width");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pools", "Width", c => c.Int(nullable: false));
            AddColumn("dbo.Pools", "Length", c => c.Int(nullable: false));
            AddColumn("dbo.Pools", "Depth", c => c.Int(nullable: false));
            DropForeignKey("dbo.MonitorUnits", "Pool_PoolId", "dbo.Pools");
            DropIndex("dbo.MonitorUnits", new[] { "Pool_PoolId" });
            DropColumn("dbo.Pools", "AverageTemperature");
            DropTable("dbo.MonitorUnits");
        }
    }
}
