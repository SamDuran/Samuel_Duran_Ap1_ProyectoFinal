using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class EntradasAlmacen
    {
        [Key]
        public int EntradaId { get; set; }

        public DateTime FechaEntrada { get; set; } = DateTime.Today;

        public int TransportistaId { get; set; } //ForeignKey de Transportista

        public int AlmacenId { get; set; } //ForeignKey de Almacen        public Almacenes Almacen { get; set; } = new Almacenes();
        
        public decimal PrecioTotal {get;set;}

        public virtual List<MaterialesRecibidos> MaterialesRecibidos {get; set;}= new List<MaterialesRecibidos>();


        //Constructores
        public EntradasAlmacen(DateTime fecha, int IdTransportista, int idAlmacen, decimal precioTotal, List<MaterialesRecibidos> materiales)
        {
            FechaEntrada= fecha;
            AlmacenId = idAlmacen;
            TransportistaId = IdTransportista;
            PrecioTotal = precioTotal;
            MaterialesRecibidos=materiales;
        }
        public EntradasAlmacen(){}
    }
}