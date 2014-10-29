namespace SimpleHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credential",
                c => new
                    {
                        LoginId = c.String(nullable: false, maxLength: 128),
                        PasswordHash = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
            CreateTable(
                "dbo.EmployeeRole",
                c => new
                    {
                        LoginId = c.String(nullable: false, maxLength: 128),
                        RoleName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginId, t.RoleName })
                .ForeignKey("dbo.Credential", t => t.LoginId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleName, cascadeDelete: true)
                .Index(t => t.LoginId)
                .Index(t => t.RoleName);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleName);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        Lastname = c.String(),
                        Location = c.String(),
                        LoginId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Credential", t => t.LoginId)
                .Index(t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "LoginId", "dbo.Credential");
            DropForeignKey("dbo.EmployeeRole", "RoleName", "dbo.Role");
            DropForeignKey("dbo.EmployeeRole", "LoginId", "dbo.Credential");
            DropIndex("dbo.Employee", new[] { "LoginId" });
            DropIndex("dbo.EmployeeRole", new[] { "RoleName" });
            DropIndex("dbo.EmployeeRole", new[] { "LoginId" });
            DropTable("dbo.Employee");
            DropTable("dbo.Role");
            DropTable("dbo.EmployeeRole");
            DropTable("dbo.Credential");
        }
    }
}
