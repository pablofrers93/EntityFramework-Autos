namespace TP_Autos.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRelationshipBetweenCategoriaDeVendedoresAndVendedorTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendedores", "CategoriaDeVendedoresId", c => c.Int(nullable: false));
            Sql("UPDATE Vendedores SET CategoriaDeVendedoresId=1");
            CreateIndex("dbo.Vendedores", "CategoriaDeVendedoresId");
            AddForeignKey("dbo.Vendedores", "CategoriaDeVendedoresId", "dbo.CategoriasDeVendedores", "CategoriaDeVendedoresId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendedores", "CategoriaDeVendedoresId", "dbo.CategoriasDeVendedores");
            DropIndex("dbo.Vendedores", new[] { "CategoriaDeVendedoresId" });
            DropColumn("dbo.Vendedores", "CategoriaDeVendedoresId");
        }
    }
}
