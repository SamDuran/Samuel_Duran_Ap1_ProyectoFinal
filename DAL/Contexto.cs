using Microsoft.EntityFrameworkCore;
using Entidades;

namespace Dal;

public partial class Contexto : DbContext
{
    public DbSet<Almacenes> Almacenes {get;set;} //Por defecto
    
    public DbSet<EntradasAlmacen> EntradasAlmacenes {get;set;} //Registro
    public DbSet<Materiales> Materiales {get;set;} //Registro
    public DbSet<Transportistas> Transportistas {get;set;} //Registro

    public Contexto(DbContextOptions<Contexto> options): base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        /* base.OnModelCreating(builder); */
        builder.Entity<Almacenes>().HasData(new Almacenes{
            AlmacenId = 1,
            NombreCentro = "N300",
            DenominacionCentro = "San Francisco - Edenorte",
            NombreAlmacen = "N301",
            DenominacionAlmacen = "San Francisco"
        });
        builder.Entity<Almacenes>().HasData(new Almacenes{
            AlmacenId = 2,
            NombreCentro = "N100",
            DenominacionCentro="Santiago - Edenorte",
            NombreAlmacen = "N101",
            DenominacionAlmacen="Santiago"
        });
        builder.Entity<Almacenes>().HasData(new Almacenes{
            AlmacenId = 3,
            NombreCentro = "N400",
            DenominacionCentro="Puerto Plata - Edenorte",
            NombreAlmacen = "N401",
            DenominacionAlmacen="Puerto plata"
        });
        builder.Entity<Almacenes>().HasData(new Almacenes{
            AlmacenId = 4,
            NombreCentro = "N500",
            DenominacionCentro="Mao- Edenorte",
            NombreAlmacen = "N501",
            DenominacionAlmacen="Mao"
        });
        builder.Entity<Almacenes>().HasData(new Almacenes{
            AlmacenId = 5,
            NombreCentro = "N600",
            DenominacionCentro="La vega - Edenorte",
            NombreAlmacen = "N601",
            DenominacionAlmacen="La vega"
        });
    }
}
