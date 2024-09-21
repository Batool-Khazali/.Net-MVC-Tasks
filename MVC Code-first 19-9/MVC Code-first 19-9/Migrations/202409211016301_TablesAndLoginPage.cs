namespace MVC_Code_first_19_9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesAndLoginPage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        ClassID = c.Int(nullable: false),
                        TaskID = c.Int(nullable: false),
                        Subjects_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskID)
                .ForeignKey("dbo.Subjects", t => t.Subjects_Id)
                .Index(t => t.ClassID)
                .Index(t => t.TaskID)
                .Index(t => t.Subjects_Id);
            
            CreateTable(
                "dbo.SubjectsClasses",
                c => new
                    {
                        Subjects_Id = c.Int(nullable: false),
                        Classes_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subjects_Id, t.Classes_Id })
                .ForeignKey("dbo.Subjects", t => t.Subjects_Id, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Classes_Id, cascadeDelete: true)
                .Index(t => t.Subjects_Id)
                .Index(t => t.Classes_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Subjects_Id", "dbo.Subjects");
            DropForeignKey("dbo.Tasks", "TaskID", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.SubjectsClasses", "Classes_Id", "dbo.Classes");
            DropForeignKey("dbo.SubjectsClasses", "Subjects_Id", "dbo.Subjects");
            DropForeignKey("dbo.Students", "ClassID", "dbo.Classes");
            DropIndex("dbo.SubjectsClasses", new[] { "Classes_Id" });
            DropIndex("dbo.SubjectsClasses", new[] { "Subjects_Id" });
            DropIndex("dbo.Tasks", new[] { "Subjects_Id" });
            DropIndex("dbo.Tasks", new[] { "TaskID" });
            DropIndex("dbo.Tasks", new[] { "ClassID" });
            DropIndex("dbo.Students", new[] { "ClassID" });
            DropTable("dbo.SubjectsClasses");
            DropTable("dbo.Tasks");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
