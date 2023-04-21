namespace TP_Autos.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRelationshipBetweenSucursalAndVentaTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ventas", "SucursalId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ventas", "SucursalId");
            AddForeignKey("dbo.Ventas", "SucursalId", "dbo.Sucursales", "SucursalId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "SucursalId", "dbo.Sucursales");
            DropIndex("dbo.Ventas", new[] { "SucursalId" });
            AlterColumn("dbo.Ventas", "SucursalId", c => c.Int());
        }
    }
}
