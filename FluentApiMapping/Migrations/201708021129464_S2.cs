namespace FluentApiMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class S2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Stu.NewStudents",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "Stu.StudentAddresses",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Zipcode = c.Int(nullable: false),
                        State = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("Stu.NewStudents", t => t.StudentId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Stu.StudentAddresses", "StudentId", "Stu.NewStudents");
            DropIndex("Stu.StudentAddresses", new[] { "StudentId" });
            DropTable("Stu.StudentAddresses");
            DropTable("Stu.NewStudents");
        }
    }
}
