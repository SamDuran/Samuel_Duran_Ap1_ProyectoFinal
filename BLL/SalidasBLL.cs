using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Entidades;
using Dal;

namespace BLL
{
    public partial class SalidasBLL
    {
        private Contexto contexto {get;set;}
        public SalidasBLL(Contexto _contexto){ contexto  = _contexto; }

        public SalidasAlmacen? Buscar(int id)
        {
            SalidasAlmacen? salidaBuscada;

            try
            {
                salidaBuscada = contexto.SalidasAlmacen.AsNoTracking()
                .Where(s => s.SalidaId==id)
                .Include(s => s.MaterialesDespachados)
                .ThenInclude(d => d.Material).AsNoTracking()
                .Include(s=>s.AlmacenDestino).AsNoTracking()
                .Include(s => s.Transportista).AsNoTracking()
                .FirstOrDefault();
            }
            catch (System.Exception)
            {
                throw;
            }
            return salidaBuscada;
        }
        private bool Existe(int id)
        {
            bool existe = false;
            try
            {
                existe = contexto.SalidasAlmacen.Any(s => s.SalidaId==id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return existe;
        }
        public bool Guardar(SalidasAlmacen salida)
        {
            if(Existe(salida.SalidaId))
                return Modificar(salida);
            else
                return Insertar(salida);
        }
        private bool Insertar(SalidasAlmacen salida)
        {
            bool paso= false;

            try
            {
                foreach (var despachado in salida.MaterialesDespachados)
                {
                    contexto.Entry(despachado.Material).State = EntityState.Modified;
                    contexto.Entry(despachado).State = EntityState.Added;

                    despachado.Material.Cantidad-= despachado.Cantidad;
                    despachado.Material.ValorInventario = despachado.Material.Cantidad*despachado.Material.Costo;
                }
                contexto.Entry(salida).State = EntityState.Added;
                paso = contexto.SaveChanges()>0;
            }
            catch (System.Exception)
            {
                throw;
            }
            return paso;
        }
        private bool Modificar(SalidasAlmacen salidaModificada)
        {
            bool paso = false;

            try
            {
                var SalidaAnterior = contexto.SalidasAlmacen
                .Include(s => s.MaterialesDespachados)
                .ThenInclude(s => s.Material).AsNoTracking()
                .Include(s => s.AlmacenDestino).AsNoTracking()
                .Include(s => s.Transportista).AsNoTracking()
                .Where(s => s.SalidaId == salidaModificada.SalidaId)
                .AsNoTracking().SingleOrDefault();

                if(SalidaAnterior!=null)
                {
                    foreach(var despachadoAnterior in SalidaAnterior.MaterialesDespachados)
                    {
                        despachadoAnterior.Material.Cantidad += despachadoAnterior.Cantidad;
                        despachadoAnterior.Material.ValorInventario = despachadoAnterior.Material.Cantidad*despachadoAnterior.Material.Costo;
                    }
                    contexto.Database.ExecuteSqlRaw($"Delete FROM MaterialesDespachados WHERE SalidaId={SalidaAnterior.SalidaId}");
                    
                    foreach (var despachado in salidaModificada.MaterialesDespachados)
                    {
                        contexto.Entry(despachado).State = EntityState.Added;
                        contexto.Entry(despachado.Material).State = EntityState.Modified;

                        despachado.Material.Cantidad -= despachado.Cantidad;
                        despachado.Material.ValorInventario = despachado.Material.Cantidad*despachado.Material.Costo;
                    }
                    contexto.Entry(salidaModificada).State = EntityState.Modified;
                    paso = contexto.SaveChanges()>0;
                }
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
                var salida = contexto.SalidasAlmacen.Find(id);
                if(salida!=null)
                {
                    foreach (var despachado in salida.MaterialesDespachados)
                    {
                        contexto.Entry(despachado.Salida).State = EntityState.Modified;
                        contexto.Entry(despachado.Material).State = EntityState.Modified;

                        despachado.Material.Cantidad += despachado.Cantidad;
                        despachado.Material.ValorInventario = despachado.Material.Cantidad * despachado.Material.Costo;
                    }

                    contexto.Remove(salida);
                    paso = contexto.SaveChanges()>0;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return paso;
        }
        public List<SalidasAlmacen> GetList(Expression<Func<SalidasAlmacen, bool>>criterio)
        {
            List<SalidasAlmacen> lista = new List<SalidasAlmacen>();

            try
            {
                lista=contexto.SalidasAlmacen
                .Include(s => s.AlmacenDestino).AsNoTracking()
                .Include(s =>s.Transportista).AsNoTracking()
                .Include(s =>s.MaterialesDespachados).ThenInclude(s =>s.Material).AsNoTracking()
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