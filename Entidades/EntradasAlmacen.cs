using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class EntradasAlmacen
    {
        [Key]
        public int EntradaId { get; set; }

        [Required(ErrorMessage ="Se debe indicar la fecha de la entrada.")]
        public DateTime FechaEntrada { get; set; } = DateTime.Today;

        [Required(ErrorMessage ="Se debe indicar un transportista")]
        public Transportistas Transportista {get; set;} = new Transportistas();

        [Required(ErrorMessage ="Campo obligatorio, se debe indicar un almacen de orígen")]
        public Almacenes AlmacenOrigen { get; set; } = new Almacenes();
        public decimal PrecioTotal {get;set;}

        [ForeignKey("EntradaId")] 
        public virtual List<MaterialesRecibidos> MaterialesRecibidos {get; set;}= new List<MaterialesRecibidos>();
    }
}