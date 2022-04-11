using Microsoft.EntityFrameworkCore;
using Entidades;

namespace Dal;

public partial class Contexto : DbContext
{
    /* OnModelCreating */
    public DbSet<Almacenes> Almacenes {get;set;} 
    /* Registros y consultas */
    public DbSet<EntradasAlmacen> EntradasAlmacenes {get;set;} //Registro
    public DbSet<Materiales> Materiales {get;set;} //Registro
    public DbSet<Transportistas> Transportistas {get;set;} //Registro
    public DbSet<SalidasAlmacen> SalidasAlmacen {get;set;} //Registro


    public Contexto(DbContextOptions<Contexto> options): base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        /* Caso base */
        base.OnModelCreating(builder);
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
    }
}
