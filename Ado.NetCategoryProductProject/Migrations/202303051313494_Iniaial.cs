namespace Ado.NetCategoryProductProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Iniaial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Studentname = c.String(),
                        RollNumber = c.Int(nullable: false),
                        Qualification = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
