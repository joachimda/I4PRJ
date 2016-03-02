namespace SPDatabase.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name_FirstName = c.String(),
                        Name_MiddleName = c.String(),
                        Name_SurName = c.String(),
                        Password = c.String(),
                        NumberOfRegisteredMonitorUnits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.MonitorUnits",
                c => new
                    {
                        MonitorUnitId = c.Int(nullable: false, identity: true),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.MonitorUnitId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Pools",
                c => new
                    {
                        PoolId = c.Int(nullable: false, identity: true),
                        Depth = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PoolId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pools", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.MonitorUnits", "User_UserId", "dbo.Users");
            DropIndex("dbo.Pools", new[] { "User_UserId" });
            DropIndex("dbo.MonitorUnits", new[] { "User_UserId" });
            DropTable("dbo.Pools");
            DropTable("dbo.MonitorUnits");
            DropTable("dbo.Users");
        }
    }
}
