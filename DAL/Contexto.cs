using Microsoft.EntityFrameworkCore;
using Entidades;

namespace Dal;

public partial class Contexto : DbContext
{
    /* OnModelCreating */
    public DbSet<Almacenes> Almacenes {get;set;} = null!;
    /* Registros y consultas */
    public DbSet<EntradasAlmacen> EntradasAlmacenes {get;set;}  = null!;//Registro
    public DbSet<Materiales> Materiales {get;set;} = null!;//Registro
    public DbSet<Transportistas> Transportistas {get;set;} = null!;//Registro
    public DbSet<SalidasAlmacen> SalidasAlmacen {get;set;} = null!;//Registro

    public Contexto(DbContextOptions<Contexto> options): base(options){
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        /* Almacenes */
        {
            builder.Entity<Almacenes>().HasData(new Almacenes{
                AlmacenId = 1,
                NombreCentro = "N100",
                DenominacionCentro="Santiago - Edenorte"
            });
            builder.Entity<Almacenes>().HasData(new Almacenes{
                AlmacenId = 2,
                NombreCentro = "N200",
                DenominacionCentro="Samaná - Edenorte"
            });
            builder.Entity<Almacenes>().HasData(new Almacenes{
                AlmacenId = 3,
                NombreCentro = "N300",
                DenominacionCentro = "San Francisco - Edenorte"
            });
            builder.Entity<Almacenes>().HasData(new Almacenes{
                AlmacenId = 4,
                NombreCentro = "N400",
                DenominacionCentro="Puerto Plata - Edenorte"
            });
            builder.Entity<Almacenes>().HasData(new Almacenes{
                AlmacenId = 5,
                NombreCentro = "N500",
                DenominacionCentro="Mao- Edenorte"
            });
            builder.Entity<Almacenes>().HasData(new Almacenes{
                AlmacenId = 6,
                NombreCentro = "N600",
                DenominacionCentro="La vega - Edenorte"
            });
            builder.Entity<Almacenes>().HasData(new Almacenes{
                AlmacenId = 7,
                NombreCentro = "N700",
                DenominacionCentro="Espaillat - Edenorte"
            });
            builder.Entity<Almacenes>().HasData(new Almacenes{
                AlmacenId = 8,
                NombreCentro = "N800",
                DenominacionCentro="Valverde - Edenorte"
            });
        }
        /* Materiales */
        {
            builder.Entity<Materiales>().HasData(new Materiales{
                MaterialId = 1,
                Descripcion = "Poste Hormigón",
                UnidadesMedida = "Unidad",
                Cantidad = 0,
                ValorInventario = 0.00m,
                Costo = 200.00m,
                FechaRegistro = DateTime.Today
            });
            builder.Entity<Materiales>().HasData(new Materiales{
                MaterialId = 2,
                Descripcion = "Cable Cobre",
                UnidadesMedida = "Metros",
                Cantidad = 2,
                ValorInventario = 600.00m,
                Costo = 300.00m,
                FechaRegistro = DateTime.Today
            });
            builder.Entity<Materiales>().HasData(new Materiales{
                MaterialId = 3,
                Descripcion = "Tornillo",
                UnidadesMedida = "Unidad",
                Cantidad = 0,
                ValorInventario = 0.00m,
                Costo = 30.00m,
                FechaRegistro = DateTime.Today
            });
        }
        /* Transportista */
        {
            builder.Entity<Transportistas>().HasData(new Transportistas{
                TransportistaId = 1,
                Nombres="Juan Steven",
                Apellidos="Perez",
                NumeroCarnet=1000,
                FechaRegistro = DateTime.Today
            });
            builder.Entity<Transportistas>().HasData(new Transportistas{
                TransportistaId = 2,
                Nombres="Samuel",
                Apellidos="Duran",
                NumeroCarnet=1001,
                FechaRegistro = DateTime.Today
            });
            builder.Entity<Transportistas>().HasData(new Transportistas{
                TransportistaId = 3,
                Nombres="Juan",
                Apellidos="Perez",
                NumeroCarnet=1002,
                FechaRegistro = DateTime.Today
            });
        }
    }
}
