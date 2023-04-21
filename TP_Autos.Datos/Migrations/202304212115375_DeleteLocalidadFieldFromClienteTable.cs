namespace TP_Autos.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteLocalidadFieldFromClienteTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "Localidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Localidad", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
