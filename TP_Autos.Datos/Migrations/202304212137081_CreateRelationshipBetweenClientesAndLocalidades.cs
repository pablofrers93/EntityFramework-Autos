namespace TP_Autos.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRelationshipBetweenClientesAndLocalidades : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Clientes", "LocalidadId");
            AddForeignKey("dbo.Clientes", "LocalidadId", "dbo.Localidades", "LocalidadId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "LocalidadId", "dbo.Localidades");
            DropIndex("dbo.Clientes", new[] { "LocalidadId" });
        }
    }
}
