namespace Kurs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class task : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.Tasks", new[] { "SubtaskId" });
            AlterColumn("dbo.Tasks", "ProjectId", c => c.Guid());
            AlterColumn("dbo.Tasks", "SubtaskId", c => c.Guid());
            CreateIndex("dbo.Tasks", "ProjectId");
            CreateIndex("dbo.Tasks", "SubtaskId");
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "SubtaskId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            AlterColumn("dbo.Tasks", "SubtaskId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Tasks", "ProjectId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Tasks", "SubtaskId");
            CreateIndex("dbo.Tasks", "ProjectId");
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
    }
}
