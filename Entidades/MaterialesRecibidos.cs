using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public partial class MaterialesRecibidos
    {
        [Key]
        public int ID { get; set; }
        public decimal Cantidad { get; set; }
        public int EntradasAlmacenEntradaId { get; set; }
        public int MaterialId { get; set; }

        //Constructores y metodos
        public MaterialesRecibidos(){}
        public MaterialesRecibidos(decimal cantidad, int idEntrada, int idMaterial)
        {
            Cantidad = cantidad;
            EntradasAlmacenEntradaId = idEntrada;
            MaterialId = idMaterial;
        }

        public override bool Equals(object? obj)
        {
            if(obj==null)
                return false;
            if(!(obj is MaterialesRecibidos))
                return false;
            
            return (this.ID==((MaterialesRecibidos)obj).ID)
            && (this.Cantidad ==((MaterialesRecibidos)obj).Cantidad)
            && (this.EntradasAlmacenEntradaId ==((MaterialesRecibidos)obj).EntradasAlmacenEntradaId)
            && (this.MaterialId ==((MaterialesRecibidos)obj).MaterialId);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}