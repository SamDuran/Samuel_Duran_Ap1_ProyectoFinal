using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class SalidasAlmacen
    {
        [Key]
        public int SalidaId { get; set; }

        public DateTime FechaSalida { get; set; } = DateTime.Today;


        public int TransportistaId { get; set; } //ForeignKey de Transportista

        public int AlmacenId { get; set; } //ForeignKey de Almacen 

        public decimal CostoTotal { get; set; } //ReadOnly

        public virtual List<MaterialesDespachados> MaterialesDespachados {get; set;}= new List<MaterialesDespachados>();
    }
}