using System.Linq;
using SchoolSolution.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace SchoolSolution.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolDbContext ctx)
        {
            //ctx.Database.EnsureDeleted();
            //ctx.Database.EnsureCreated();
            ctx.Database.Migrate();
            if (ctx.PaimentType.Any())
            {
                return;
            }
            var types = new PaiementType[]
            {
                new PaiementType{Description = "N/A" },
                new PaiementType{Description = "Minerval" },
                new PaiementType{Description = "Frais Scolaire"},
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
                new PaiementFor{Month = "Août"},
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
                new Period{Name="1er P"},
                new Period{Name="2eme P"},
                new Period{Name="Exam Semèstre I"},
                new Period{Name="Total Semèstre I"},
                new Period{Name="3eme P"},
                new Period{Name="4eme P"},
                new Period{Name="Exam semèstre II"},
                new Period{Name="Total semèstre II"},
            };
            ctx.AddRange(period);
            ctx.SaveChanges();


        }
    }
}
