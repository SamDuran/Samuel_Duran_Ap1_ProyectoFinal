using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class SalidasAlmacen
    {
        [Key]
        public int SalidaId { get; set; }

        [Required(ErrorMessage ="Se debe indicar la fecha de la salida")]
        public DateTime FechaSalida { get; set; } = DateTime.Today;


        [Required(ErrorMessage ="Se debe indicar un transportista")]
        public Transportistas Transportista {get; set;} = new Transportistas();
        
        public decimal CostoTotal { get; set; } //ReadOnly

        [Required(ErrorMessage ="Se debe indicar un almacen destino")]
        public Almacenes AlmacenDestino { get; set; } = new Almacenes();

        [ForeignKey("SalidaId")]
        public virtual List<MaterialesDespachados> MaterialesDespachados {get; set;}= new List<MaterialesDespachados>();
    }
}