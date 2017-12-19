namespace WebApiRestaurante.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prato",
                c => new
                    {
                        PratoID = c.Int(nullable: false, identity: true),
                        NomePrato = c.String(),
                        PrecoPrato = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RestauranteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PratoID)
                .ForeignKey("dbo.Restaurante", t => t.RestauranteID, cascadeDelete: true)
                .Index(t => t.RestauranteID);
            
            CreateTable(
                "dbo.Restaurante",
                c => new
                    {
                        RestauranteID = c.Int(nullable: false, identity: true),
                        NomeRestaurante = c.String(),
                        Restaurante_RestauranteID = c.Int(),
                    })
                .PrimaryKey(t => t.RestauranteID)
                .ForeignKey("dbo.Restaurante", t => t.Restaurante_RestauranteID)
                .Index(t => t.Restaurante_RestauranteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prato", "RestauranteID", "dbo.Restaurante");
            DropForeignKey("dbo.Restaurante", "Restaurante_RestauranteID", "dbo.Restaurante");
            DropIndex("dbo.Restaurante", new[] { "Restaurante_RestauranteID" });
            DropIndex("dbo.Prato", new[] { "RestauranteID" });
            DropTable("dbo.Restaurante");
            DropTable("dbo.Prato");
        }
    }
}
