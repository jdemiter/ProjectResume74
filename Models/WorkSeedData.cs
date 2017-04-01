using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectResume.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectResume.Models
{
    public class WorkSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //look for any records, if there are records do nothing
                if(context.WorkExperience.Any())
                {
                    return;
                }
                context.WorkExperience.AddRange(
                    new WorkExperience
                    {
                        Employer = "Verizon Wireless",
                        Location = "Albuquerque, NM",
                        JobTitle = "Sr. Trainer",
                        EmploymentStartDate = DateTime.Parse("2014-8-31"),
                        EmploymentEndDate = DateTime.Parse("2017-4-1")

                    }
                    );
                context.SaveChanges();

            }
        }
    }
}
