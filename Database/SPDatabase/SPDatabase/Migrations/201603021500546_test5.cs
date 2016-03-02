namespace SPDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserInDatabases", "Name_RealNameId", "dbo.RealNames");
            DropForeignKey("dbo.MonitorUnits", "UserInDatabase_UserInDatabaseId", "dbo.UserInDatabases");
            DropIndex("dbo.UserInDatabases", new[] { "Name_RealNameId" });
            DropIndex("dbo.MonitorUnits", new[] { "UserInDatabase_UserInDatabaseId" });
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
            
            CreateTable(
                "dbo.Pools",
                c => new
                    {
                        PoolId = c.Int(nullable: false, identity: true),
                        Depth = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        UserEntity_UserEntityId = c.Int(),
                    })
                .PrimaryKey(t => t.PoolId)
                .ForeignKey("dbo.UserEntities", t => t.UserEntity_UserEntityId)
                .Index(t => t.UserEntity_UserEntityId);
            
            DropTable("dbo.UserInDatabases");
            DropTable("dbo.MonitorUnits");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MonitorUnits",
                c => new
                    {
                        MonitorUnitId = c.Int(nullable: false, identity: true),
                        SerialNo = c.String(),
                        UserInDatabase_UserInDatabaseId = c.Int(),
                    })
                .PrimaryKey(t => t.MonitorUnitId);
            
            CreateTable(
                "dbo.UserInDatabases",
                c => new
                    {
                        UserInDatabaseId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        NumberOfRegisteredMonitorUnits = c.Int(nullable: false),
                        Name_RealNameId = c.Int(),
                    })
                .PrimaryKey(t => t.UserInDatabaseId);
            
            DropForeignKey("dbo.Pools", "UserEntity_UserEntityId", "dbo.UserEntities");
            DropForeignKey("dbo.UserEntities", "Name_RealNameId", "dbo.RealNames");
            DropIndex("dbo.Pools", new[] { "UserEntity_UserEntityId" });
            DropIndex("dbo.UserEntities", new[] { "Name_RealNameId" });
            DropTable("dbo.Pools");
            DropTable("dbo.UserEntities");
            CreateIndex("dbo.MonitorUnits", "UserInDatabase_UserInDatabaseId");
            CreateIndex("dbo.UserInDatabases", "Name_RealNameId");
            AddForeignKey("dbo.MonitorUnits", "UserInDatabase_UserInDatabaseId", "dbo.UserInDatabases", "UserInDatabaseId");
            AddForeignKey("dbo.UserInDatabases", "Name_RealNameId", "dbo.RealNames", "RealNameId");
        }
    }
}
