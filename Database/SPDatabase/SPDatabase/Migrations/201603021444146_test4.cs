namespace SPDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Name_RealNameId", "dbo.RealNames");
            DropIndex("dbo.Users", new[] { "Name_RealNameId" });
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
                .PrimaryKey(t => t.UserInDatabaseId)
                .ForeignKey("dbo.RealNames", t => t.Name_RealNameId)
                .Index(t => t.Name_RealNameId);
            
            CreateTable(
                "dbo.MonitorUnits",
                c => new
                    {
                        MonitorUnitId = c.Int(nullable: false, identity: true),
                        SerialNo = c.String(),
                        UserInDatabase_UserInDatabaseId = c.Int(),
                    })
                .PrimaryKey(t => t.MonitorUnitId)
                .ForeignKey("dbo.UserInDatabases", t => t.UserInDatabase_UserInDatabaseId)
                .Index(t => t.UserInDatabase_UserInDatabaseId);
            
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
            
            DropForeignKey("dbo.MonitorUnits", "UserInDatabase_UserInDatabaseId", "dbo.UserInDatabases");
            DropForeignKey("dbo.UserInDatabases", "Name_RealNameId", "dbo.RealNames");
            DropIndex("dbo.MonitorUnits", new[] { "UserInDatabase_UserInDatabaseId" });
            DropIndex("dbo.UserInDatabases", new[] { "Name_RealNameId" });
            DropTable("dbo.MonitorUnits");
            DropTable("dbo.UserInDatabases");
            CreateIndex("dbo.Users", "Name_RealNameId");
            AddForeignKey("dbo.Users", "Name_RealNameId", "dbo.RealNames", "RealNameId");
        }
    }
}
