namespace SPDatabase.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
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
            CreateIndex("dbo.Users", "Name_RealNameId");
            AddForeignKey("dbo.Users", "Name_RealNameId", "dbo.RealNames", "RealNameId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Name_RealNameId", "dbo.RealNames");
            DropIndex("dbo.Users", new[] { "Name_RealNameId" });
            DropColumn("dbo.Users", "Name_RealNameId");
            DropTable("dbo.RealNames");
        }
    }
}
