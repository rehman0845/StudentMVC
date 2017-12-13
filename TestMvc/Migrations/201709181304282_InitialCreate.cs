namespace TestMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StandardName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        StandardId = c.String(),
                        BatchId = c.String(),
                        Batch_Id = c.Int(),
                        Standard_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.Batch_Id)
                .ForeignKey("dbo.Standards", t => t.Standard_Id)
                .Index(t => t.Batch_Id)
                .Index(t => t.Standard_Id);
           // AlterColumn("dbo.Students","Year", c => c.String(false , 50,null,null,null,null,"Year",string,null});
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Standard_Id", "dbo.Standards");
            DropForeignKey("dbo.Students", "Batch_Id", "dbo.Batches");
            DropIndex("dbo.Students", new[] { "Standard_Id" });
            DropIndex("dbo.Students", new[] { "Batch_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Standards");
            DropTable("dbo.Batches");
        }
    }
}
