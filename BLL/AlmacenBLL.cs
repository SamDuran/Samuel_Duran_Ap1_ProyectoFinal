using Microsoft.EntityFrameworkCore;
using Entidades;
using Dal;

namespace BLL
{
    public class AlmacenBLL
    {
        private Contexto contexto;
        public AlmacenBLL(Contexto _contexto) { contexto = _contexto; }
        public Almacenes? Buscar(int id)
        {
            Almacenes? almacen;

            try
            {
                almacen = contexto.Almacenes.AsNoTracking()
                .FirstOrDefault(a => a.AlmacenId==id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return almacen;
        }
        public List<Almacenes> GetList()
        {
            return contexto.Almacenes
            .AsNoTracking()
            .ToList();
        }
    }
}