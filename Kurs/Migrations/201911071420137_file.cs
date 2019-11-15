namespace Kurs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class file : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "PdfTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "PdfTitle");
        }
    }
}
