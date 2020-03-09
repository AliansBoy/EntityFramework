namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMingration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetailTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO dbo.Manufacturers (Name) Values ('Not Selected')");
            Sql("INSERT INTO dbo.Manufacturers (Name) Select Manufacturer FROM dbo.Cars");
            AddColumn("dbo.Cars", "ManufacturerId", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.Details", "Price", c => c.Int(nullable: false));
            Sql("INSERT INTO dbo.DetailTypes (Type) Values ('Not Selected')");
            AddColumn("dbo.Details", "TypeId", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.Details", "ManufacturerId", c => c.Int(nullable: false, defaultValue: 1));
            CreateIndex("dbo.Cars", "ManufacturerId");
            CreateIndex("dbo.Details", "TypeId");
            CreateIndex("dbo.Details", "ManufacturerId");
            AddForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Details", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Details", "TypeId", "dbo.DetailTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Cars", "Manufacturer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Manufacturer", c => c.String());
            Sql("INSERT INTO dbo.Cars (Manufacturer) Select Name FROM dbo.Manufacturers");
            DropForeignKey("dbo.Details", "TypeId", "dbo.DetailTypes");
            DropForeignKey("dbo.Details", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Details", new[] { "ManufacturerId" });
            DropIndex("dbo.Details", new[] { "TypeId" });
            DropIndex("dbo.Cars", new[] { "ManufacturerId" });
            DropColumn("dbo.Details", "ManufacturerId");
            DropColumn("dbo.Details", "TypeId");
            DropColumn("dbo.Details", "Price");
            DropColumn("dbo.Cars", "ManufacturerId");
            DropTable("dbo.DetailTypes");
            DropTable("dbo.Manufacturers");
        }
    }
}
