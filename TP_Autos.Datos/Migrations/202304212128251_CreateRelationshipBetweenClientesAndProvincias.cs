namespace TP_Autos.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRelationshipBetweenClientesAndProvincias : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "ProvinciaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clientes", "LocalidadId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clientes", "ProvinciaId");
            AddForeignKey("dbo.Clientes", "ProvinciaId", "dbo.Provincias", "ProvinciaId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "ProvinciaId", "dbo.Provincias");
            DropIndex("dbo.Clientes", new[] { "ProvinciaId" });
            AlterColumn("dbo.Clientes", "LocalidadId", c => c.Int());
            AlterColumn("dbo.Clientes", "ProvinciaId", c => c.Int());
        }
    }
}
