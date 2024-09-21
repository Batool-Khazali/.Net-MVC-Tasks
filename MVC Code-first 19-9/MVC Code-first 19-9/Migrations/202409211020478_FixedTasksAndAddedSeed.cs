namespace MVC_Code_first_19_9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedTasksAndAddedSeed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "TaskID", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "Subjects_Id", "dbo.Subjects");
            DropIndex("dbo.Tasks", new[] { "TaskID" });
            DropIndex("dbo.Tasks", new[] { "Subjects_Id" });
            RenameColumn(table: "dbo.Tasks", name: "Subjects_Id", newName: "SubjectID");
            AlterColumn("dbo.Tasks", "SubjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "SubjectID");
            AddForeignKey("dbo.Tasks", "SubjectID", "dbo.Subjects", "Id", cascadeDelete: true);
            DropColumn("dbo.Tasks", "TaskID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "TaskID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tasks", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.Tasks", new[] { "SubjectID" });
            AlterColumn("dbo.Tasks", "SubjectID", c => c.Int());
            RenameColumn(table: "dbo.Tasks", name: "SubjectID", newName: "Subjects_Id");
            CreateIndex("dbo.Tasks", "Subjects_Id");
            CreateIndex("dbo.Tasks", "TaskID");
            AddForeignKey("dbo.Tasks", "Subjects_Id", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Tasks", "TaskID", "dbo.Tasks", "Id");
        }
    }
}
