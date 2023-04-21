namespace TP_Autos.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldComisionInVentasTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ventas", "Comision", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            Sql("UPDATE Ventas set Comision = 3*Monto/100");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ventas", "Comision");
        }
    }
}
