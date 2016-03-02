namespace SPDatabase.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class herpaderpdddd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "NumberOfRegisteredMonitorUnits", c => c.Int(nullable: false));
            DropTable("dbo.MonitorUnits");
            DropTable("dbo.Pools");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pools",
                c => new
                    {
                        PoolId = c.Int(nullable: false, identity: true),
                        Depth = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PoolId);
            
            CreateTable(
                "dbo.MonitorUnits",
                c => new
                    {
                        MonitorUnitId = c.Int(nullable: false, identity: true),
                        SerialNo = c.String(),
                    })
                .PrimaryKey(t => t.MonitorUnitId);
            
            DropColumn("dbo.Users", "NumberOfRegisteredMonitorUnits");
        }
    }
}
