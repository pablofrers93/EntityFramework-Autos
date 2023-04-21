namespace TP_Autos.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCategoriaFieldFromVendedoresTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vendedores", "Categoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendedores", "Categoria", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
