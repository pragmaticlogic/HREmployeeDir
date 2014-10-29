namespace SimpleHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class svidina1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employee");
            AlterColumn("dbo.Employee", "EmployeeId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Employee", "EmployeeId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employee");
            AlterColumn("dbo.Employee", "EmployeeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employee", "EmployeeId");
        }
    }
}
