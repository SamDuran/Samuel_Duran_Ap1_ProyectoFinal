using Dal;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Entidades;

namespace BLL
{
    public partial class TransportistasBLL
    {
        private Contexto contexto;

        public TransportistasBLL(Contexto _contexto) { this.contexto = _contexto; }

        private bool Existe(int id)
        {
            bool existe = false; 

            try
            {
                existe = contexto.Transportistas.Any(t => t.TransportistaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }
        public Transportistas? BuscarPorCarnet(int NoCarnet)
        {
            Transportistas? transportista;

            try
            {
                transportista = contexto.Transportistas
                .Where( t => t.NumeroCarnet== NoCarnet)
                .AsNoTracking()
                .FirstOrDefault();
            }
            catch (System.Exception)
            {
                throw;
            }

            return transportista;
        }

        public bool Guardar(Transportistas transportista)
        {
            if(Existe(transportista.TransportistaId))
                return Modificar(transportista);
            else
                return Insertar(transportista);
        }
        private bool Modificar(Transportistas transportista)
        {
            bool paso = false;

            try
            {
                contexto.Entry(transportista).State = EntityState.Modified;
                paso = contexto.SaveChanges()>0;
            }
            catch (Exception)
            {
                
                throw;
            }
            return paso;
        }
        private bool Insertar(Transportistas transportista)
        {
            bool paso = false;

            try
            {
                contexto.Transportistas.Add(transportista);
                paso = contexto.SaveChanges()>0;
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return paso;
        }
        public Transportistas? Buscar(int id)
        {
            Transportistas? transportista;

            try
            {
                transportista = contexto.Transportistas
                .Where( t => t.TransportistaId== id)
                .AsNoTracking()
                .FirstOrDefault();
            }
            catch (System.Exception)
            {
                throw;
            }
            return transportista;
        }
        public bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                var transportista = contexto.Transportistas.Find(id);
                if(transportista != null)
                {
                    contexto.Transportistas.Remove(transportista);
                    paso = contexto.SaveChanges()>0;
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return paso; 
        }
        public List<Transportistas> GetList(Expression<Func<Transportistas, bool>>criterio)
        {
            List<Transportistas> lista = new List<Transportistas>();

            try
            {
                lista = contexto.Transportistas
                .Where(criterio)
                .AsNoTracking()
                .ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
            return lista;
        }
    }
}