namespace SPDatabase.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RealNames",
                c => new
                    {
                        RealNameId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        SurName = c.String(),
                    })
                .PrimaryKey(t => t.RealNameId);
            
            AddColumn("dbo.Users", "Name_RealNameId", c => c.Int());
            AddColumn("dbo.MonitorUnits", "SerialNo", c => c.String());
            CreateIndex("dbo.Users", "Name_RealNameId");
            AddForeignKey("dbo.Users", "Name_RealNameId", "dbo.RealNames", "RealNameId");
            DropColumn("dbo.Users", "Name_FirstName");
            DropColumn("dbo.Users", "Name_MiddleName");
            DropColumn("dbo.Users", "Name_SurName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name_SurName", c => c.String());
            AddColumn("dbo.Users", "Name_MiddleName", c => c.String());
            AddColumn("dbo.Users", "Name_FirstName", c => c.String());
            DropForeignKey("dbo.Users", "Name_RealNameId", "dbo.RealNames");
            DropIndex("dbo.Users", new[] { "Name_RealNameId" });
            DropColumn("dbo.MonitorUnits", "SerialNo");
            DropColumn("dbo.Users", "Name_RealNameId");
            DropTable("dbo.RealNames");
        }
    }
}
