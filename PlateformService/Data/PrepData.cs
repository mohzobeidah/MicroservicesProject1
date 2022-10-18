using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlateformService.Models;
namespace PlateformService.Data
{
    public static class PrepData
    {
        public static void PrepDataPopulation(IApplicationBuilder app)
        {
            using( var ServicesScope = app.ApplicationServices.CreateScope()){

            //ServicesScope.ServiceProvider.GetService<AppDataContext>();
            seedData( ServicesScope.ServiceProvider.GetService<AppDataContext>());
            }

        }

        private static void seedData(AppDataContext context)
        {

            if (!context.Plateforms.Any())
            {
                Console.WriteLine("seeding data");

                    context.Plateforms.AddRange(   
                    new Plateform() {Name="Dot Net", Publisher="Microsoft", Cost="Free"},
                    new Plateform() {Name="SQL Server Express", Publisher="Microsoft",  Cost="Free"},
                    new Plateform() {Name="Kubernetes", Publisher="Cloud Native Computing Foundation",  Cost="Free"}
                    );
                    context.SaveChanges();
            }
            else
            {
                Console.WriteLine("there is Already data");
            }

        }
    }
}