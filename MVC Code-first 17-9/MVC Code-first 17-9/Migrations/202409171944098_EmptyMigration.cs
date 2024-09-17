namespace MVC_Code_first_17_9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignments", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Address", c => c.String());
            CreateIndex("dbo.Assignments", "StudentId");
            AddForeignKey("dbo.Assignments", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "StudentId", "dbo.Students");
            DropIndex("dbo.Assignments", new[] { "StudentId" });
            DropColumn("dbo.Students", "Address");
            DropColumn("dbo.Assignments", "StudentId");
        }
    }
}
