namespace MVC_Code_first_17_9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentsCourses",
                c => new
                    {
                        Students_Id = c.Int(nullable: false),
                        Courses_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Students_Id, t.Courses_Id })
                .ForeignKey("dbo.Students", t => t.Students_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Courses_Id, cascadeDelete: true)
                .Index(t => t.Students_Id)
                .Index(t => t.Courses_Id);
            
            AddColumn("dbo.Assignments", "CouseId", c => c.Int(nullable: false));
            AddColumn("dbo.Assignments", "Course_Id", c => c.Int());
            CreateIndex("dbo.Assignments", "Course_Id");
            AddForeignKey("dbo.Assignments", "Course_Id", "dbo.Courses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentsCourses", "Courses_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentsCourses", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.Assignments", "Course_Id", "dbo.Courses");
            DropIndex("dbo.StudentsCourses", new[] { "Courses_Id" });
            DropIndex("dbo.StudentsCourses", new[] { "Students_Id" });
            DropIndex("dbo.Assignments", new[] { "Course_Id" });
            DropColumn("dbo.Assignments", "Course_Id");
            DropColumn("dbo.Assignments", "CouseId");
            DropTable("dbo.StudentsCourses");
        }
    }
}
