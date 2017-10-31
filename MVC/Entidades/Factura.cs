using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entidades
{
    [Table("Factura")]
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar el {0}")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DisplayFormat(DataFormatString ="{0:0.###")]
        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime DateCreation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime DateModification { get; set; }          

        public virtual IEnumerable<FacturaDetalle> FacturasDetalle { get; set; }

        public virtual IEnumerable<Desglose> Desgloses { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Clientes { get; set; }
        
        //public IEnumerable<Adelanto> Adelantos { get; set; }

    }
}
// Para facturación se hace el campo con opción especial, además se crea el script
// para generar la base de datos con update-database -script

//script para sumar la factura
// select sum(""(PrecioVenta*Cantidad)+((PrecioVenta*Cantidad)*IVA))
// from DetalleFacturas
//where FacturaId= @facturaId
// and Active=1

//En el migration:
//Sql(@"Create Function dbo.GetsumDetalleFactura(@FacturaId int)
//                        Returns Decimal(18,2)
//                        As
//                        Begin
//                        Declare @facturaSum Decimal(18,2)
//                            select @facturaSum = sum((Precio ) + ((Precio) * IVA))
//                            from DetalleFactura
//                            where FacturaId = @facturaId
//                            and Active = 1
//                        return IsNull(@facturaSum,0)
//                        End
//                        ");

//                Sql(@"Alter Table dbo.Factura
//                    add Total as dbo.GetSumDetalleFactura(id)");