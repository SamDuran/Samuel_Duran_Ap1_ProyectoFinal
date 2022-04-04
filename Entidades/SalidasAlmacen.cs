using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class SalidasAlmacen
    {
        [Key]
        public int SalidasId { get; set; }
        
        [Required(ErrorMessage ="Se debe indicar la fecha de la salida")]
        public DateTime FechaSalida { get; set; } = DateTime.Today;

        [Required(ErrorMessage ="Se debe indicar el nombre del operario")]
        [MinLength(3,ErrorMessage ="El nombre del operario debe tener {1} caracteres como mínimo.")]
        [MaxLength(50, ErrorMessage ="El nombre del operario debe tener {1} caracteres como máximo.")]
        public string Operario {get; set;} = "";  //Nombre de quien operó la salida

        [Required(ErrorMessage ="Se debe indicar un transportista")]
        public Transportistas Transportista {get; set;} = new Transportistas();
        

        [Required(ErrorMessage ="Se debe indicar un almacen destino")]
        public Almacenes AlmacenDestino { get; set; } = new Almacenes();


        [ForeignKey("SalidaId")]
        public virtual List<Materiales> Materiales {get; set;}= new List<Materiales>();
    }
}