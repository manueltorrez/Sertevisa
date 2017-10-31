namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adelanto",
                c => new
                    {
                        AdelantoId = c.Int(nullable: false, identity: true),
                        OrdenEntradaId = c.Int(nullable: false),
                        Moneda = c.String(nullable: false, maxLength: 250, unicode: false),
                        Valor = c.Int(nullable: false),
                        TasaCambio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdelantoId)
                .ForeignKey("dbo.OrdenEntrada", t => t.OrdenEntradaId)
                .Index(t => t.OrdenEntradaId);
            
            CreateTable(
                "dbo.OrdenEntrada",
                c => new
                    {
                        OrdenEntradaId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        NumeroSerie = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        DescripcionTecnica = c.String(maxLength: 250, unicode: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        FechaEgreso = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrdenEntradaId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre1 = c.String(nullable: false, maxLength: 250, unicode: false),
                        Nombre2 = c.String(maxLength: 250, unicode: false),
                        Apellido1 = c.String(nullable: false, maxLength: 250, unicode: false),
                        Apellido2 = c.String(maxLength: 250, unicode: false),
                        Correo = c.String(maxLength: 250, unicode: false),
                        Telefono = c.Int(nullable: false),
                        Celular = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false),
                        Descripción = c.String(nullable: false, maxLength: 250, unicode: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EstadoId)
                .ForeignKey("dbo.OrdenEntrada", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        MarcaID = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.MarcaID)
                .ForeignKey("dbo.OrdenEntrada", t => t.MarcaID)
                .Index(t => t.MarcaID);
            
            CreateTable(
                "dbo.Desglose",
                c => new
                    {
                        DesgloseId = c.Int(nullable: false, identity: true),
                        FacturaId = c.Int(nullable: false),
                        Moneda = c.String(nullable: false, maxLength: 250, unicode: false),
                        Valor = c.Int(nullable: false),
                        TasaCambio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DesgloseId)
                .ForeignKey("dbo.Factura", t => t.FacturaId)
                .Index(t => t.FacturaId);
            
            CreateTable(
                "dbo.Factura",
                c => new
                    {
                        FacturaId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Numero = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FacturaId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.FacturaDetalle",
                c => new
                    {
                        FacturaDetalleId = c.Int(nullable: false, identity: true),
                        FacturaId = c.Int(nullable: false),
                        OrdenEntradaId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FacturaDetalleId)
                .ForeignKey("dbo.Factura", t => t.FacturaId)
                .ForeignKey("dbo.OrdenEntrada", t => t.OrdenEntradaId)
                .Index(t => t.FacturaId)
                .Index(t => t.OrdenEntradaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaDetalle", "OrdenEntradaId", "dbo.OrdenEntrada");
            DropForeignKey("dbo.FacturaDetalle", "FacturaId", "dbo.Factura");
            DropForeignKey("dbo.Desglose", "FacturaId", "dbo.Factura");
            DropForeignKey("dbo.Factura", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Adelanto", "OrdenEntradaId", "dbo.OrdenEntrada");
            DropForeignKey("dbo.Marca", "MarcaID", "dbo.OrdenEntrada");
            DropForeignKey("dbo.Estado", "EstadoId", "dbo.OrdenEntrada");
            DropForeignKey("dbo.OrdenEntrada", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.FacturaDetalle", new[] { "OrdenEntradaId" });
            DropIndex("dbo.FacturaDetalle", new[] { "FacturaId" });
            DropIndex("dbo.Factura", new[] { "ClienteId" });
            DropIndex("dbo.Desglose", new[] { "FacturaId" });
            DropIndex("dbo.Marca", new[] { "MarcaID" });
            DropIndex("dbo.Estado", new[] { "EstadoId" });
            DropIndex("dbo.OrdenEntrada", new[] { "ClienteId" });
            DropIndex("dbo.Adelanto", new[] { "OrdenEntradaId" });
            DropTable("dbo.FacturaDetalle");
            DropTable("dbo.Factura");
            DropTable("dbo.Desglose");
            DropTable("dbo.Marca");
            DropTable("dbo.Estado");
            DropTable("dbo.Cliente");
            DropTable("dbo.OrdenEntrada");
            DropTable("dbo.Adelanto");
        }
    }
}
