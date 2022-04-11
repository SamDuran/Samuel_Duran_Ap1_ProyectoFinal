using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Entidades;
using Dal;

namespace BLL
{
    public partial class EntradasBLL
    {
        private Contexto contexto;
        public EntradasBLL(Contexto _contexto){ contexto = _contexto;}

        private bool Existe(int id)
        {
            bool existe = false;

            try
            {
                existe = contexto.EntradasAlmacenes.Any(e => e.EntradaId == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return existe;
        }
        public bool Guardar(EntradasAlmacen entrada)
        {
            if(Existe(entrada.EntradaId))
                return Modificar(entrada);
            else
                return Insertar(entrada);
        }
        private bool Modificar(EntradasAlmacen entrada)
        {
            bool paso = false; 

            try
            {
                var entradaAnterior = contexto.EntradasAlmacenes
                .Where(e => e.EntradaId == entrada.EntradaId)
                .Include(e => e.MaterialesRecibidos)
                .ThenInclude(m => m.material)
                .Include(e => e.AlmacenOrigen)
                .AsNoTracking()
                .SingleOrDefault();

                if(entradaAnterior!=null)
                {
                    foreach (var recibidoAnterior in entradaAnterior.MaterialesRecibidos)
                    {
                        recibidoAnterior.material.Cantidad -= recibidoAnterior.Cantidad;
                    }
                    contexto.Database.ExecuteSqlRaw($"Delete FROM MaterialesRecibidos WHERE EntradaId={entrada.EntradaId}");

                    foreach (var recibido in entrada.MaterialesRecibidos)
                    {
                        contexto.Entry(recibido).State = EntityState.Added;
                        contexto.Entry(recibido.material).State = EntityState.Modified;

                        recibido.material.Cantidad += recibido.Cantidad;
                        recibido.material.ValorInventario = recibido.material.Cantidad*recibido.material.Costo;
                    }
                    contexto.Entry(entrada).State = EntityState.Modified;
                    paso = contexto.SaveChanges()>0;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return paso;
        }
        private bool Insertar(EntradasAlmacen entrada)
        {
            bool paso = false;

            try
            {
                foreach (var recibido in entrada.MaterialesRecibidos)
                {
                    contexto.Entry(recibido.material).State = EntityState.Modified;
                    contexto.Entry(recibido).State = EntityState.Added;

                    recibido.material.Cantidad += recibido.Cantidad;
                    recibido.material.ValorInventario = recibido.material.Cantidad*recibido.material.Costo;
                }
                contexto.Entry(entrada.AlmacenOrigen).State = EntityState.Modified;
                contexto.Entry(entrada.Transportista).State = EntityState.Modified;
                contexto.EntradasAlmacenes.Add(entrada);
                paso = contexto.SaveChanges()>0;
            }catch(Exception)
            {
                throw;
            }
            return paso;
        }
        public EntradasAlmacen? Buscar(int id)
        {
            EntradasAlmacen? entrada;

            try
            {
                entrada = contexto.EntradasAlmacenes
                .Where(e => e.EntradaId==id)
                .AsNoTracking()
                .Include(e => e.Transportista)
                .Include(e => e.AlmacenOrigen)
                .Include(e => e.MaterialesRecibidos)
                .ThenInclude(e => e.material)
                .SingleOrDefault();
            }
            catch (System.Exception)
            {
                throw;
            }

            return entrada;
        }
        public bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                var entrada = contexto.EntradasAlmacenes.Find(id);
                if(entrada!=null)
                {
                    foreach(var recibido in entrada.MaterialesRecibidos)
                    {
                        contexto.Entry(recibido.entrada).State = EntityState.Modified;
                        contexto.Entry(recibido.material).State = EntityState.Modified;
                        recibido.material.Cantidad -= recibido.Cantidad;
                        recibido.material.ValorInventario = recibido.material.Cantidad*recibido.material.Costo;
                    }
                    contexto.Entry(entrada.AlmacenOrigen).State = EntityState.Modified;
                    contexto.Entry(entrada.Transportista).State = EntityState.Modified;
                    contexto.EntradasAlmacenes.Remove(entrada);
                    paso = contexto.SaveChanges()>0;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return paso;
        }
        public List<EntradasAlmacen> GetList(Expression<Func<EntradasAlmacen, bool>>criterio)
        {
            List<EntradasAlmacen> lista = new List<EntradasAlmacen>();

            try
            {
                lista = contexto.EntradasAlmacenes
                .Where(criterio)
                .Include(e => e.Transportista)
                .Include(e => e.MaterialesRecibidos)
                .ThenInclude(e => e.material)
                .Include(e => e.AlmacenOrigen)
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