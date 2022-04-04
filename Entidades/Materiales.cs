using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public partial class Materiales
    {
        [Key]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Debe indicar la descripción.")]
        [MinLength(3, ErrorMessage = "La descripción debe tener al menos {1} caractéres.")]
        [MaxLength(35, ErrorMessage = "La descripción no debe pasar de {1} caractéres.")]
        public string Descripcion { get; set; } ="";


        [Required(ErrorMessage =("Campo obligatorio. Debe indicar la unidad en la que se mide el material."))]
        public string UnidadesMedida { get; set; } = "";

        [Required(ErrorMessage = ("Campo obligatorio. Debe indicar la cantidad del material."))]
        [Range(0.1, 10000000, ErrorMessage ="La cantidad debe permanecer dentro de un rango de {1} a {2}.")]
        public decimal Cantidad { get; set; }

        [Required(ErrorMessage ="Campo obligatorio. Debe indicar el costo del material.")]
        [Range(1,25000000, ErrorMessage ="El costo debe permanecer dentro de un rango de {1} a {2}.")]
        public decimal Costo {get; set;}
        
        [Required(ErrorMessage ="Campo obligatorio")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

    }
}