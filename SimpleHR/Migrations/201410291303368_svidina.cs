namespace SimpleHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class svidina : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employee");
            AddColumn("dbo.Employee", "Address", c => c.String());
            AddColumn("dbo.Employee", "City", c => c.String());
            AddColumn("dbo.Employee", "County", c => c.String());
            AddColumn("dbo.Employee", "State", c => c.String());
            AddColumn("dbo.Employee", "ZipCode", c => c.String());
            AddColumn("dbo.Employee", "OfficePhone", c => c.String());
            AddColumn("dbo.Employee", "CellPhone", c => c.String());
            AddColumn("dbo.Employee", "Email", c => c.String());
            AlterColumn("dbo.Employee", "EmployeeId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Employee", "EmployeeId");
            DropColumn("dbo.Employee", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "Location", c => c.String());
            DropPrimaryKey("dbo.Employee");
            //AlterColumn("dbo.Employee", "EmployeeId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Employee", "Email");
            DropColumn("dbo.Employee", "CellPhone");
            DropColumn("dbo.Employee", "OfficePhone");
            DropColumn("dbo.Employee", "ZipCode");
            DropColumn("dbo.Employee", "State");
            DropColumn("dbo.Employee", "County");
            DropColumn("dbo.Employee", "City");
            DropColumn("dbo.Employee", "Address");
            //AddPrimaryKey("dbo.Employee", "EmployeeId");
        }
    }
}
