using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectResume.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectResume.Models
{
    public class PersonSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //look for any records, if there are records do nothing
                if (context.Person.Any())
                {
                    return;
                }
                context.Person.AddRange(
                    new Person
                    {
                        PersonID = 1,
                        FirstName = "Jennifer",
                        LastName = "Demiter",
                        StreetAddress = "1928 Maderia Dr NE",
                        City = "Albuquerque",
                        State = "New Mexico",
                        Zip = "87110",
                        Email = "jdemiter@gmail.com",
                        PhoneNumber = "915-497-2876"
                    },
                    new Person
                    { 
                    PersonID = 2,
                        FirstName = "Test",
                        LastName = "Student",
                        StreetAddress = "1928 Avenue Dr NE",
                        City = "Albuquerque",
                        State = "New Mexico",
                        Zip = "87112",
                        Email = "demailr@gmail.com",
                        PhoneNumber = "915-222-2876"
                },
                    new Person
                    {
                        PersonID = 3,
                        FirstName = "Another",
                        LastName = "Test",
                        StreetAddress = "1928 Street Dr NE",
                        City = "Albuquerque",
                        State = "New Mexico",
                        Zip = "87114",
                        Email = "jemail@gmail.com",
                        PhoneNumber = "915-111-2876"
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
