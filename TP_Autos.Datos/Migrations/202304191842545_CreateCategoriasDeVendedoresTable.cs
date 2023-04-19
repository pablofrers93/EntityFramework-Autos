namespace TP_Autos.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategoriasDeVendedoresTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriasDeVendedores",
                c => new
                    {
                        CategoriaDeVendedoresId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.CategoriaDeVendedoresId)
                .Index(t => t.Descripcion, unique: true, name: "IX_CategoriasDevendedores_Descripcion");
            Sql("INSERT INTO CategoriasDeVendedores (Descripcion) select distinct Categoria from Vendedores");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CategoriasDeVendedores", "IX_CategoriasDevendedores_Descripcion");
            DropTable("dbo.CategoriasDeVendedores");
        }
    }
}
