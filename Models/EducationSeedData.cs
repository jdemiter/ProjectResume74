using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectResume.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectResume.Models
{
    public class EducationSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //look for any records, if there are records do nothing
                if (context.Education.Any())
                {
                    return;
                }
                context.Education.AddRange(
                    new Education
                    {
                        School = "Arizona State University",
                        DegreeReceived = "Bachelor of Arts",
                        Concentration = "Spanish Language and Literature",
                        DateCompleted = DateTime.Parse("2003-5-24")
                        

                    }
                    );
                context.SaveChanges();

            }
        }
    }
}

    
