using System.Linq.Expressions;
using Dal;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public partial class MaterialesBLL
    {
        public Contexto contexto { get; set; }
        public MaterialesBLL(Contexto _contexto) { contexto = _contexto; }

        public Materiales? Buscar(int id)
        {
            Materiales? material;
            try
            {
                material = contexto.Materiales
                .Where(m => m.MaterialId == id)
                .AsNoTracking()
                .SingleOrDefault();
            }
            catch (System.Exception)
            {
                throw;
            }
            return material;
        }
        public Materiales? BuscarPorDescripcion(string descripcion)
        {
            Materiales? material;
            try
            {
                material = contexto.Materiales
                .Where(m => m.Descripcion.ToLower().Contains(descripcion.ToLower()))
                .AsNoTracking()
                .SingleOrDefault();
            }
            catch (System.Exception)
            {
                throw;
            }
            return material;
        }
        private bool Existe(int id)
        {
            bool existe = false;

            try
            {
                existe = contexto.Materiales.Any(m => m.MaterialId == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return existe;
        }
        public bool Guardar(Materiales material)
        {
            if (Existe(material.MaterialId))
                return Modificar(material);
            else
                return Insertar(material);
        }
        private bool Modificar(Materiales material)
        {
            bool paso = false;

            try
            {
                contexto.Entry(material).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
            return paso;
        }
        private bool Insertar(Materiales material)
        {
            bool paso = false;

            try
            {
                contexto.Materiales.Add(material);
                paso = contexto.SaveChanges() > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
            return paso;
        }
        public bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                var material = contexto.Materiales.Find(id);
                if (material != null)
                {
                    contexto.Materiales.Remove(material);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return paso;
        }
        public List<Materiales>? GetList(Expression<Func<Materiales, bool>> criterio)
        {
            var lista = new List<Materiales>();
            try
            {
                lista = contexto.Materiales
                .Where(criterio)
                .AsNoTracking()
                .ToList();
            }
            catch
            {
                throw;
            }

            return lista;
        }
    }
}