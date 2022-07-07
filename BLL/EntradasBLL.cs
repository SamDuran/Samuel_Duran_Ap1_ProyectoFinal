using System.Linq.Expressions;
using Dal;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public partial class EntradasBLL
    {
        private Contexto contexto;
        public EntradasBLL(Contexto _contexto) { contexto = _contexto; }
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
            if (Existe(entrada.EntradaId))
                return Modificar(entrada, EntityState.Added);
            else
                return Insertar(entrada);
        }
        private bool Modificar(EntradasAlmacen entrada, EntityState added)
        {
            bool paso = false;
            try
            {
                var entradaAnterior = contexto.EntradasAlmacenes
                .AsNoTracking()
                .Include(e => e.MaterialesRecibidos)
                .SingleOrDefault(e => e.EntradaId == entrada.EntradaId);

                if (entradaAnterior != null)
                {
                    MaterialesRecibidos? Materialrecibido = new MaterialesRecibidos();
                    var material = new Materiales();

                    foreach (var recibido in entradaAnterior.MaterialesRecibidos)
                    {
                        material = contexto.Materiales.Find(recibido.MaterialId);
                        if(material != null)
                        {
                            material.Cantidad -=recibido.Cantidad;//Devolvemos los valores entrantes del material
                            entrada.PrecioTotal -= material.Costo * recibido.Cantidad; //Recalculamos el valor total de la entrada
                        }
                    }
                    
                    contexto.Database.ExecuteSqlRaw($"Delete FROM MaterialesRecibidos WHERE EntradasAlmacenEntradaId={entradaAnterior.EntradaId}");
                    
                    
                    MaterialesRecibidos? recibidoDeEntradaAnterior;
                    foreach (var recibido in entrada.MaterialesRecibidos)
                    {
                        recibidoDeEntradaAnterior = entradaAnterior.MaterialesRecibidos.FirstOrDefault(r => r.Equals(recibido));
                        material=contexto.Materiales.Find(recibido.MaterialId);
                        if(material != null)
                        {
                            material.Cantidad += recibido.Cantidad;//Aumentamos los valores entrantes del material
                            if (recibidoDeEntradaAnterior == null) //si este recibido es nuevo o diferente en la entrada
                            {
                                contexto.Entry(material).State = EntityState.Modified;
                            }
                            entrada.PrecioTotal += material.Costo * recibido.Cantidad;
                        }
                        contexto.Entry(recibido).State = EntityState.Added;
                        material = null;
                        recibidoDeEntradaAnterior = null;
                    }
                    contexto.Entry(entrada).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                    contexto.Entry(entrada).State = EntityState.Detached;
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
            var material = new Materiales();

            try
            {
                foreach (var recibido in entrada.MaterialesRecibidos)
                {
                    material = contexto.Materiales.Find(recibido.MaterialId);
                    if(material!=null)
                    {
                        material.Cantidad += recibido.Cantidad;
                        material.ValorInventario = material.Cantidad * material.Costo;

                        //contexto.Attach(material);
                        contexto.Entry(material).State = EntityState.Modified;
                        contexto.Entry(recibido).State = EntityState.Added;
                    }
                }
                contexto.Entry(entrada).State = EntityState.Added;
                paso = contexto.SaveChanges() > 0;
                contexto.Entry(entrada).State = EntityState.Detached;
            }
            catch (Exception)
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
                entrada = contexto.EntradasAlmacenes.AsNoTracking()
                .Include(e => e.MaterialesRecibidos)
                .FirstOrDefault(e => e.EntradaId == id);
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
                var material = new Materiales();
                if (entrada != null)
                {
                    foreach (var recibido in entrada.MaterialesRecibidos)
                    {
                        material = contexto.Materiales.Find(recibido.MaterialId);
                        if(material!=null)
                        {
                            contexto.Entry(material).State = EntityState.Modified;
                            material.Cantidad -= recibido.Cantidad;
                            material.ValorInventario = material.Cantidad * material.Costo;
                        }
                    }
                    contexto.EntradasAlmacenes.Remove(entrada);
                    paso = contexto.SaveChanges() > 0;
                    contexto.Entry(entrada).State = EntityState.Detached;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return paso;
        }
        public List<EntradasAlmacen> GetList(Expression<Func<EntradasAlmacen, bool>> criterio)
        {
            List<EntradasAlmacen> lista = new List<EntradasAlmacen>();

            try
            {
                lista = contexto.EntradasAlmacenes
                .Include(e => e.MaterialesRecibidos)
                .Where(criterio).AsNoTracking().ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
            return lista;
        }
    }
}