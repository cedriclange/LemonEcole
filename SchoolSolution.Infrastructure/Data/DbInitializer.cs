using System.Linq;
using SchoolSolution.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace SchoolSolution.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolDbContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            if (ctx.PaimentType.Any())
            {
                return;
            }
            var types = new PaiementType[]
            {
                new PaiementType{Description = "N/A" },
                new PaiementType{Description = "Minerval" },
                new PaiementType{Description = "Frais Scholaire"},
                new PaiementType{Description = "Autres frais" }
            };
            ctx.AddRange(types);
            ctx.SaveChanges();

            var months = new PaiementFor[]
            {
                new PaiementFor{Month = "Janvier"},
                new PaiementFor{Month = "Fevrier"},
                new PaiementFor{Month = "Mars"},
                new PaiementFor{Month = "Avril"},
                new PaiementFor{Month = "Mai"},
                new PaiementFor{Month = "Juin"},
                new PaiementFor{Month = "Juillet"},
                new PaiementFor{Month = "Aout"},
                new PaiementFor{Month = "Septembre"},
                new PaiementFor{Month = "Octobre"},
                new PaiementFor{Month = "Novembre"},
                new PaiementFor{Month = "Decembre"},
                new PaiementFor{Month = "N/A"}
            };
            ctx.AddRange(months);
            ctx.SaveChanges();
            var period = new Period[]
            {
                new Period{Name="Première"},
                new Period{Name="Deuxième"},
                new Period{Name="Troisième"},
                new Period{Name="Quatrieme"},
                new Period{Name="Examen premier semestre"},
                new Period{Name="Total premier semestre"},
                new Period{Name="Examen deuxième semestre"},
                new Period{Name="Total deuxième semestre"},
            };
            ctx.AddRange(period);
            ctx.SaveChanges();


        }
    }
}
