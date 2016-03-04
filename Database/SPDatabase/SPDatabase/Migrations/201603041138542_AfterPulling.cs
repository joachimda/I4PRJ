namespace SPDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterPulling : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Name_RealNameId", "dbo.RealNames");
            DropIndex("dbo.Users", new[] { "Name_RealNameId" });
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
            
            CreateTable(
                "dbo.Pools",
                c => new
                    {
                        PoolId = c.Int(nullable: false, identity: true),
                        AverageTemperature = c.Double(nullable: false),
                        UserEntity_UserEntityId = c.Int(),
                    })
                .PrimaryKey(t => t.PoolId)
                .ForeignKey("dbo.UserEntities", t => t.UserEntity_UserEntityId)
                .Index(t => t.UserEntity_UserEntityId);
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        UserEntityId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Name_RealNameId = c.Int(),
                    })
                .PrimaryKey(t => t.UserEntityId)
                .ForeignKey("dbo.RealNames", t => t.Name_RealNameId)
                .Index(t => t.Name_RealNameId);
            
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        NumberOfRegisteredMonitorUnits = c.Int(nullable: false),
                        Name_RealNameId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropForeignKey("dbo.Pools", "UserEntity_UserEntityId", "dbo.UserEntities");
            DropForeignKey("dbo.UserEntities", "Name_RealNameId", "dbo.RealNames");
            DropForeignKey("dbo.MonitorUnits", "Pool_PoolId", "dbo.Pools");
            DropIndex("dbo.UserEntities", new[] { "Name_RealNameId" });
            DropIndex("dbo.Pools", new[] { "UserEntity_UserEntityId" });
            DropIndex("dbo.MonitorUnits", new[] { "Pool_PoolId" });
            DropTable("dbo.UserEntities");
            DropTable("dbo.Pools");
            DropTable("dbo.MonitorUnits");
            CreateIndex("dbo.Users", "Name_RealNameId");
            AddForeignKey("dbo.Users", "Name_RealNameId", "dbo.RealNames", "RealNameId");
        }
    }
}
