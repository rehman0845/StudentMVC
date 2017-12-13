namespace TestMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Batch_Id", "dbo.Batches");
            DropForeignKey("dbo.Students", "Standard_Id", "dbo.Standards");
            DropIndex("dbo.Students", new[] { "Batch_Id" });
            DropIndex("dbo.Students", new[] { "Standard_Id" });
            DropColumn("dbo.Students", "BatchId");
            DropColumn("dbo.Students", "StandardId");
            RenameColumn(table: "dbo.Students", name: "Batch_Id", newName: "BatchId");
            RenameColumn(table: "dbo.Students", name: "Standard_Id", newName: "StandardId");
            AlterColumn("dbo.Students", "StandardId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "BatchId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "BatchId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "StandardId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "StandardId");
            CreateIndex("dbo.Students", "BatchId");
            AddForeignKey("dbo.Students", "BatchId", "dbo.Batches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "StandardId", "dbo.Standards", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StandardId", "dbo.Standards");
            DropForeignKey("dbo.Students", "BatchId", "dbo.Batches");
            DropIndex("dbo.Students", new[] { "BatchId" });
            DropIndex("dbo.Students", new[] { "StandardId" });
            AlterColumn("dbo.Students", "StandardId", c => c.Int());
            AlterColumn("dbo.Students", "BatchId", c => c.Int());
            AlterColumn("dbo.Students", "BatchId", c => c.String());
            AlterColumn("dbo.Students", "StandardId", c => c.String());
            RenameColumn(table: "dbo.Students", name: "StandardId", newName: "Standard_Id");
            RenameColumn(table: "dbo.Students", name: "BatchId", newName: "Batch_Id");
            AddColumn("dbo.Students", "StandardId", c => c.String());
            AddColumn("dbo.Students", "BatchId", c => c.String());
            CreateIndex("dbo.Students", "Standard_Id");
            CreateIndex("dbo.Students", "Batch_Id");
            AddForeignKey("dbo.Students", "Standard_Id", "dbo.Standards", "Id");
            AddForeignKey("dbo.Students", "Batch_Id", "dbo.Batches", "Id");
        }
    }
}
