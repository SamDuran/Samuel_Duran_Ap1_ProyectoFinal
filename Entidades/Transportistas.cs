using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class Transportistas
    {
        [Key]
        public int TransportistaId { get; set; }

        [Required(ErrorMessage= "Campo obligatorio.")]
        [MinLength(3, ErrorMessage="El nombre debe tener mínimamente {1} caractéres.")]
        [MaxLength(40, ErrorMessage="El nombre debe tener como máximo {1} caractéres.")]
        public string Nombres { get; set; } = String.Empty;

        [Required(ErrorMessage= "Campo obligatorio.")]
        [MaxLength(40, ErrorMessage="Este campo permite un valor máximo de {1} caractéres.")]
        public string Apellidos { get; set; } = String.Empty;

        [Required(ErrorMessage= "Campo obligatorio.")]
        [Range(1000, 99999,ErrorMessage="El Numero del carnet debe estar comprendido entre 1000 y 10000.")]
        public int NumeroCarnet { get; set; }
        
        [Required(ErrorMessage= "Campo obligatorio.")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}