namespace SPDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class herpaderp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MonitorUnits", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Pools", "User_UserId", "dbo.Users");
            DropIndex("dbo.MonitorUnits", new[] { "User_UserId" });
            DropIndex("dbo.Pools", new[] { "User_UserId" });
            DropColumn("dbo.MonitorUnits", "User_UserId");
            DropColumn("dbo.Pools", "User_UserId");
            DropColumn("dbo.Users", "NumberOfRegisteredMonitorUnits");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "NumberOfRegisteredMonitorUnits", c => c.Int(nullable: false));
            AddColumn("dbo.Pools", "User_UserId", c => c.Int());
            AddColumn("dbo.MonitorUnits", "User_UserId", c => c.Int());
            CreateIndex("dbo.Pools", "User_UserId");
            CreateIndex("dbo.MonitorUnits", "User_UserId");
            AddForeignKey("dbo.Pools", "User_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.MonitorUnits", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
