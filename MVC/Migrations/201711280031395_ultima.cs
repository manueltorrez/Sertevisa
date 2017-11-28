namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ultima : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adelanto",
                c => new
                    {
                        AdelantoId = c.Int(nullable: false, identity: true),
                        OrdenEntradaId = c.Int(nullable: false),
                        Moneda = c.String(nullable: false, maxLength: 4, unicode: false),
                        Valor = c.Int(nullable: false),
                        TasaCambio = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Control = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
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
                        EquipoId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        NumeroSerie = c.String(nullable: false, maxLength: 30, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 100, unicode: false),
                        DescripcionTecnica = c.String(maxLength: 150, unicode: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        FechaEgreso = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Control = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.OrdenEntradaId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Equipo", t => t.EquipoId)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.ClienteId)
                .Index(t => t.EquipoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre1 = c.String(nullable: false, maxLength: 20, unicode: false),
                        Nombre2 = c.String(maxLength: 20, unicode: false),
                        Apellido1 = c.String(nullable: false, maxLength: 40, unicode: false),
                        Apellido2 = c.String(maxLength: 40, unicode: false),
                        Correo = c.String(maxLength: 60, unicode: false),
                        Telefono = c.String(maxLength: 10, unicode: false),
                        Celular = c.String(maxLength: 10, unicode: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Control = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Equipo",
                c => new
                    {
                        EquipoId = c.Int(nullable: false, identity: true),
                        MarcaId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                        Modelo = c.String(nullable: false, maxLength: 25, unicode: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Control = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.EquipoId)
                .ForeignKey("dbo.Marcas", t => t.MarcaId)
                .Index(t => t.MarcaId);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20, unicode: false),
                        Active = c.Boolean(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Control = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Nombre, unique: true, name: "Index_Marca_Nombre");
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 35, unicode: false),
                        Activo = c.Boolean(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Control = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Descripcion, unique: true, name: "Index_Estado_Descripcion");
            
            CreateTable(
                "dbo.Desglose",
                c => new
                    {
                        DesgloseId = c.Int(nullable: false, identity: true),
                        FacturaId = c.Int(nullable: false),
                        Moneda = c.String(nullable: false, maxLength: 4, unicode: false),
                        Valor = c.Int(nullable: false),
                        TasaCambio = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Control = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
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
                        //Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Numero = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Control = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.FacturaId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);

            Sql(@"Create FUNCTION dbo.GetSumDetalleFactura(@facturaId INT)
                   Returns Decimal(18,2)
                AS
                Begin
                
                DECLARE @facturaSum Decimal(18,2)
                
                select @facturaSum = sum((PrecioVenta * Cantidad))
                from DetalleFacturas
                where FacturaId = @facturaId
                and Active = 1

                return ISNULL(@facturaSum,0)
                END
                ");


            CreateTable(
                "dbo.FacturaDetalle",
                c => new
                    {
                        FacturaDetalleId = c.Int(nullable: false, identity: true),
                        FacturaId = c.Int(nullable: false),
                        OrdenEntradaId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 70, unicode: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                        Control = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.FacturaDetalleId)
                .ForeignKey("dbo.Factura", t => t.FacturaId)
                .ForeignKey("dbo.OrdenEntrada", t => t.OrdenEntradaId)
                .Index(t => t.FacturaId)
                .Index(t => t.OrdenEntradaId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 250, unicode: false),
                        Name = c.String(nullable: false, maxLength: 256, unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 250, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 250, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 20, unicode: false),
                        LastName = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 256, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 250, unicode: false),
                        SecurityStamp = c.String(maxLength: 250, unicode: false),
                        PhoneNumber = c.String(maxLength: 250, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 250, unicode: false),
                        ClaimType = c.String(maxLength: 250, unicode: false),
                        ClaimValue = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 250, unicode: false),
                        ProviderKey = c.String(nullable: false, maxLength: 250, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FacturaDetalle", "OrdenEntradaId", "dbo.OrdenEntrada");
            DropForeignKey("dbo.FacturaDetalle", "FacturaId", "dbo.Factura");
            DropForeignKey("dbo.Desglose", "FacturaId", "dbo.Factura");
            DropForeignKey("dbo.Factura", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Adelanto", "OrdenEntradaId", "dbo.OrdenEntrada");
            DropForeignKey("dbo.OrdenEntrada", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.OrdenEntrada", "EquipoId", "dbo.Equipo");
            DropForeignKey("dbo.Equipo", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.OrdenEntrada", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FacturaDetalle", new[] { "OrdenEntradaId" });
            DropIndex("dbo.FacturaDetalle", new[] { "FacturaId" });
            DropIndex("dbo.Factura", new[] { "ClienteId" });
            DropIndex("dbo.Desglose", new[] { "FacturaId" });
            DropIndex("dbo.Estado", "Index_Estado_Descripcion");
            DropIndex("dbo.Marcas", "Index_Marca_Nombre");
            DropIndex("dbo.Equipo", new[] { "MarcaId" });
            DropIndex("dbo.OrdenEntrada", new[] { "EstadoId" });
            DropIndex("dbo.OrdenEntrada", new[] { "EquipoId" });
            DropIndex("dbo.OrdenEntrada", new[] { "ClienteId" });
            DropIndex("dbo.Adelanto", new[] { "OrdenEntradaId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FacturaDetalle");
            DropTable("dbo.Factura");
            DropTable("dbo.Desglose");
            DropTable("dbo.Estado");
            DropTable("dbo.Marcas");
            DropTable("dbo.Equipo");
            DropTable("dbo.Cliente");
            DropTable("dbo.OrdenEntrada");
            DropTable("dbo.Adelanto");
        }
    }
}
