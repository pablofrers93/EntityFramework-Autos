namespace TP_Autos.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaisDeOrigenIdInAutosTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Autos", "PaisDeOrigenId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Autos", "PaisDeOrigenId");
        }
    }
}
