using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WorkOutApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WorkOutContext(
                serviceProvider.GetRequiredService<DbContextOptions<WorkOutContext>>()))
            {
                // Look for any movies.
                if (context.WorkOut.Any())
                {
                    return;   // DB has been seeded
                }

                context.WorkOut.AddRange(
                    new WorkOut
                    {
                        Id = 11,
                        Date = DateTime.Parse("2018-11-12"),
                        DistanceInMenters = 250,
                        TimeInSeconds = 38
                    },

                    new WorkOut
                    {
                        Id = 12,
                        Date = DateTime.Parse("2018-10-12"),
                        DistanceInMenters = 100,
                        TimeInSeconds = 12
                    },

                    new WorkOut
                    {
                        Id = 13,
                        Date = DateTime.Parse("2018-9-12"),
                        DistanceInMenters = 150,
                        TimeInSeconds = 19
                    },

                    new WorkOut
                    {
                        Id = 14,
                        Date = DateTime.Parse("2018-8-12"),
                        DistanceInMenters = 500,
                        TimeInSeconds = 54
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
