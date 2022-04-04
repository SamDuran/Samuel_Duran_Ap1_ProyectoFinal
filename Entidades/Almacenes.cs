using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class Almacenes
    {
        [Key]
        public int AlmacenId { get; set; }
        public string NombreCentro { get; set; } = string.Empty;
        public string DenominacionCentro { get; set; } = string.Empty; //Esto porque puede ser de Edesur, edenorte o edeeste
        public string NombreAlmacen { get; set; } = string.Empty;
        public string DenominacionAlmacen { get; set; } = string.Empty;
    }
}