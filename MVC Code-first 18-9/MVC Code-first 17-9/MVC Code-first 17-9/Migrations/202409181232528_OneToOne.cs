namespace MVC_Code_first_17_9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentsDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        phone = c.Int(nullable: false),
                        BirthDate = c.DateTime(),
                        Address = c.String(),
                        ParentName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.StudentID, unique: true);
            
            AddColumn("dbo.Students", "Grade", c => c.String());
            DropColumn("dbo.Students", "BirthDate");
            DropColumn("dbo.Students", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Address", c => c.String());
            AddColumn("dbo.Students", "BirthDate", c => c.DateTime());
            DropForeignKey("dbo.StudentsDetails", "ID", "dbo.Students");
            DropIndex("dbo.StudentsDetails", new[] { "StudentID" });
            DropIndex("dbo.StudentsDetails", new[] { "ID" });
            DropColumn("dbo.Students", "Grade");
            DropTable("dbo.StudentsDetails");
        }
    }
}
