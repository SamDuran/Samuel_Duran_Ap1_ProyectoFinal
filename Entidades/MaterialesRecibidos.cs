using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class MaterialesRecibidos
    {
        [Key]
        public int ID { get; set; }
        public decimal Cantidad { get; set; }
        public int EntradaId { get; set; }

        [ForeignKey("MaterialId")]
        public Materiales material { get; set; } = new Materiales();
        public EntradasAlmacen entrada { get; set; } = new EntradasAlmacen();
    }
}