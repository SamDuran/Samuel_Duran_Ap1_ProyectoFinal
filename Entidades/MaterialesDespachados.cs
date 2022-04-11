using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class MaterialesDespachados
    {
        [Key]
        public int ID { get; set; }
        public decimal Cantidad { get; set; }
        public int SalidaId { get; set; }

        [ForeignKey("MaterialId")]
        public Materiales Material { get; set; } = new Materiales();
        public SalidasAlmacen Salida { get; set; } = new SalidasAlmacen();
    }
}