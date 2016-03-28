namespace SPDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingt2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pools", "UserEntity_UserEntityId", "dbo.UserEntities");
            DropIndex("dbo.Pools", new[] { "UserEntity_UserEntityId" });
            DropColumn("dbo.Pools", "UserEntity_UserEntityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pools", "UserEntity_UserEntityId", c => c.Int());
            CreateIndex("dbo.Pools", "UserEntity_UserEntityId");
            AddForeignKey("dbo.Pools", "UserEntity_UserEntityId", "dbo.UserEntities", "UserEntityId");
        }
    }
}
